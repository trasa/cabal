
makecert -n "CN=trasa2k8_CA" -r -sv trasa2k8_CA.pvk trasa2k8_CA.cer 

(the password is 'password')
(below, the CN=localhost MUST be the hostname in the URL that you're going to serve these things up with.)

makecert -sk SignedByCA -iv trasa2k8_CA.pvk -n "CN=localhost" -ic trasa2k8_CA.cer -sr LocalMachine -ss My -sky exchange -pe

(this registers the certificates created by the first execution of makecert into the certificate store of the local machine.)
