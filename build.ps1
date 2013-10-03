# http://docs.myget.org/docs/reference/build-services-build.bat-examples

param(

    # http://semver.org/
    [ValidatePattern("^([0-9]+)\.([0-9]+)\.([0-9]+)(?:-([0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?(?:\+[0-9A-Za-z-]+)?$")]
    [string]$packageVersion = $null,

    [string]$config = "Release",

    [string[]]$targetFrameworks = @("v4.0", "v4.5", "v4.5.1"),

    [ValidateSet("clean", "rebuild", "build")]
    [string]$target = "rebuild",

    [ValidateSet("quiet", "minimal", "normal", "detailed", "diagnostic")]
    [string]$verbosity = "minimal"

)

# Diagnostic 

function Write-Diagnostic {
    param([string]$message)

    Write-Host
    Write-Host $message -ForegroundColor Green
    Write-Host
}

function Die([string]$message, [object[]]$output) {
	if ($output) {
		Write-Output $output
		$message += ". See output above."
	}
	Write-Error $message
	exit 1
}

# Build

function Build-Clean {
	param(
	    [string]$root = $(throw "-Root is required."),
        [string]$folders = "bin,obj"
    )

    Write-Diagnostic "Build: Clean"

    Get-ChildItem $root -Include $folders -Recurse | ForEach-Object {
       Remove-Item $_.fullname -Force -Recurse 
    }

}

function Build-Bootstrap {
    param(
        [string]$solutionFile = $(throw "-solutionFile is required."),
        [string]$nugetExe = $(throw "-nugetExe is required.")
    )

    Write-Diagnostic "Build: Bootstrap"

    $solutionFolder = [System.IO.Path]::GetDirectoryName($solutionFile)

    . $nugetExe config -Set Verbosity=quiet
	. $nugetExe restore $solutionFile -NonInteractive

    Get-ChildItem $solutionFolder -filter packages.config -recurse | 
        Where-Object { -not ($_.PSIsContainer) } | 
        ForEach-Object {

        . $nugetExe restore $_.FullName -NonInteractive -SolutionDirectory $solutionFolder

    }

}

