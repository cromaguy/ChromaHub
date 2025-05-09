# Certificate Installer for MSIX Package
# This script installs a certificate for MSIX package installation

param (
    [Parameter(Mandatory=$false)]
    [string]$CertificatePath = ".\ChromaHub_1.2.27.0_x64_Debug.cer",
    
    [Parameter(Mandatory=$false)]
    [string]$AppName = "ChromaHub"
)

# Function to check if script is running as administrator
function Test-Admin {
    $currentUser = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
    return $currentUser.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
}

# Check for admin rights
if (-not (Test-Admin)) {
    Write-Host "This script requires administrator privileges to install certificates." -ForegroundColor Red
    Write-Host "Please run this script as an administrator." -ForegroundColor Red
    
    # Attempt to restart with elevated privileges
    $scriptPath = $MyInvocation.MyCommand.Path
    Start-Process powershell.exe -ArgumentList "-NoProfile -ExecutionPolicy Bypass -File `"$scriptPath`"" -Verb RunAs
    exit
}

# Display banner
Write-Host "================================================" -ForegroundColor Cyan
Write-Host "  Certificate Installer for $AppName" -ForegroundColor Cyan
Write-Host "================================================" -ForegroundColor Cyan
Write-Host ""

# Check if certificate file exists
if (-not (Test-Path $CertificatePath)) {
    Write-Host "Certificate file not found at path: $CertificatePath" -ForegroundColor Red
    Write-Host "Please place the certificate file in the specified location or provide the correct path." -ForegroundColor Yellow
    
    # Ask user if they want to specify a different path
    $userResponse = Read-Host "Would you like to specify a different certificate path? (Y/N)"
    if ($userResponse -eq "Y" -or $userResponse -eq "y") {
        $CertificatePath = Read-Host "Please enter the full path to the certificate file"
        if (-not (Test-Path $CertificatePath)) {
            Write-Host "Certificate file still not found. Exiting installation." -ForegroundColor Red
            exit 1
        }
    } else {
        Write-Host "Exiting installation." -ForegroundColor Red
        exit 1
    }
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
    exit 1
}

# Pause so the user can see the result
Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Cyan
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")