using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using ProductionPlanning.LicenceManager.Model;

namespace ProductionPlanning.LicenceManager.LicenceUtils
{
    public class LicenceHandler
    {
        public string GenerateLicenceKey(Licence licence)
        {
            var planeusLicence = licence.ToPlaneusLicence();
            var serializedLicence = JsonConvert.SerializeObject(planeusLicence);

            var publicKey = GetPublicKey();

            return Encrypt(publicKey, serializedLicence);
        }

        private static byte[] GetPublicKey()
        {
            var fileContent = File.ReadAllText("PubKey.pem");
            using (var publicKeyTextReader = new StringReader(fileContent))
            {
                var pemReader = new PemReader(publicKeyTextReader);
                var publicKey = (AsymmetricKeyParameter)pemReader.ReadObject();

                var publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
                var serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();

                return serializedPublicBytes;
            }
        }

        public static string Encrypt(byte[] pubKey, string txtToEncrypt)
        {
            var publicKey = (RsaKeyParameters)PublicKeyFactory.CreateKey(pubKey);

            var rsa = new RSACryptoServiceProvider();

            var rsaParameters = new RSAParameters
            {
                Modulus = publicKey.Modulus.ToByteArrayUnsigned(),
                Exponent = publicKey.Exponent.ToByteArrayUnsigned()
            };

            rsa.ImportParameters(rsaParameters);

            var bytes = Encoding.UTF8.GetBytes(txtToEncrypt);

            var textByteLength = bytes.Length;
            var maxLength = 490;

            var result = new StringBuilder();

            if (textByteLength > maxLength)
            {
                var parts = Math.Ceiling(Convert.ToDouble(textByteLength) / Convert.ToDouble(maxLength));
                var textLength = (int)Math.Ceiling(txtToEncrypt.Length / parts);

                for (var i = 0; i < txtToEncrypt.Length; i += textLength)
                {
                    var str = i + textLength > txtToEncrypt.Length ? txtToEncrypt.Substring(i, txtToEncrypt.Length - i) : txtToEncrypt.Substring(i, textLength);

                    var partEnc = rsa.Encrypt(Encoding.UTF8.GetBytes(str), false);

                    result.Append(Convert.ToBase64String(partEnc));

                    if (txtToEncrypt.Length - i >= textLength)
                        result.Append("|");
                }
            }
            else
            {
                var enc = rsa.Encrypt(bytes, false);
                result.Append(Convert.ToBase64String(enc));
            }

            return result.ToString();
        }
    }
}
