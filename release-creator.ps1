# Set version
$version = "0.0.0.2"

# Enable error handling
$ErrorActionPreference = "Stop"

# Function to write log messages
function Write-Log {
    param($Message)
    Write-Host "[$(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')] $Message"
}

try {
    Write-Log "Starting release creation process for version $version"

    # Clean and build
    Write-Log "Cleaning solution..."
    dotnet clean
    if ($LASTEXITCODE -ne 0) {
        throw "Clean failed with exit code $LASTEXITCODE"
    }

    Write-Log "Building and publishing solution..."
    dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
    if ($LASTEXITCODE -ne 0) {
        throw "Publish failed with exit code $LASTEXITCODE"
    }

    # Create release folder
    $releaseFolder = "release-$version"
    Write-Log "Creating release folder: $releaseFolder"
    if (Test-Path $releaseFolder) {
        Write-Log "Removing existing release folder..."
        Remove-Item -Path $releaseFolder -Recurse -Force
    }
    New-Item -ItemType Directory -Force -Path $releaseFolder | Out-Null

    # Find the publish directory dynamically
    Write-Log "Searching for publish directory..."
    $publishPath = Get-ChildItem -Path "bin\Release" -Recurse -Directory |
        Where-Object { $_.Name -eq "publish" } |
        Select-Object -First 1 -ExpandProperty FullName

    if (-not $publishPath) {
        Write-Log "Available directories in bin\Release:"
        Get-ChildItem -Path "bin\Release" -Recurse -Directory | ForEach-Object {
            Write-Log "  $($_.FullName)"
        }
        throw "Could not find publish directory. Please check the build output."
    }

    Write-Log "Found publish directory at: $publishPath"

    # Copy files
    Write-Log "Copying published files..."
    Copy-Item "$publishPath\*" $releaseFolder -Recurse -Force

    # Verify files were copied
    if (-not (Get-ChildItem $releaseFolder)) {
        throw "No files were copied to the release folder"
    }

    # Create ZIP
    $zipName = "TheMysteriousTower-$version.zip"
    Write-Log "Creating ZIP archive: $zipName"
    if (Test-Path $zipName) {
        Write-Log "Removing existing ZIP file..."
        Remove-Item -Path $zipName -Force
    }
    Compress-Archive -Path "$releaseFolder\*" -DestinationPath $zipName -Force

    Write-Log "Release creation completed successfully!"
}
catch {
    Write-Log "ERROR: $_"
    exit 1
}