@echo off
:: ChromaHub Certificate Installer
:: This batch file installs the certificate required for ChromaHub MSIX package
:: Just place this file in the same folder as your .cer file and run as administrator

title ChromaHub Certificate Installer
color 0B
echo ================================================
echo   ChromaHub Certificate Installer
echo ================================================
echo.

:: Check for Admin rights
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo This script requires administrator privileges to install certificates.
    echo Please right-click on this file and select "Run as administrator".
    echo.
    pause
    exit /b 1
)

:: Look for certificate file
if exist "ChromaHub_1.2.27.0_x64_Debug.cer" (
    set CERT_PATH=ChromaHub_1.2.27.0_x64_Debug.cer
    goto :INSTALL_CERT
) else (
    echo Looking for certificate files...
    echo.
)

:: Try to find any .cer file
for %%f in (*.cer) do (
    echo Found certificate: %%f
    set CERT_PATH=%%f
    goto :INSTALL_CERT
)

echo.
echo No certificate files found in current directory.
echo Please place the certificate file (.cer) in the same folder as this script.
echo.
pause
exit /b 1

:INSTALL_CERT
echo.
echo Installing certificate from: %CERT_PATH%
echo.

:: Import certificate to Trusted Root and Trusted People stores
certutil -addstore "Root" "%CERT_PATH%"
if %errorLevel% neq 0 (
    echo Error installing certificate to Root store.
    goto :ERROR
)

certutil -addstore "TrustedPeople" "%CERT_PATH%"
if %errorLevel% neq 0 (
    echo Error installing certificate to TrustedPeople store.
    goto :ERROR
)

echo.
echo Certificate successfully installed!
echo You can now install the ChromaHub MSIX package.
echo.
pause
exit /b 0

:ERROR
echo.
echo An error occurred while installing the certificate.
echo.
pause
exit /b 1