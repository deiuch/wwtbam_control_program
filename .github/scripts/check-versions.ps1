# Checks the programs' versions: both programs must carry one version, a change against -Base must be a
# single-step increment (one part up by one, every part to its right reset to 0), and a release -Tag must
# name that version. Problems are printed as GitHub annotations; the exit code is 1 if there are any.
# In GitHub Actions it also outputs the version's release tag ("tag") and whether -Base had another version ("changed").
param(
    [string]$Base, # Commit to compare with; empty or all zeros when there is none
    [string]$Tag   # Release tag being pushed, if any
)

$files = 'src/ControlProgram/MyProject/AssemblyInfo.vb', 'src/FastestFingerFirst/MyProject/AssemblyInfo.vb'
$attributes = 'AssemblyVersion', 'AssemblyFileVersion'
$problems = New-Object System.Collections.Generic.List[string]

function Get-Versions([string]$commit) {
    foreach ($file in $files) {
        $info = if ($commit) { (git show "${commit}:$file") -join "`n" } else { Get-Content $file -Raw }
        foreach ($attribute in $attributes) {
            [pscustomobject]@{
                Name    = "$($file.Split('/')[1]) $attribute"
                Version = [regex]::Match($info, "$attribute\(""([^""]+)""\)").Groups[1].Value
            }
        }
    }
}

# Four-part form, so that 1.3 and 1.3.0.0 compare equal
function Get-Normalized([string]$version) {
    $parsed = [version]$version
    (@($parsed.Major, $parsed.Minor, $parsed.Build, $parsed.Revision) | ForEach-Object { [math]::Max($_, 0) }) -join '.'
}

# The versions one step up from $old: each part in turn raised by one, with every part to its right reset to 0
function Get-NextVersions([string]$old) {
    $parts = (Get-Normalized $old).Split('.') | ForEach-Object { [int]$_ }
    foreach ($i in 0..3) {
        $next = @(0, 0, 0, 0)
        for ($j = 0; $j -lt $i; $j++) { $next[$j] = $parts[$j] }
        $next[$i] = $parts[$i] + 1
        $next -join '.'
    }
}

# A release tag is "v" and the version, without the fourth part while it is 0 (the zip is named the same way)
function Get-TagName([string]$version) {
    $parsed = [version](Get-Normalized $version)
    'v' + $(if ($parsed.Revision -eq 0) { $parsed.ToString(3) } else { $parsed.ToString(4) })
}

$changed = $false
$current = @(Get-Versions $null)
$unparsable = @($current | Where-Object { -not ($_.Version -as [version]) })
if ($unparsable) {
    $problems.Add("Unreadable version: " + (($unparsable | ForEach-Object { "$($_.Name) = '$($_.Version)'" }) -join ', '))
} elseif (@($current.Version | Sort-Object -Unique).Count -ne 1) {
    $problems.Add("Both programs must have one version: " + (($current | ForEach-Object { "$($_.Name) = $($_.Version)" }) -join ', '))
}

if ($Base -and $Base -notmatch '^0+$' -and -not $problems.Count) {
    git cat-file -e "${Base}^{commit}" 2>$null
    if ($LASTEXITCODE -ne 0) {
        Write-Host "::warning::Base commit $Base is not available; the version increment was not checked"
    } else {
        $previous = @(Get-Versions $Base)
        $wrong = for ($i = 0; $i -lt $current.Count; $i++) {
            $old = $previous[$i].Version
            $new = $current[$i].Version
            if (-not ($old -as [version]) -or (Get-Normalized $old) -eq (Get-Normalized $new)) { continue }
            if ((Get-NextVersions $old) -notcontains (Get-Normalized $new)) {
                [pscustomobject]@{ Name = $current[$i].Name; Old = $old; New = $new }
            }
        }
        foreach ($group in @($wrong | Group-Object Old, New)) {
            $first = $group.Group[0]
            $which = if ($group.Count -eq $current.Count) { '' } else { ' (' + ($group.Group.Name -join ', ') + ')' }
            $problems.Add("Version $($first.Old) -> $($first.New)$which is not a single-step increment; expected one of: " + ((Get-NextVersions $first.Old) -join ', '))
        }
        if (-not $problems.Count -and ($previous[0].Version -as [version]) -and (Get-Normalized $previous[0].Version) -ne (Get-Normalized $current[0].Version)) {
            Write-Host "Version $($previous[0].Version) -> $($current[0].Version)"
            $changed = $true
        }
    }
}

if ($Tag -and -not $problems.Count) {
    $expected = Get-TagName $current[0].Version
    if ($Tag -cnotmatch '^v\d+\.\d+\.\d+(\.\d+)?$') {
        $problems.Add("Tag $Tag is not a version tag like v1.2.3; for version $($current[0].Version) it must be $expected")
    } elseif ($Tag -cne $expected) {
        $problems.Add("Tag $Tag does not match the programs' version $($current[0].Version); expected tag $expected")
    }
}

if ($problems.Count) {
    foreach ($problem in $problems) { Write-Host "::error::$problem" }
    exit 1
}
Write-Host "Versions OK: $($current[0].Version)"
if ($env:GITHUB_OUTPUT) {
    "tag=$(Get-TagName $current[0].Version)", "changed=$($changed.ToString().ToLower())" | Out-File $env:GITHUB_OUTPUT -Append -Encoding utf8
}
exit 0 # Otherwise the exit code of the last git command would decide the step's result