function Build-Nupkg {
    param(
        [string]$root = $(throw "-root is required."),
        [string]$project = $(throw "-project is required."),
        [string]$nugetExe = $(throw "-nugetExe is required."),
        [string]$outputFolder = $(throw "-outputFolder is required."),
        [string]$config = $(throw "-config is required."),
        [string]$version = $(throw "-version is required.")
    )

    $nuspecFilename = [System.IO.Path]::GetFullPath($project) -ireplace ".csproj$", ".nuspec"

    if(-not (Test-Path $nuspecFilename)) {
        Die("Could not find nuspec: $nuspecFilename")
    }

    . $nugetExe pack $nuspecFilename -OutputDirectory $outputFolder -Symbols -NonInteractive `
        -Properties "Configuration=$config;Bin=$outputFolder" -Version $version

    if($LASTEXITCODE -ne 0) {
        Die("Build failed: $projectName")
    }

    # MyGet support
    if((Test-Path env:nuget) -and (Test-Path env:PackageVersion)) {

        $mygetBuildFolder = Join-Path $root "Build"

        if(-not (Test-Path $mygetBuildFolder)) {
            [System.IO.Directory]::CreateDirectory($mygetBuildFolder)
        }

        Get-ChildItem $outputFolder -filter *.nupkg | 
        Where-Object { -not ($_.PSIsContainer) } | 
        ForEach-Object {
            $fullpath = $_.FullName
            $filename = $_.Name

            cp $fullpath $mygetBuildFolder\$filename
        }

    }

}

function Build-Project {
    param(
        [string]$project = $(throw "-project is required."),
        [string]$outputFolder = $(throw "-outputFolder is required."),
        [string]$nugetExe = $(throw "-nugetExe is required."),
        [string]$config = $(throw "-config is required."),
        [string]$target = $(throw "-target is required."),
        [string[]]$targetFrameworks = $(throw "-targetFrameworks is required.")
    )

    $projectPath = [System.IO.Path]::GetFullPath($project)
    $projectName = [System.IO.Path]::GetFileName($projectPath) -ireplace ".csproj$", ""


    if(-not (Test-Path $outputFolder)) {
        [System.IO.Directory]::CreateDirectory($outputFolder)
    }

    if(-not (Test-Path $projectPath)) {
        Die("Could not find csproj: $projectPath")
    }

    $targetFrameworks | foreach-object {
        
        $targetFramework = $_

        Write-Diagnostic "Build: $projectName ($Config - $targetFramework)"

        & "$(Get-Content env:windir)\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" `
            $projectPath `
            /t:$target `
            /p:Configuration=$config `
            /p:OutputPath=$outputFolder\$config\$targetFramework `
            /p:TargetFrameworkVersion=$targetFramework `
            /m `
            /v:M `
            /fl `
            /flp:LogFile=$outputFolder\msbuild.log `
            /nr:false

        if($LASTEXITCODE -ne 0) {
            Die("Build failed: $projectName ($Config - $targetFramework)")
        }

    }

}

function Build-Solution {
    param(
        [string[]]$projects = $(throw "-projects is required."),
        [string]$root = $(throw "-root is required."),
        [string]$solutionFile = $(throw "-solutionFile is required."),
        [string]$outputFolder = $(throw "-outputFolder is required."),
        [string[]]$targetFrameworks = $(throw "-targetFrameworks is required."),
        [string]$version = $(throw "-version is required"),
        [string]$config = $(throw "-config is required."),
        [string]$target = $(throw "-target is required.")
    )

    if(-not (Test-Path $solutionFile)) {
        Die("Could not find solution: $solutionFile")
    }

    $outputFolder = Join-Path $outputFolder "$version"
    $solutionFolder = [System.IO.Path]::GetDirectoryName($solutionFile)
    $nugetExe = if(Test-Path Env:nuget) { Get-Item -path env:nuget } else { Join-Path $solutionFolder ".nuget\nuget.exe" }

    Build-Clean -root $solutionFolder
    Build-Bootstrap -solutionFile $solutionFile -nugetExe $nugetExe

    $projects | ForEach-Object {

        $project = $_

        Build-Project -root $solutionFolder -project $project -outputFolder $outputFolder `
            -nugetExe $nugetExe -target $target -config $config `
            -targetFrameworks $targetFrameworks -version $version

        Build-Nupkg -root $root -project $project -nugetExe $nugetExe -outputFolder $outputFolder `
            -config $config -version $version 

    }

}

function TestRunner-Nunit {
    param(
        [string[]]$projects = $(throw "-projects is required."),
        [string]$outputFolder = $(throw "-outputFolder is required."),
        [string]$config = $(throw "-config is required."),
        [string]$target = $(throw "-target is required.")
    )

    $outputFolder = Join-Path $outputFolder "$version"
    $nunitExe = "tools\nunit\nunit-console.exe"

    Write-Diagnostic ("Running nunit test suite: {0} project(s)" -f $projects.Count)

    Die("TODO")
}

# Bootstrap
$rootFolder = Split-Path -parent $script:MyInvocation.MyCommand.Definition
$outputFolder = Join-Path $rootFolder "bin"
$testsFolder = Join-Path $outputFolder "tests"

$config = $config.substring(0, 1).toupper() + $config.substring(1)
$version = $config.trim()

# Myget
$currentVersion = if(Test-Path env:PackageVersion) { Get-Item -path env:PackageVersion } else { $packageVersion }

if($currentVersion -eq "") {
    Die("Package version cannot be empty")
}

# Build AsposeCloud
Build-Solution -solutionFile $rootFolder\AsposeCloud.SDK-for-.NET-master\AsposeCloud.SDK.sln `
    -projects @( `
        "$rootFolder\AsposeCloud.SDK-for-.NET-master\AsposeCloud.SDK\AsposeCloud.csproj"
    ) `
    -root $rootFolder `
    -version $currentVersion `
    -outputFolder $outputFolder `
    -config $config `
    -target $target `
    -targetFrameworks $targetFrameworks
