# Simplified Certificate Installer for ChromaHub MSIX Package
# Just run this script as administrator to install the certificate

# Set the certificate path to the current directory
$CertificatePath = ".\ChromaHub_1.2.27.0_x64_Debug.cer"
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

# Check if certificate file exists
if (-not (Test-Path $CertificatePath)) {
    Write-Host "Certificate file not found at path: $CertificatePath" -ForegroundColor Red
    
    # Look for certificate files in current directory
    $certFiles = Get-ChildItem -Path . -Filter *.cer
    if ($certFiles.Count -gt 0) {
        Write-Host "Found the following certificate files in current directory:" -ForegroundColor Yellow
        foreach ($file in $certFiles) {
            Write-Host "  - $($file.Name)" -ForegroundColor White
        }
        
        # Use the first certificate found
        $CertificatePath = $certFiles[0].FullName
        Write-Host "Using: $CertificatePath" -ForegroundColor Green
    } else {
        Write-Host "No certificate files found in current directory." -ForegroundColor Red
        Write-Host "Please place the certificate file in the same folder as this script." -ForegroundColor Yellow
        
        # Pause so the user can see the error
        Write-Host ""
        Write-Host "Press any key to exit..." -ForegroundColor Cyan
        $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
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