# Direct PS2EXE Conversion Script
# This script directly converts the simplified installer to EXE without requiring a separate compile step
# Run this script to create the final EXE immediately

# Script content to be converted to EXE
$scriptContent = @'
# Certificate Installer for ChromaHub MSIX Package
# This script installs the certificate needed for the MSIX package

# Set the certificate path - will automatically find the certificate in the same directory
$CertificatePath = $null
$AppName = "ChromaHub"

# Function to check if script is running as administrator
function Test-Admin {
    $currentUser = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
    return $currentUser.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
}

# Check for admin rights
if (-not (Test-Admin)) {
    Write-Host "This script requires administrator privileges to install certificates." -ForegroundColor Red
    Write-Host "Please run this script as an administrator." -ForegroundColor Red
    
    # Pause so the user can see the message
    Write-Host ""
    Write-Host "Press any key to exit..." -ForegroundColor Cyan
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
    exit
}

# Display banner
Write-Host "================================================" -ForegroundColor Cyan
Write-Host "  Certificate Installer for $AppName" -ForegroundColor Cyan
Write-Host "================================================" -ForegroundColor Cyan
Write-Host ""

# Get the directory the executable is running from
$scriptDir = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

# Look for certificate files in current directory
$certFiles = Get-ChildItem -Path $scriptDir -Filter *.cer
if ($certFiles.Count -gt 0) {
    # Use the first certificate found if specific one not found
    $CertificatePath = $certFiles[0].FullName
    Write-Host "Found certificate: $($certFiles[0].Name)" -ForegroundColor Green
} else {
    Write-Host "No certificate files found in current directory." -ForegroundColor Red
    Write-Host "Please place the certificate file in the same folder as this installer." -ForegroundColor Yellow
    
    # Pause so the user can see the error
    Write-Host ""
    Write-Host "Press any key to exit..." -ForegroundColor Cyan
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
    exit 1
}

try {
    # Import the certificate
    Write-Host "Installing certificate from: $CertificatePath" -ForegroundColor Yellow
    
    # Get certificate details
    $cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($CertificatePath)
    Write-Host "Certificate details:" -ForegroundColor Cyan
    Write-Host "  Subject: $($cert.Subject)" -ForegroundColor White
    Write-Host "  Issuer: $($cert.Issuer)" -ForegroundColor White
    Write-Host "  Valid from: $($cert.NotBefore) to $($cert.NotAfter)" -ForegroundColor White
    Write-Host "  Thumbprint: $($cert.Thumbprint)" -ForegroundColor White
    Write-Host ""
    
    # Import to Trusted Root store (requires admin)
    Write-Host "Adding certificate to Trusted Root Certificate Authorities store..." -ForegroundColor Yellow
    $store = New-Object System.Security.Cryptography.X509Certificates.X509Store("Root", "LocalMachine")
    $store.Open("ReadWrite")
    $store.Add($cert)
    $store.Close()
    
    # Also import to Trusted People store for extra compatibility
    Write-Host "Adding certificate to Trusted People store..." -ForegroundColor Yellow
    $store = New-Object System.Security.Cryptography.X509Certificates.X509Store("TrustedPeople", "LocalMachine")
    $store.Open("ReadWrite")
    $store.Add($cert)
    $store.Close()
    
    Write-Host ""
    Write-Host "Certificate successfully installed!" -ForegroundColor Green
    Write-Host "You can now install the MSIX package for $AppName." -ForegroundColor Green
    
} catch {
    Write-Host "Error installing certificate: $_" -ForegroundColor Red
    
    # Pause so the user can see the error
    Write-Host ""
    Write-Host "Press any key to exit..." -ForegroundColor Cyan
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
    exit 1
}

# Pause so the user can see the result
Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Cyan
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
'@

# Save the script content to a temporary file
$tempScriptPath = Join-Path -Path $env:TEMP -ChildPath "ChromaHubCertInstaller.ps1"
Set-Content -Path $tempScriptPath -Value $scriptContent -Force

# Check if PS2EXE module is installed, if not install it
if (-not (Get-Module -ListAvailable -Name PS2EXE)) {
    Write-Host "Installing PS2EXE module..." -ForegroundColor Yellow
    Install-Module -Name PS2EXE -Force -Scope CurrentUser
}

# Import the module
Import-Module PS2EXE

# Set output path for the EXE
$outputPath = ".\ChromaHub_Certificate_Installer.exe"

# Convert PowerShell script to EXE
Write-Host "Creating certificate installer executable..." -ForegroundColor Cyan
Invoke-ps2exe -InputFile $tempScriptPath -OutputFile $outputPath -NoConsole:$false -NoOutput:$false -NoError:$false -RequireAdmin -IconFile:$null -Title "ChromaHub Certificate Installer" -Company "ChromaHub" -Product "ChromaHub Certificate Installer" -Version "1.0.0" -Copyright "Copyright © $(Get-Date -Format yyyy)"

# Check if the EXE was created successfully
if (Test-Path $outputPath) {
    Write-Host "EXE created successfully at: $outputPath" -ForegroundColor Green
    Write-Host "`nHow to use: " -ForegroundColor Cyan
    Write-Host "1. Place the EXE in the same folder as your .cer certificate file" -ForegroundColor White
    Write-Host "2. Run the EXE as administrator" -ForegroundColor White
    Write-Host "3. The certificate will be automatically installed" -ForegroundColor White
    Write-Host "4. You can then install your MSIX package" -ForegroundColor White
} else {
    Write-Host "Failed to create EXE" -ForegroundColor Red
}

# Clean up temp file
Remove-Item -Path $tempScriptPath -Force -ErrorAction SilentlyContinue

# Pause so the user can see the result
Write-Host "`nPress any key to exit..." -ForegroundColor Cyan
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")