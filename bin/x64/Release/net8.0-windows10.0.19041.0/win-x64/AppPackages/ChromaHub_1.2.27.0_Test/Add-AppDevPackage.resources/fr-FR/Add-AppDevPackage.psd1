# Localized	12/03/2020 06:20 PM (GMT)	303:4.80.0411 	Add-AppDevPackage.psd1
# Culture = "en-US"
ConvertFrom-StringData @'
###PSLOC
PromptYesString=O&ui
PromptNoString=&Non
BundleFound=Lot trouvé : {0}
PackageFound=Package trouvé : {0}
EncryptedBundleFound=Lot chiffré trouvé : {0}
EncryptedPackageFound=Package chiffré trouvé : {0}
CertificateFound=Certificat trouvé : {0}
DependenciesFound=Package(s) de dépendance trouvé(s) :
GettingDeveloperLicense=Acquisition de la licence de développeur...
InstallingCertificate=Installation du certificat...
InstallingPackage=\nInstallation de l'application…
AcquireLicenseSuccessful=Une licence de développeur a été correctement acquise.
InstallCertificateSuccessful=Le certificat a été correctement installé.
Success=\nOpération réussie : votre application a été correctement installée.
WarningInstallCert=\nVous êtes sur le point d'installer un certificat numérique dans le magasin de certificats Personnes autorisées de votre ordinateur. Cette opération comporte un grave risque de sécurité et elle ne doit être exécutée que si l'émetteur de ce certificat numérique est fiable.\n\nLorsque vous avez fini d'utiliser cette application, vous devez supprimer manuellement le certificat numérique associé. Des instructions se rapportant à cette procédure sont disponibles à cette adresse : http://go.microsoft.com/fwlink/?LinkId=243053\n\nVoulez-vous vraiment continuer ?\n\n
ElevateActions=\nAvant d'installer cette application, vous devez exécuter les tâches suivantes :
ElevateActionDevLicense=\t- Acquérir une licence de développeur
ElevateActionCertificate=\t- Installer le certificat de signature
ElevateActionsContinue=Des informations d'identification d'administrateur sont nécessaires pour continuer. Acceptez l'invite du contrôle de compte d'utilisateur et entrez votre mot de passe d'administrateur si nécessaire.
ErrorForceElevate=Vous devez fournir des informations d'identification d'administrateur pour continuer. Exécutez ce script sans le paramètre -Force ou dans une fenêtre PowerShell avec des privilèges élevés.
ErrorForceDeveloperLicense=L'acquisition d'une licence de développeur requiert l'intervention de l'utilisateur. Réexécutez le script sans le paramètre -Force.
ErrorLaunchAdminFailed=Erreur : impossible de démarrer un nouveau processus en tant qu'administrateur.
ErrorNoScriptPath=Erreur : vous devez lancer ce script à partir d'un fichier.
ErrorNoPackageFound=Erreur : aucun package ou lot trouvé dans le répertoire de scripts. Vérifiez que le package ou lot que vous voulez installer se trouve dans le même répertoire que ce script.
ErrorManyPackagesFound=Erreur : plusieurs packages ou lots trouvés dans le répertoire de scripts. Vérifiez que seul le package ou lot que vous voulez installer se trouve dans le même répertoire que ce script.
ErrorPackageUnsigned=Erreur : le package ou lot n'est pas signé numériquement ou sa signature est endommagée.
ErrorNoCertificateFound=Erreur : aucun certificat trouvé dans le répertoire de scripts. Vérifiez que le certificat utilisé pour signer le package ou lot que vous installez se trouve dans le même répertoire que ce script.
ErrorManyCertificatesFound=Erreur : plusieurs certificats trouvés dans le répertoire de scripts. Vérifiez que seul le certificat utilisé pour signer le package ou le lot que vous installez se trouve dans le même répertoire que ce script.
ErrorBadCertificate=Erreur : le fichier "{0}" n'est pas un certificat numérique valide. CertUtil retourné avec le code d'erreur {1}.
ErrorExpiredCertificate=Erreur : le certificat de développeur "{0}" a expiré. Cela peut être dû à un mauvais réglage de la date et de l'heure de l'horloge système. Si les paramètres système sont corrects, contactez le propriétaire de l'application afin qu'il recrée le package ou le lot avec un certificat valide.
ErrorCertificateMismatch=Erreur : le certificat ne correspond pas à celui utilisé pour signer le package ou le lot.
ErrorCertIsCA=Erreur : le certificat ne peut pas être une autorité de certification.
ErrorBannedKeyUsage=Erreur : le certificat ne peut pas avoir l'utilisation de clé suivante : {0}. L'utilisation de la clé ne doit pas être spécifiée ou elle doit être égale à "DigitalSignature".
ErrorBannedEKU=Erreur : le certificat ne peut pas avoir l'utilisation améliorée de la clé suivante : {0}. Seules les utilisations améliorées de la clé (EKU) Signature du code et Signature permanente sont autorisées.
ErrorNoBasicConstraints=Erreur : le certificat ne contient pas les extensions de contraintes de base.
ErrorNoCodeSigningEku=Erreur : le certificat ne contient pas l'utilisation améliorée de la clé pour Signature du code.
ErrorInstallCertificateCancelled=Erreur : l'installation du certificat a été annulée.
ErrorCertUtilInstallFailed=Erreur : impossible d'installer le certificat. CertUtil retourné avec le code d'erreur {0}.
ErrorGetDeveloperLicenseFailed=Erreur : impossible d'acquérir une licence de développeur. Pour plus d'informations, consultez http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorInstallCertificateFailed=Erreur : impossible d'installer le certificat. État : {0}. Pour plus d'informations, consultez http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorAddPackageFailed=Erreur : impossible d'installer l'application.
ErrorAddPackageFailedWithCert=Erreur : impossible d'installer l'application. Pour garantir la sécurité, pensez à désinstaller le certificat de signature jusqu'à ce que vous puissiez installer l'application. Des instructions se rapportant à cette procédure sont disponibles à cette adresse : \nhttp://go.microsoft.com/fwlink/?LinkId=243053
'@

