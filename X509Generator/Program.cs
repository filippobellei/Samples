using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

var subjectName = new X500DistinguishedName("CN=localhost");
using var key = RSA.Create(2048);

var certificateRequest = new CertificateRequest(subjectName, key, HashAlgorithmName.SHA512, RSASignaturePadding.Pss);
using var certificate = certificateRequest.CreateSelfSigned(DateTime.UtcNow, DateTime.UtcNow.AddYears(1));

File.WriteAllBytes("cert.pfx", certificate.Export(X509ContentType.Pfx));
File.WriteAllText("cert.crt", certificate.ExportCertificatePem());
File.WriteAllText("cert.key", key.ExportPkcs8PrivateKeyPem());
