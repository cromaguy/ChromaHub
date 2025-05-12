# Compile PowerShell Script to EXE
# This script converts the certificate installer script to an EXE
# Save this as Compile-Installer.ps1

# Set the path to the PowerShell script to convert
$scriptPath = ".\Install-Certificate.ps1"

# Check if PS2EXE module is installed, if not install it
if (-not (Get-Module -ListAvailable -Name PS2EXE)) {
    Write-Host "Installing PS2EXE module..." -ForegroundColor Yellow
    Install-Module -Name PS2EXE -Force -Scope CurrentUser
}

# Import the module
Import-Module PS2EXE

# Set output path for the EXE
$outputPath = ".\CertificateInstaller.exe"

# Convert PowerShell script to EXE
Write-Host "Converting PowerShell script to EXE..." -ForegroundColor Cyan
Invoke-ps2exe -InputFile $scriptPath -OutputFile $outputPath -NoConsole:$false -NoOutput:$false -NoError:$false -RequireAdmin -IconFile:$null -Title "Certificate Installer" -CompanyName "Chroma Hub" -Product "WinUI App Installer" -Version "1.2.0" -Copyright "Anjishnu Nandi"

# Check if the EXE was created successfully
if (Test-Path $outputPath) {
    Write-Host "EXE created successfully at: $outputPath" -ForegroundColor Green
} else {
    Write-Host "Failed to create EXE" -ForegroundColor Red
}

# Pause so the user can see the result
Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Cyan
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")