# SIG # Begin signature block
# MIIoVQYJKoZIhvcNAQcCoIIoRjCCKEICAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCAFO4b12o9Q47XJ
# hD1wgOoRkZLqDncJWHLhb3O3PI/qnqCCDYUwggYDMIID66ADAgECAhMzAAAEA73V
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
# cVZOSEXAQsmbdlsKgEhr/Xmfwb1tbWrJUnMTDXpQzTGCGiYwghoiAgEBMIGVMH4x
# CzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRt
# b25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01p
# Y3Jvc29mdCBDb2RlIFNpZ25pbmcgUENBIDIwMTECEzMAAAQDvdWVXQ87GK0AAAAA
# BAMwDQYJYIZIAWUDBAIBBQCgga4wGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQw
# HAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUwLwYJKoZIhvcNAQkEMSIEIKJR
# fa5gvhNr5FczOTYQdnywJMAxQeIjIEVA8hufTogsMEIGCisGAQQBgjcCAQwxNDAy
# oBSAEgBNAGkAYwByAG8AcwBvAGYAdKEagBhodHRwOi8vd3d3Lm1pY3Jvc29mdC5j
# b20wDQYJKoZIhvcNAQEBBQAEggEAJTTx/FJlCXTYjGMwcw2u75oxkIho4iq0/MS3
# lGt1rIqVh+fKkblNvfmtUCkD9YrdZf1xhyHAO9VTIFvRw4/hw+AhBkoKdHhD+biK
# ZYaLmEmlyvjWsJlFJFXm/T6azFjImJtuEKW3OGeh8pF0u+3TTMvhumKvllNThpsq
# liS2kDyMQtPbFghO/HPOV+lV8oWB9XnY8xLgm4o2TzpV7nzqrRuKykY1NQzWAGzO
# BSL5GhUbxz7C8/82gxZaMR6hhhpGkr1OmxuENjCrPKZLVw1ik43xU1+TWvUzPI4z
# iVuvsq/ZtP72rkJy72yArs/0vakCw0TG9R9QZ7KJj4jyGNRco6GCF7AwghesBgor
# BgEEAYI3AwMBMYIXnDCCF5gGCSqGSIb3DQEHAqCCF4kwgheFAgEDMQ8wDQYJYIZI
# AWUDBAIBBQAwggFaBgsqhkiG9w0BCRABBKCCAUkEggFFMIIBQQIBAQYKKwYBBAGE
# WQoDATAxMA0GCWCGSAFlAwQCAQUABCBdk7T3DZtSTVT8hXL6OaZekUSaHfCkJ+5e
# goIIs0j5rgIGZ7YzV6OVGBMyMDI1MDQwMTA2MzIwNi42NDJaMASAAgH0oIHZpIHW
# MIHTMQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
# UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMS0wKwYDVQQL
# EyRNaWNyb3NvZnQgSXJlbGFuZCBPcGVyYXRpb25zIExpbWl0ZWQxJzAlBgNVBAsT
# Hm5TaGllbGQgVFNTIEVTTjozNjA1LTA1RTAtRDk0NzElMCMGA1UEAxMcTWljcm9z
# b2Z0IFRpbWUtU3RhbXAgU2VydmljZaCCEf4wggcoMIIFEKADAgECAhMzAAAB91gg
# dQTK+8L0AAEAAAH3MA0GCSqGSIb3DQEBCwUAMHwxCzAJBgNVBAYTAlVTMRMwEQYD
# VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24xJjAkBgNVBAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1w
# IFBDQSAyMDEwMB4XDTI0MDcyNTE4MzEwNloXDTI1MTAyMjE4MzEwNlowgdMxCzAJ
# BgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25k
# MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xLTArBgNVBAsTJE1pY3Jv
# c29mdCBJcmVsYW5kIE9wZXJhdGlvbnMgTGltaXRlZDEnMCUGA1UECxMeblNoaWVs
# ZCBUU1MgRVNOOjM2MDUtMDVFMC1EOTQ3MSUwIwYDVQQDExxNaWNyb3NvZnQgVGlt
# ZS1TdGFtcCBTZXJ2aWNlMIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEA
# 0OdHTBNom6/uXKaEKP9rPITkT6QxF11tjzB0Nk1byDpPrFTHha3hxwSdTcr8Y0a3
# k6EQlwqy6ROz42e0R5eDW+dCoQapipDIFUOYp3oNuqwX/xepATEkY17MyXFx6rQW
# 2NcWUJW3Qo2AuJ0HOtblSpItQZPGmHnGqkt/DB45Fwxk6VoSvxNcQKhKETkuzrt8
# U6DRccQm1FdhmPKgDzgcfDPM5o+GnzbiMu6y069A4EHmLMmkecSkVvBmcZ8VnzFH
# TDkGLdpnDV5FXjVObAgbSM0cnqYSGfRp7VGHBRqyoscvR4bcQ+CV9pDjbJ6S5rZn
# 1uA8hRhj09Hs33HRevt4oWAVYGItgEsG+BrCYbpgWMDEIVnAgPZEiPAaI8wBGemE
# 4feEkuz7TAwgkRBcUzLgQ4uvPqRD1A+Jkt26+pDqWYSn0MA8j0zacQk9q/AvciPX
# D9It2ez+mqEzgFRRsJGLtcf9HksvK8Jsd6I5zFShlqi5bpzf1Y4NOiNOh5QwW1pI
# vA5irlal7qFhkAeeeZqmop8+uNxZXxFCQG3R3s5pXW89FiCh9rmXrVqOCwgcXFIJ
# QAQkllKsI+UJqGq9rmRABJz5lHKTFYmFwcM52KWWjNx3z6odwz2h+sxaxewToe9G
# qtDx3/aU+yqNRcB8w0tSXUf+ylN4uk5xHEpLpx+ZNNsCAwEAAaOCAUkwggFFMB0G
# A1UdDgQWBBTfRqQzP3m9PZWuLf1p8/meFfkmmDAfBgNVHSMEGDAWgBSfpxVdAF5i
# XYP05dJlpxtTNRnpcjBfBgNVHR8EWDBWMFSgUqBQhk5odHRwOi8vd3d3Lm1pY3Jv
# c29mdC5jb20vcGtpb3BzL2NybC9NaWNyb3NvZnQlMjBUaW1lLVN0YW1wJTIwUENB
# JTIwMjAxMCgxKS5jcmwwbAYIKwYBBQUHAQEEYDBeMFwGCCsGAQUFBzAChlBodHRw
# Oi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpb3BzL2NlcnRzL01pY3Jvc29mdCUyMFRp
# bWUtU3RhbXAlMjBQQ0ElMjAyMDEwKDEpLmNydDAMBgNVHRMBAf8EAjAAMBYGA1Ud
# JQEB/wQMMAoGCCsGAQUFBwMIMA4GA1UdDwEB/wQEAwIHgDANBgkqhkiG9w0BAQsF
# AAOCAgEAN0ajafILeL6SQIMIMAXM1Qd6xaoci2mOrpR8vKWyyTsL3b83A7XGLiAb
# QxTrqnXvVWWeNst5YQD8saO+UTgOLJdTdfUADhLXoK+RlwjfndimIJT9MH9tUYXL
# zJXKhZM09ouPwNsrn8YOLIpdAi5TPyN8Cl11OGZSlP9r8JnvomW00AoJ4Pl9rlg0
# G5lcQknAXqHa9nQdWp1ZxXqNd+0JsKmlR8tcANX33ClM9NnaClJExLQHiKeHUUWt
# qyLMl65TW6wRM7XlF7Y+PTnC8duNWn4uLng+ON/Z39GO6qBj7IEZxoq4o3avEh9b
# a43UU6TgzVZaBm8VaA0wSwUe/pqpTOYFWN62XL3gl/JC2pzfIPxP66XfRLIxafjB
# VXm8KVDn2cML9IvRK02s941Y5+RR4gSAOhLiQQ6A03VNRup+spMa0k+XTPAi+2aM
# H5xa1Zjb/K8u9f9M05U0/bUMJXJDP++ysWpJbVRDiHG7szaca+r3HiUPjQJyQl2N
# iOcYTGV/DcLrLCBK2zG503FGb04N5Kf10XgAwFaXlod5B9eKh95PnXKx2LNBgLwG
# 85anlhhGxxBQ5mFsJGkBn0PZPtAzZyfr96qxzpp2pH9DJJcjKCDrMmZziXazpa5V
# VN36CO1kDU4ABkSYTXOM8RmJXuQm7mUF3bWmj+hjAJb4pz6hT5UwggdxMIIFWaAD
# AgECAhMzAAAAFcXna54Cm0mZAAAAAAAVMA0GCSqGSIb3DQEBCwUAMIGIMQswCQYD
# VQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEe
# MBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMTIwMAYDVQQDEylNaWNyb3Nv
# ZnQgUm9vdCBDZXJ0aWZpY2F0ZSBBdXRob3JpdHkgMjAxMDAeFw0yMTA5MzAxODIy
# MjVaFw0zMDA5MzAxODMyMjVaMHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNo
# aW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29y
# cG9yYXRpb24xJjAkBgNVBAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEw
# MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEA5OGmTOe0ciELeaLL1yR5
# vQ7VgtP97pwHB9KpbE51yMo1V/YBf2xK4OK9uT4XYDP/XE/HZveVU3Fa4n5KWv64
# NmeFRiMMtY0Tz3cywBAY6GB9alKDRLemjkZrBxTzxXb1hlDcwUTIcVxRMTegCjhu
# je3XD9gmU3w5YQJ6xKr9cmmvHaus9ja+NSZk2pg7uhp7M62AW36MEBydUv626GIl
# 3GoPz130/o5Tz9bshVZN7928jaTjkY+yOSxRnOlwaQ3KNi1wjjHINSi947SHJMPg
# yY9+tVSP3PoFVZhtaDuaRr3tpK56KTesy+uDRedGbsoy1cCGMFxPLOJiss254o2I
# 5JasAUq7vnGpF1tnYN74kpEeHT39IM9zfUGaRnXNxF803RKJ1v2lIH1+/NmeRd+2
# ci/bfV+AutuqfjbsNkz2K26oElHovwUDo9Fzpk03dJQcNIIP8BDyt0cY7afomXw/
# TNuvXsLz1dhzPUNOwTM5TI4CvEJoLhDqhFFG4tG9ahhaYQFzymeiXtcodgLiMxhy
# 16cg8ML6EgrXY28MyTZki1ugpoMhXV8wdJGUlNi5UPkLiWHzNgY1GIRH29wb0f2y
# 1BzFa/ZcUlFdEtsluq9QBXpsxREdcu+N+VLEhReTwDwV2xo3xwgVGD94q0W29R6H
# XtqPnhZyacaue7e3PmriLq0CAwEAAaOCAd0wggHZMBIGCSsGAQQBgjcVAQQFAgMB
# AAEwIwYJKwYBBAGCNxUCBBYEFCqnUv5kxJq+gpE8RjUpzxD/LwTuMB0GA1UdDgQW
# BBSfpxVdAF5iXYP05dJlpxtTNRnpcjBcBgNVHSAEVTBTMFEGDCsGAQQBgjdMg30B
# ATBBMD8GCCsGAQUFBwIBFjNodHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpb3Bz
# L0RvY3MvUmVwb3NpdG9yeS5odG0wEwYDVR0lBAwwCgYIKwYBBQUHAwgwGQYJKwYB
# BAGCNxQCBAweCgBTAHUAYgBDAEEwCwYDVR0PBAQDAgGGMA8GA1UdEwEB/wQFMAMB
# Af8wHwYDVR0jBBgwFoAU1fZWy4/oolxiaNE9lJBb186aGMQwVgYDVR0fBE8wTTBL
# oEmgR4ZFaHR0cDovL2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVjdHMv
# TWljUm9vQ2VyQXV0XzIwMTAtMDYtMjMuY3JsMFoGCCsGAQUFBwEBBE4wTDBKBggr
# BgEFBQcwAoY+aHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNS
# b29DZXJBdXRfMjAxMC0wNi0yMy5jcnQwDQYJKoZIhvcNAQELBQADggIBAJ1Vffwq
# reEsH2cBMSRb4Z5yS/ypb+pcFLY+TkdkeLEGk5c9MTO1OdfCcTY/2mRsfNB1OW27
# DzHkwo/7bNGhlBgi7ulmZzpTTd2YurYeeNg2LpypglYAA7AFvonoaeC6Ce5732pv
# vinLbtg/SHUB2RjebYIM9W0jVOR4U3UkV7ndn/OOPcbzaN9l9qRWqveVtihVJ9Ak
# vUCgvxm2EhIRXT0n4ECWOKz3+SmJw7wXsFSFQrP8DJ6LGYnn8AtqgcKBGUIZUnWK
# NsIdw2FzLixre24/LAl4FOmRsqlb30mjdAy87JGA0j3mSj5mO0+7hvoyGtmW9I/2
# kQH2zsZ0/fZMcm8Qq3UwxTSwethQ/gpY3UA8x1RtnWN0SCyxTkctwRQEcb9k+SS+
# c23Kjgm9swFXSVRk2XPXfx5bRAGOWhmRaw2fpCjcZxkoJLo4S5pu+yFUa2pFEUep
# 8beuyOiJXk+d0tBMdrVXVAmxaQFEfnyhYWxz/gq77EFmPWn9y8FBSX5+k77L+Dvk
# txW/tM4+pTFRhLy/AsGConsXHRWJjXD+57XQKBqJC4822rpM+Zv/Cuk0+CQ1Zyvg
# DbjmjJnW4SLq8CdCPSWU5nR0W2rRnj7tfqAxM328y+l7vzhwRNGQ8cirOoo6CGJ/
# 2XBjU02N7oJtpQUQwXEGahC0HVUzWLOhcGbyoYIDWTCCAkECAQEwggEBoYHZpIHW
# MIHTMQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
# UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMS0wKwYDVQQL
# EyRNaWNyb3NvZnQgSXJlbGFuZCBPcGVyYXRpb25zIExpbWl0ZWQxJzAlBgNVBAsT
# Hm5TaGllbGQgVFNTIEVTTjozNjA1LTA1RTAtRDk0NzElMCMGA1UEAxMcTWljcm9z
# b2Z0IFRpbWUtU3RhbXAgU2VydmljZaIjCgEBMAcGBSsOAwIaAxUAb28KDG/xXbNB
# jmM7/nqw3bgrEOaggYMwgYCkfjB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2Fz
# aGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENv
# cnBvcmF0aW9uMSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAx
# MDANBgkqhkiG9w0BAQsFAAIFAOuVapswIhgPMjAyNTAzMzExOTI1MTVaGA8yMDI1
# MDQwMTE5MjUxNVowdzA9BgorBgEEAYRZCgQBMS8wLTAKAgUA65VqmwIBADAKAgEA
# AgILQgIB/zAHAgEAAgISTzAKAgUA65a8GwIBADA2BgorBgEEAYRZCgQCMSgwJjAM
# BgorBgEEAYRZCgMCoAowCAIBAAIDB6EgoQowCAIBAAIDAYagMA0GCSqGSIb3DQEB
# CwUAA4IBAQBwo4jx8W7Ajwl0sAl8R80zLuhWxfEwC6l1K+uypQK7i71lEUwRcvVv
# 39Qp81yWZAjJWQNYa7dks7ecLaJTvPx0m1rkditT7bW0nyPTwLAeztvV9kr/EZ1t
# Z79Y6WyZXOt6LFMal+R4R/PHbd9I6EXuynMR0wnetj5pz57sL9K2akz2rNqJY1m2
# 1HVBge8c5IA+MH4CdhNKoJUUwWrhylV/nwgdxmj0jQdwYxvmUycM8FveSAcdTunp
# JhbYt6S5GRU3yh12Z8sLpcc9LOO/u4hu5xnqg/nXTGDFyttcV0K4axcxNm9t0Jfx
# THud3c591uK4E93/TsXyJzk5/j1qGdXxMYIEDTCCBAkCAQEwgZMwfDELMAkGA1UE
# BhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAc
# BgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0
# IFRpbWUtU3RhbXAgUENBIDIwMTACEzMAAAH3WCB1BMr7wvQAAQAAAfcwDQYJYIZI
# AWUDBAIBBQCgggFKMBoGCSqGSIb3DQEJAzENBgsqhkiG9w0BCRABBDAvBgkqhkiG
# 9w0BCQQxIgQgiUtaL8aExBT+9om03snhyscIAENBQhzWpruGoWbo39cwgfoGCyqG
# SIb3DQEJEAIvMYHqMIHnMIHkMIG9BCAh2pjaa3ca0ecYuhu60uYHP/IKnPbedbVQ
# J5SoIH5Z4jCBmDCBgKR+MHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5n
# dG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9y
# YXRpb24xJjAkBgNVBAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEwAhMz
# AAAB91ggdQTK+8L0AAEAAAH3MCIEIG0KNVVdWMd46VmV4tonUJqfPGB+Wizpz2f7
# q/VYOvpCMA0GCSqGSIb3DQEBCwUABIICAHy5kn7fvPmJGqWsB9GmgHLAr4KGPufd
# nQGcnrYeRt4bEJb1Bfv3hH4Va7BtlselRws7TByzQFSMwxDUlCdzZKtrcxHgZs96
# tQoi8AjrD/8AH4c/c6z8RM+afMfEQwgIqbtbv3qfbXo/zvVWn4RdvQZ+LF8DGI8H
# on0jX3+puoAzOLp9Lq+eFrUUAyHLjR68dHXcMfUdPJIgRxKQCrRU9Rn6JxQHthiO
# NHzv1e2qCI9sjaaav+LWkrxz2bbDGevijvx1vmzPusC4PJCJOoiWuBPmcTZ+9VYk
# kWUukI4xfgrs63YN+pW499AEkD3II2Nx6b4e8YPeEwD+QAlF1TJLISy01gKuqlQm
# 65qD5DscLxHjOY+2mJbZbCcNd3/BOA8549el6O8R6/+nsG2mXBSqTW4wltXgziIz
# opkMhUvN+MP628J/O4c3DdgWXiWrNe/DVNLdEyU2c8sVeJ0dRjmEu5JxbGD2tNJK
# dAojHrCu9PqlgtoApxoZDBlBjgz231Fr88q/FwuHu/cN6/hVO2hqX0yspNYBzbF9
# qdT4jftp9lc4DzUswNI/91DWMHoe0f0T8ZqZoXt/JktOSmadaAIMlD4x24HfZU0k
# AT+yGsiVdGYcCWsZ3dWNccbdVZlboHz8vZMbZ1dVLc6ubf8L1lSDNm0UbF2LijO4
# peFeIR4LqcX1
# SIG # End signature block
