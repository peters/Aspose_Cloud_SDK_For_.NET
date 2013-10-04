param(
    [string[]]$platforms = @(
        "AnyCpu"
    ),
    [string[]]$targetFrameworks = @(
        "v2.0", 
        "v3.5", 
        "v4.0",
        "v4.5", 
        "v4.5.1"
    ),
    [string]$packageVersion = $null,
    [string]$config = "Release",
    [string]$target = "Rebuild",
    [string]$verbosity = "Minimal",

    [bool]$clean = $true
)

# Initialization
$rootFolder = Split-Path -parent $script:MyInvocation.MyCommand.Definition
. $rootFolder\myget.include.ps1

# Build folders
$outputFolder = Join-Path $rootFolder "bin\AsposeCloud.SDK"

# Myget
$packageVersion = MyGet-Package-Version $packageVersion
$nugetExe = MyGet-NugetExe-Path

# Build solution
$nuspec = Join-Path $rootFolder "AsposeCloud.SDK-for-.NET-master\AsposeCloud.SDK\AsposeCloud.nuspec"

# Bootstrap
if($clean) { MyGet-Build-Clean $rootFolder }

$platforms | ForEach-Object {
    $platform = $_

    # Build solution
    MyGet-Build-Solution -sln $rootFolder\AsposeCloud.SDK-for-.NET-master\AsposeCloud.SDK.sln `
        -rootFolder $rootFolder `
        -outputFolder $outputFolder `
        -platforms $platforms `
        -targetFrameworks $targetFrameworks `
        -verbosity $verbosity `
        -clean $clean `
        -config $config `
        -target $target `
        -version $packageVersion `
        -nuspec $nuspec

}