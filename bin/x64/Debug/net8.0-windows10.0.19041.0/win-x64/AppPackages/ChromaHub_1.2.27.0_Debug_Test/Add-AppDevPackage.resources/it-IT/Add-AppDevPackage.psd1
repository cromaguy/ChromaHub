# Localized	12/03/2020 06:20 PM (GMT)	303:4.80.0411 	Add-AppDevPackage.psd1
# Culture = "en-US"
ConvertFrom-StringData @'
###PSLOC
PromptYesString=&Sì
PromptNoString=&No
BundleFound=Pacchetto trovato: {0}
PackageFound=Pacchetto trovato: {0}
EncryptedBundleFound=Bundle crittografato trovato: {0}
EncryptedPackageFound=Pacchetto crittografato trovato: {0}
CertificateFound=Certificato trovato: {0}
DependenciesFound=Pacchetti di dipendenza trovati:
GettingDeveloperLicense=Acquisizione della licenza per sviluppatori in corso...
InstallingCertificate=Installazione del certificato in corso...
InstallingPackage=\nInstallazione dell'applicazione in corso...
AcquireLicenseSuccessful=Acquisizione di una licenza per sviluppatori completata.
InstallCertificateSuccessful=Installazione del certificato completata.
Success=\nOperazione completata: l'applicazione è stata installata.
WarningInstallCert=\nVerrà installato un certificato digitale nell'archivio certificati Persone attendibili del computer. Questa operazione costituisce un grave rischio per la sicurezza e deve essere eseguita solo se si considera attendibile l'origine del certificato digitale.\n\nDopo aver terminato di usare l'app, è consigliabile rimuovere manualmente il certificato digitale associato. Le istruzioni necessarie sono disponibili all'indirizzo: http://go.microsoft.com/fwlink/?LinkId=243053\n\nContinuare?\n\n
ElevateActions=\nPrima di installare questa applicazione, è necessario eseguire quanto segue:
ElevateActionDevLicense=\t- Acquisire una licenza per sviluppatori
ElevateActionCertificate=\t- Installare il certificato di firma
ElevateActionsContinue=Per continuare sono necessarie credenziali di amministratore. Accettare l'avviso di Controllo dell'account utente e specificare, se richiesta, la password di amministratore.
ErrorForceElevate=Per continuare è necessario specificare credenziali di amministratore. Eseguire questo script senza il parametro -Force oppure da una finestra di PowerShell con privilegi elevati.
ErrorForceDeveloperLicense=L'acquisizione di una licenza per sviluppatori richiede l'intervento dell'utente. Eseguire di nuovo lo script senza il parametro -Force.
ErrorLaunchAdminFailed=Errore: impossibile avviare un nuovo processo come amministratore.
ErrorNoScriptPath=Errore: è necessario avviare questo script da un file.
ErrorNoPackageFound=Errore: nessun pacchetto trovato nella directory dello script. Accertarsi che nella directory dello script sia presente il pacchetto da installare.
ErrorManyPackagesFound=Errore: più pacchetti trovati nella directory dello script. Accertarsi che nella directory dello script sia presente solo il pacchetto da installare.
ErrorPackageUnsigned=Errore: il pacchetto non è provvisto di firma digitale oppure la firma è danneggiata.
ErrorNoCertificateFound=Errore: nessun certificato trovato nella directory dello script. Accertarsi che nella directory dello script sia presente il certificato utilizzato per firmare il pacchetto da installare.
ErrorManyCertificatesFound=Errore: più certificati trovati nella directory dello script. Accertarsi che nella directory dello script sia presente solo il certificato utilizzato per firmare il pacchetto da installare.
ErrorBadCertificate=Errore: il file "{0}" non è un certificato digitale valido. CertUtil terminato con codice di errore {1}.
ErrorExpiredCertificate=Errore: il certificato "{0}" dello sviluppatore è scaduto. È possibile che l'orologio di sistema non sia impostato sulla data e sull'ora corrette. Se le impostazioni di sistema sono corrette, contattare il proprietario dell'applicazione per ricreare un pacchetto con un certificato valido.
ErrorCertificateMismatch=Errore: il certificato non corrisponde a quello utilizzato per firmare il pacchetto.
ErrorCertIsCA=Errore: il certificato non può essere un'autorità di certificazione.
ErrorBannedKeyUsage=Errore: il certificato non può avere il seguente utilizzo chiavi: {0}. L'utilizzo chiavi deve essere non specificato o corrispondere a "DigitalSignature".
ErrorBannedEKU=Errore: il certificato non può avere il seguente utilizzo chiavi avanzato: {0}. Sono consentiti solo utilizzi chiavi avanzati (EKU) Firma codice e Firma definitiva.
ErrorNoBasicConstraints=Errore: il certificato non dispone dell'estensione Limitazioni di base.
ErrorNoCodeSigningEku=Errore: il certificato non dispone dell'utilizzo chiavi avanzato per Firma codice.
ErrorInstallCertificateCancelled=Errore: installazione del certificato annullata.
ErrorCertUtilInstallFailed=Errore: impossibile installare il certificato. CertUtil terminato con codice di errore {0}.
ErrorGetDeveloperLicenseFailed=Errore: impossibile acquisire una licenza per sviluppatori. Per ulteriori informazioni, vedere http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorInstallCertificateFailed=Errore: impossibile installare il certificato. Stato: {0}. Per ulteriori informazioni, vedere http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorAddPackageFailed=Errore: impossibile installare l'applicazione.
ErrorAddPackageFailedWithCert=Errore: impossibile installare l'applicazione. Per garantire la sicurezza, provare a disinstallare il certificato di firma finché non risulta possibile installare l'applicazione. Le istruzioni necessarie sono disponibili qui:\nhttp://go.microsoft.com/fwlink/?LinkId=243053
'@

# SIG # Begin signature block
# MIIoOQYJKoZIhvcNAQcCoIIoKjCCKCYCAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCDKsJ3QNm0qtYLQ
# 3ayOahNQH+oSXwVuqZ62HBVPqyCWRqCCDYUwggYDMIID66ADAgECAhMzAAAEA73V
# lV0POxitAAAAAAQDMA0GCSqGSIb3DQEBCwUAMH4xCzAJBgNVBAYTAlVTMRMwEQYD
# VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01pY3Jvc29mdCBDb2RlIFNpZ25p
# bmcgUENBIDIwMTEwHhcNMjQwOTEyMjAxMTEzWhcNMjUwOTExMjAxMTEzWjB0MQsw
# CQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9u
# ZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMR4wHAYDVQQDExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB
# AQCfdGddwIOnbRYUyg03O3iz19XXZPmuhEmW/5uyEN+8mgxl+HJGeLGBR8YButGV
# LVK38RxcVcPYyFGQXcKcxgih4w4y4zJi3GvawLYHlsNExQwz+v0jgY/aejBS2EJY
# oUhLVE+UzRihV8ooxoftsmKLb2xb7BoFS6UAo3Zz4afnOdqI7FGoi7g4vx/0MIdi
# kwTn5N56TdIv3mwfkZCFmrsKpN0zR8HD8WYsvH3xKkG7u/xdqmhPPqMmnI2jOFw/
# /n2aL8W7i1Pasja8PnRXH/QaVH0M1nanL+LI9TsMb/enWfXOW65Gne5cqMN9Uofv
# ENtdwwEmJ3bZrcI9u4LZAkujAgMBAAGjggGCMIIBfjAfBgNVHSUEGDAWBgorBgEE
# AYI3TAgBBggrBgEFBQcDAzAdBgNVHQ4EFgQU6m4qAkpz4641iK2irF8eWsSBcBkw
# VAYDVR0RBE0wS6RJMEcxLTArBgNVBAsTJE1pY3Jvc29mdCBJcmVsYW5kIE9wZXJh
# dGlvbnMgTGltaXRlZDEWMBQGA1UEBRMNMjMwMDEyKzUwMjkyNjAfBgNVHSMEGDAW
# gBRIbmTlUAXTgqoXNzcitW2oynUClTBUBgNVHR8ETTBLMEmgR6BFhkNodHRwOi8v
# d3d3Lm1pY3Jvc29mdC5jb20vcGtpb3BzL2NybC9NaWNDb2RTaWdQQ0EyMDExXzIw
# MTEtMDctMDguY3JsMGEGCCsGAQUFBwEBBFUwUzBRBggrBgEFBQcwAoZFaHR0cDov
# L3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9jZXJ0cy9NaWNDb2RTaWdQQ0EyMDEx
# XzIwMTEtMDctMDguY3J0MAwGA1UdEwEB/wQCMAAwDQYJKoZIhvcNAQELBQADggIB
# AFFo/6E4LX51IqFuoKvUsi80QytGI5ASQ9zsPpBa0z78hutiJd6w154JkcIx/f7r
# EBK4NhD4DIFNfRiVdI7EacEs7OAS6QHF7Nt+eFRNOTtgHb9PExRy4EI/jnMwzQJV
# NokTxu2WgHr/fBsWs6G9AcIgvHjWNN3qRSrhsgEdqHc0bRDUf8UILAdEZOMBvKLC
# rmf+kJPEvPldgK7hFO/L9kmcVe67BnKejDKO73Sa56AJOhM7CkeATrJFxO9GLXos
# oKvrwBvynxAg18W+pagTAkJefzneuWSmniTurPCUE2JnvW7DalvONDOtG01sIVAB
# +ahO2wcUPa2Zm9AiDVBWTMz9XUoKMcvngi2oqbsDLhbK+pYrRUgRpNt0y1sxZsXO
# raGRF8lM2cWvtEkV5UL+TQM1ppv5unDHkW8JS+QnfPbB8dZVRyRmMQ4aY/tx5x5+
# sX6semJ//FbiclSMxSI+zINu1jYerdUwuCi+P6p7SmQmClhDM+6Q+btE2FtpsU0W
# +r6RdYFf/P+nK6j2otl9Nvr3tWLu+WXmz8MGM+18ynJ+lYbSmFWcAj7SYziAfT0s
# IwlQRFkyC71tsIZUhBHtxPliGUu362lIO0Lpe0DOrg8lspnEWOkHnCT5JEnWCbzu
# iVt8RX1IV07uIveNZuOBWLVCzWJjEGa+HhaEtavjy6i7MIIHejCCBWKgAwIBAgIK
# YQ6Q0gAAAAAAAzANBgkqhkiG9w0BAQsFADCBiDELMAkGA1UEBhMCVVMxEzARBgNV
# BAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jv
# c29mdCBDb3Jwb3JhdGlvbjEyMDAGA1UEAxMpTWljcm9zb2Z0IFJvb3QgQ2VydGlm
# aWNhdGUgQXV0aG9yaXR5IDIwMTEwHhcNMTEwNzA4MjA1OTA5WhcNMjYwNzA4MjEw
# OTA5WjB+MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UE
# BxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSgwJgYD
# VQQDEx9NaWNyb3NvZnQgQ29kZSBTaWduaW5nIFBDQSAyMDExMIICIjANBgkqhkiG
# 9w0BAQEFAAOCAg8AMIICCgKCAgEAq/D6chAcLq3YbqqCEE00uvK2WCGfQhsqa+la
# UKq4BjgaBEm6f8MMHt03a8YS2AvwOMKZBrDIOdUBFDFC04kNeWSHfpRgJGyvnkmc
# 6Whe0t+bU7IKLMOv2akrrnoJr9eWWcpgGgXpZnboMlImEi/nqwhQz7NEt13YxC4D
# dato88tt8zpcoRb0RrrgOGSsbmQ1eKagYw8t00CT+OPeBw3VXHmlSSnnDb6gE3e+
# lD3v++MrWhAfTVYoonpy4BI6t0le2O3tQ5GD2Xuye4Yb2T6xjF3oiU+EGvKhL1nk
# kDstrjNYxbc+/jLTswM9sbKvkjh+0p2ALPVOVpEhNSXDOW5kf1O6nA+tGSOEy/S6
# A4aN91/w0FK/jJSHvMAhdCVfGCi2zCcoOCWYOUo2z3yxkq4cI6epZuxhH2rhKEmd
# X4jiJV3TIUs+UsS1Vz8kA/DRelsv1SPjcF0PUUZ3s/gA4bysAoJf28AVs70b1FVL
# 5zmhD+kjSbwYuER8ReTBw3J64HLnJN+/RpnF78IcV9uDjexNSTCnq47f7Fufr/zd
# sGbiwZeBe+3W7UvnSSmnEyimp31ngOaKYnhfsi+E11ecXL93KCjx7W3DKI8sj0A3
# T8HhhUSJxAlMxdSlQy90lfdu+HggWCwTXWCVmj5PM4TasIgX3p5O9JawvEagbJjS
# 4NaIjAsCAwEAAaOCAe0wggHpMBAGCSsGAQQBgjcVAQQDAgEAMB0GA1UdDgQWBBRI
# bmTlUAXTgqoXNzcitW2oynUClTAZBgkrBgEEAYI3FAIEDB4KAFMAdQBiAEMAQTAL
# BgNVHQ8EBAMCAYYwDwYDVR0TAQH/BAUwAwEB/zAfBgNVHSMEGDAWgBRyLToCMZBD
# uRQFTuHqp8cx0SOJNDBaBgNVHR8EUzBRME+gTaBLhklodHRwOi8vY3JsLm1pY3Jv
# c29mdC5jb20vcGtpL2NybC9wcm9kdWN0cy9NaWNSb29DZXJBdXQyMDExXzIwMTFf
# MDNfMjIuY3JsMF4GCCsGAQUFBwEBBFIwUDBOBggrBgEFBQcwAoZCaHR0cDovL3d3
# dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNSb29DZXJBdXQyMDExXzIwMTFf
# MDNfMjIuY3J0MIGfBgNVHSAEgZcwgZQwgZEGCSsGAQQBgjcuAzCBgzA/BggrBgEF
# BQcCARYzaHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9kb2NzL3ByaW1h
# cnljcHMuaHRtMEAGCCsGAQUFBwICMDQeMiAdAEwAZQBnAGEAbABfAHAAbwBsAGkA
# YwB5AF8AcwB0AGEAdABlAG0AZQBuAHQALiAdMA0GCSqGSIb3DQEBCwUAA4ICAQBn
# 8oalmOBUeRou09h0ZyKbC5YR4WOSmUKWfdJ5DJDBZV8uLD74w3LRbYP+vj/oCso7
# v0epo/Np22O/IjWll11lhJB9i0ZQVdgMknzSGksc8zxCi1LQsP1r4z4HLimb5j0b
# pdS1HXeUOeLpZMlEPXh6I/MTfaaQdION9MsmAkYqwooQu6SpBQyb7Wj6aC6VoCo/
# KmtYSWMfCWluWpiW5IP0wI/zRive/DvQvTXvbiWu5a8n7dDd8w6vmSiXmE0OPQvy
# CInWH8MyGOLwxS3OW560STkKxgrCxq2u5bLZ2xWIUUVYODJxJxp/sfQn+N4sOiBp
# mLJZiWhub6e3dMNABQamASooPoI/E01mC8CzTfXhj38cbxV9Rad25UAqZaPDXVJi
# hsMdYzaXht/a8/jyFqGaJ+HNpZfQ7l1jQeNbB5yHPgZ3BtEGsXUfFL5hYbXw3MYb
# BL7fQccOKO7eZS/sl/ahXJbYANahRr1Z85elCUtIEJmAH9AAKcWxm6U/RXceNcbS
# oqKfenoi+kiVH6v7RyOA9Z74v2u3S5fi63V4GuzqN5l5GEv/1rMjaHXmr/r8i+sL
# gOppO6/8MO0ETI7f33VtY5E90Z1WTk+/gFcioXgRMiF670EKsT/7qMykXcGhiJtX
# cVZOSEXAQsmbdlsKgEhr/Xmfwb1tbWrJUnMTDXpQzTGCGgowghoGAgEBMIGVMH4x
# CzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRt
# b25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01p
# Y3Jvc29mdCBDb2RlIFNpZ25pbmcgUENBIDIwMTECEzMAAAQDvdWVXQ87GK0AAAAA
# BAMwDQYJYIZIAWUDBAIBBQCgga4wGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQw
# HAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUwLwYJKoZIhvcNAQkEMSIEIFGv
# l7PaSy0M+z1Uju5Qyl+p1l6pWnVurJvx21Pnrz1wMEIGCisGAQQBgjcCAQwxNDAy
# oBSAEgBNAGkAYwByAG8AcwBvAGYAdKEagBhodHRwOi8vd3d3Lm1pY3Jvc29mdC5j
# b20wDQYJKoZIhvcNAQEBBQAEggEAkFQ8AxUY8JGS78Rn2z5frds2ROL6R+hY0iqF
# kh0E7CjO6x9oqJLAKDf8imr9CsjXzqQer/rX2A6sBJjpbLmxexsKpdWKKET+9959
# YTUR3UdfNMgbroKfSpKRmBYsQxCf/DqcHOUc2+i2+zUGXTCasmYJJ5kcquAu7PNY
# PorD5jFWK3cmd+cBfYXeCMA62JtjvNoi8AFbqtnG2Rg+LHsOLJgR8Lyr0twQ9fiS
# CaqzEC/Kga3dFPIkmtLynCAtJZqJri3zw0/hYwPKzWMWgAe5+33o4JKenQPzhiu/
# E3BY5hsO40nrGbgYx0Iu43oa32qVFKJe/zx09eL9wJJiKTz9waGCF5QwgheQBgor
# BgEEAYI3AwMBMYIXgDCCF3wGCSqGSIb3DQEHAqCCF20wghdpAgEDMQ8wDQYJYIZI
# AWUDBAIBBQAwggFSBgsqhkiG9w0BCRABBKCCAUEEggE9MIIBOQIBAQYKKwYBBAGE
# WQoDATAxMA0GCWCGSAFlAwQCAQUABCBTlQDCZxAN7A5BjVgw6R1Q07vNM53CCVOD
# dhRFAfaCOAIGZ98GbvIHGBMyMDI1MDQwMTA2MzIwMy43OTlaMASAAgH0oIHRpIHO
# MIHLMQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
# UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSUwIwYDVQQL
# ExxNaWNyb3NvZnQgQW1lcmljYSBPcGVyYXRpb25zMScwJQYDVQQLEx5uU2hpZWxk
# IFRTUyBFU046N0YwMC0wNUUwLUQ5NDcxJTAjBgNVBAMTHE1pY3Jvc29mdCBUaW1l
# LVN0YW1wIFNlcnZpY2WgghHqMIIHIDCCBQigAwIBAgITMwAAAgbXvFE4mCPsLAAB
# AAACBjANBgkqhkiG9w0BAQsFADB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2Fz
# aGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENv
# cnBvcmF0aW9uMSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAx
# MDAeFw0yNTAxMzAxOTQyNTBaFw0yNjA0MjIxOTQyNTBaMIHLMQswCQYDVQQGEwJV
# UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UE
# ChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSUwIwYDVQQLExxNaWNyb3NvZnQgQW1l
# cmljYSBPcGVyYXRpb25zMScwJQYDVQQLEx5uU2hpZWxkIFRTUyBFU046N0YwMC0w
# NUUwLUQ5NDcxJTAjBgNVBAMTHE1pY3Jvc29mdCBUaW1lLVN0YW1wIFNlcnZpY2Uw
# ggIiMA0GCSqGSIb3DQEBAQUAA4ICDwAwggIKAoICAQDpRIWbIM3Rlr397cjHaYx8
# 5l7I+ZVWGMCBCM911BpU6+IGWCqksqgqefZFEjKzNVDYC9YcgITAz276NGgvECm4
# ZfNv/FPwcaSDz7xbDbsOoxbwQoHUNRro+x5ubZhT6WJeU97F06+vDjAw/Yt1vWOg
# RTqmP/dNr9oqIbE5oCLYdH3wI/noYmsJVc7966n+B7UAGAWU2se3Lz+xdxnNsNX4
# CR6zIMVJTSezP/2STNcxJTu9k2sl7/vzOhxJhCQ38rdaEoqhGHrXrmVkEhSv+S00
# DMJc1OIXxqfbwPjMqEVp7K3kmczCkbum1BOIJ2wuDAbKuJelpteNZj/S58NSQw6k
# hfuJAluqHK3igkS/Oux49qTP+rU+PQeNuD+GtrCopFucRmanQvxISGNoxnBq3UeD
# Tqphm6aI7GMHtFD6DOjJlllH1gVWXPTyivf+4tN8TmO6yIgB4uP00bH9jn/dyyxS
# jxPQ2nGvZtgtqnvq3h3TRjRnkc+e1XB1uatDa1zUcS7r3iodTpyATe2hgkVX3m4D
# hRzI6A4SJ6fbJM9isLH8AGKcymisKzYupAeFSTJ10JEFa6MjHQYYohoCF77R0CCw
# MNjvE4XfLHu+qKPY8GQfsZdigQ9clUAiydFmVt61hytoxZP7LmXbzjD0VecyzZoL
# 4Equ1XszBsulAr5Ld2KwcwIDAQABo4IBSTCCAUUwHQYDVR0OBBYEFO0wsLKdDGpT
# 97cx3Iymyo/SBm4SMB8GA1UdIwQYMBaAFJ+nFV0AXmJdg/Tl0mWnG1M1GelyMF8G
# A1UdHwRYMFYwVKBSoFCGTmh0dHA6Ly93d3cubWljcm9zb2Z0LmNvbS9wa2lvcHMv
# Y3JsL01pY3Jvc29mdCUyMFRpbWUtU3RhbXAlMjBQQ0ElMjAyMDEwKDEpLmNybDBs
# BggrBgEFBQcBAQRgMF4wXAYIKwYBBQUHMAKGUGh0dHA6Ly93d3cubWljcm9zb2Z0
# LmNvbS9wa2lvcHMvY2VydHMvTWljcm9zb2Z0JTIwVGltZS1TdGFtcCUyMFBDQSUy
# MDIwMTAoMSkuY3J0MAwGA1UdEwEB/wQCMAAwFgYDVR0lAQH/BAwwCgYIKwYBBQUH
# AwgwDgYDVR0PAQH/BAQDAgeAMA0GCSqGSIb3DQEBCwUAA4ICAQB23GZOfe9ThTUv
# D29i4t6lDpxJhpVRMme+UbyZhBFCZhoGTtjDdphAArU2Q61WYg3YVcl2RdJm5PUb
# Z2bA77zk+qtLxC+3dNxVsTcdtxPDSSWgwBHxTj6pCmoDNXolAYsWpvHQFCHDqEfA
# iBxX1dmaXbiTP1d0XffvgR6dshUcqaH/mFfjDZAxLU1s6HcVgCvBQJlJ7xEG5jFK
# dtqapKWcbUHwTVqXQGbIlHVClNJ3yqW6Z3UJH/CFcYiLV/e68urTmGtiZxGSYb4S
# BSPArTrTYeHOlQIj/7loVWmfWX2y4AGV/D+MzyZMyvFw4VyL0Vgq96EzQKyteiVe
# BaVEjxQKo3AcPULRF4Uzz98P2tCM5XbFZ3Qoj9PLg3rgFXr0oJEhfh2tqUrhTJd1
# 3+i4/fek9zWicoshlwXgFu002ZWBVzASEFuqED48qyulZ/2jGJBcta+Fdk2loP2K
# 3oSj4PQQe1MzzVZO52AXO42MHlhm3SHo3/RhQ+I1A0Ny+9uAehkQH6LrxkrVNvZG
# 4f0PAKMbqUcXG7xznKJ0x0HYr5ayWGbHKZRcObU+/34ZpL9NrXOedVDXmSd2ylKS
# l/vvi1QwNJqXJl/+gJkQEetqmHAUFQkFtemi8MUXQG2w/RDHXXwWAjE+qIDZLQ/k
# 4z2Z216tWaR6RDKHGkweCoDtQtzkHTCCB3EwggVZoAMCAQICEzMAAAAVxedrngKb
# SZkAAAAAABUwDQYJKoZIhvcNAQELBQAwgYgxCzAJBgNVBAYTAlVTMRMwEQYDVQQI
# EwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3Nv
# ZnQgQ29ycG9yYXRpb24xMjAwBgNVBAMTKU1pY3Jvc29mdCBSb290IENlcnRpZmlj
# YXRlIEF1dGhvcml0eSAyMDEwMB4XDTIxMDkzMDE4MjIyNVoXDTMwMDkzMDE4MzIy
# NVowfDELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcT
# B1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEmMCQGA1UE
# AxMdTWljcm9zb2Z0IFRpbWUtU3RhbXAgUENBIDIwMTAwggIiMA0GCSqGSIb3DQEB
# AQUAA4ICDwAwggIKAoICAQDk4aZM57RyIQt5osvXJHm9DtWC0/3unAcH0qlsTnXI
# yjVX9gF/bErg4r25PhdgM/9cT8dm95VTcVrifkpa/rg2Z4VGIwy1jRPPdzLAEBjo
# YH1qUoNEt6aORmsHFPPFdvWGUNzBRMhxXFExN6AKOG6N7dcP2CZTfDlhAnrEqv1y
# aa8dq6z2Nr41JmTamDu6GnszrYBbfowQHJ1S/rboYiXcag/PXfT+jlPP1uyFVk3v
# 3byNpOORj7I5LFGc6XBpDco2LXCOMcg1KL3jtIckw+DJj361VI/c+gVVmG1oO5pG
# ve2krnopN6zL64NF50ZuyjLVwIYwXE8s4mKyzbnijYjklqwBSru+cakXW2dg3viS
# kR4dPf0gz3N9QZpGdc3EXzTdEonW/aUgfX782Z5F37ZyL9t9X4C626p+Nuw2TPYr
# bqgSUei/BQOj0XOmTTd0lBw0gg/wEPK3Rxjtp+iZfD9M269ewvPV2HM9Q07BMzlM
# jgK8QmguEOqEUUbi0b1qGFphAXPKZ6Je1yh2AuIzGHLXpyDwwvoSCtdjbwzJNmSL
# W6CmgyFdXzB0kZSU2LlQ+QuJYfM2BjUYhEfb3BvR/bLUHMVr9lxSUV0S2yW6r1AF
# emzFER1y7435UsSFF5PAPBXbGjfHCBUYP3irRbb1Hode2o+eFnJpxq57t7c+auIu
# rQIDAQABo4IB3TCCAdkwEgYJKwYBBAGCNxUBBAUCAwEAATAjBgkrBgEEAYI3FQIE
# FgQUKqdS/mTEmr6CkTxGNSnPEP8vBO4wHQYDVR0OBBYEFJ+nFV0AXmJdg/Tl0mWn
# G1M1GelyMFwGA1UdIARVMFMwUQYMKwYBBAGCN0yDfQEBMEEwPwYIKwYBBQUHAgEW
# M2h0dHA6Ly93d3cubWljcm9zb2Z0LmNvbS9wa2lvcHMvRG9jcy9SZXBvc2l0b3J5
# Lmh0bTATBgNVHSUEDDAKBggrBgEFBQcDCDAZBgkrBgEEAYI3FAIEDB4KAFMAdQBi
# AEMAQTALBgNVHQ8EBAMCAYYwDwYDVR0TAQH/BAUwAwEB/zAfBgNVHSMEGDAWgBTV
# 9lbLj+iiXGJo0T2UkFvXzpoYxDBWBgNVHR8ETzBNMEugSaBHhkVodHRwOi8vY3Js
# Lm1pY3Jvc29mdC5jb20vcGtpL2NybC9wcm9kdWN0cy9NaWNSb29DZXJBdXRfMjAx
# MC0wNi0yMy5jcmwwWgYIKwYBBQUHAQEETjBMMEoGCCsGAQUFBzAChj5odHRwOi8v
# d3d3Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL01pY1Jvb0NlckF1dF8yMDEwLTA2
# LTIzLmNydDANBgkqhkiG9w0BAQsFAAOCAgEAnVV9/Cqt4SwfZwExJFvhnnJL/Klv
# 6lwUtj5OR2R4sQaTlz0xM7U518JxNj/aZGx80HU5bbsPMeTCj/ts0aGUGCLu6WZn
# OlNN3Zi6th542DYunKmCVgADsAW+iehp4LoJ7nvfam++Kctu2D9IdQHZGN5tggz1
# bSNU5HhTdSRXud2f8449xvNo32X2pFaq95W2KFUn0CS9QKC/GbYSEhFdPSfgQJY4
# rPf5KYnDvBewVIVCs/wMnosZiefwC2qBwoEZQhlSdYo2wh3DYXMuLGt7bj8sCXgU
# 6ZGyqVvfSaN0DLzskYDSPeZKPmY7T7uG+jIa2Zb0j/aRAfbOxnT99kxybxCrdTDF
# NLB62FD+CljdQDzHVG2dY3RILLFORy3BFARxv2T5JL5zbcqOCb2zAVdJVGTZc9d/
# HltEAY5aGZFrDZ+kKNxnGSgkujhLmm77IVRrakURR6nxt67I6IleT53S0Ex2tVdU
# CbFpAUR+fKFhbHP+CrvsQWY9af3LwUFJfn6Tvsv4O+S3Fb+0zj6lMVGEvL8CwYKi
# excdFYmNcP7ntdAoGokLjzbaukz5m/8K6TT4JDVnK+ANuOaMmdbhIurwJ0I9JZTm
# dHRbatGePu1+oDEzfbzL6Xu/OHBE0ZDxyKs6ijoIYn/ZcGNTTY3ugm2lBRDBcQZq
# ELQdVTNYs6FwZvKhggNNMIICNQIBATCB+aGB0aSBzjCByzELMAkGA1UEBhMCVVMx
# EzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoT
# FU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjElMCMGA1UECxMcTWljcm9zb2Z0IEFtZXJp
# Y2EgT3BlcmF0aW9uczEnMCUGA1UECxMeblNoaWVsZCBUU1MgRVNOOjdGMDAtMDVF
# MC1EOTQ3MSUwIwYDVQQDExxNaWNyb3NvZnQgVGltZS1TdGFtcCBTZXJ2aWNloiMK
# AQEwBwYFKw4DAhoDFQAEa0f118XHM/VNdqKBs4QXxNnN96CBgzCBgKR+MHwxCzAJ
# BgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25k
# MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xJjAkBgNVBAMTHU1pY3Jv
# c29mdCBUaW1lLVN0YW1wIFBDQSAyMDEwMA0GCSqGSIb3DQEBCwUAAgUA65VhrzAi
# GA8yMDI1MDMzMTE4NDcxMVoYDzIwMjUwNDAxMTg0NzExWjB0MDoGCisGAQQBhFkK
# BAExLDAqMAoCBQDrlWGvAgEAMAcCAQACAgkrMAcCAQACAhQzMAoCBQDrlrMvAgEA
# MDYGCisGAQQBhFkKBAIxKDAmMAwGCisGAQQBhFkKAwKgCjAIAgEAAgMHoSChCjAI
# AgEAAgMBhqAwDQYJKoZIhvcNAQELBQADggEBAIh2dgUHSlAh/93TyCqlbxgaJsZn
# 6wRj2Kt/23w0VssL15KNEc3244YhO0lPP9CWKNzFEBkWkzO6h3VeJKTKIUbwB4Ap
# sbK3LXZ1ZFhOeRkChrXguD1XSpcFi4j13eVth5uIGbiiJ1ZJmsosYNJXeWJqpp1R
# 8PSJGfquGhrAS9nBjTGI8XbCPP6vda7R4kdJ/RV96f8YCN/rIG+Fwo316qOanhqG
# XOFxWcI/2LifzxqBNL9o35H0zZknPGTF0/MiI03pE2GRC0psdZ4iM0lwm+Kw0PqE
# fYA65EPPEp1NgYquHIvfeaA2q3hHf8ZAsrTSGDXDtKUwyAppRRc8+dcLxrYxggQN
# MIIECQIBATCBkzB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQ
# MA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9u
# MSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAxMAITMwAAAgbX
# vFE4mCPsLAABAAACBjANBglghkgBZQMEAgEFAKCCAUowGgYJKoZIhvcNAQkDMQ0G
# CyqGSIb3DQEJEAEEMC8GCSqGSIb3DQEJBDEiBCByqeco88Wf9wHqlapQXRa7Ur/O
# r5utHu5SDq+/qrQ7UzCB+gYLKoZIhvcNAQkQAi8xgeowgecwgeQwgb0EIODo9ZSI
# kZ6dVtKT+E/uZx2WAy7KiXM5R1JIOhNJf0vSMIGYMIGApH4wfDELMAkGA1UEBhMC
# VVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNV
# BAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0IFRp
# bWUtU3RhbXAgUENBIDIwMTACEzMAAAIG17xROJgj7CwAAQAAAgYwIgQgpXc5pzjn
# eT1Z1wiVpK5JPXnHvWCQ8sOtxJTBCiBNa9kwDQYJKoZIhvcNAQELBQAEggIAdN+B
# rnuX87FAIbOoThanBkcQMw+rXtT+arUIb6HBzp2ERndN5RCKCPKKbOI/SgDCgyLA
# IkKchKLcWUtqIxUzTsjoG2kjtKWaplZorBzOG8vFXgF4C4Jb6MkxSUvKw69Whzm+
# DxwZWuXRligpxZCFkLpcKmxM3+O8wRVQq3hbYSj26Lk70iSlefyvK6+8QU2cKITL
# eeChXOkdctFINyEsjSKOspTZkKXO2cBdZZ38dJ5OFqy/t7hGfmlVtZIXXv5UixKo
# M9nCu485dZAKSv7+Fr6b6yPs7qBrF6zC7qE9eg78hibvXu1Xcj4zhSyTlQqJN4tN
# kO/ol15Vh87AsEbaxL33yBosz2rVN8CrsoFbx3DsNNU5Lr7Sc3wZcD5eQ3icoCRa
# KGvhrWlMB5lbxyGRhTOA9Q8O/vZdRaTG+iv+UVKfGCZ9ifiN3uvcXbmGKmrpPwH5
# lLDv1R2g3T3cf159/tzV4wk1BHsMQ4HTKyREKkiZLbv9lVD4w3W1C+8nfCIxpGVr
# ew5aWYi86vojhDiKtQGCfa/8tIJ8uEcqY8EhgZPe+7CJONE7UIEhuFhdQLP9wnjJ
# F4/kAyh/l7mg+bF0m7L0lwqGo12aRL0138DrkX7ixlIOkcKf8hFvupH9u/YdZW7Y
# e37/etfO5rB9GKSmHB4brAERxpFzrwDaFpDHpkU=
# SIG # End signature block
