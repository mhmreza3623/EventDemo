using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;

namespace SharedKernel.Common.Encryotions
{
    public static class RSACryptProvider
    {

        public static string Signn(this string data, string keyData)
        {

            var res = RsaEncryptWithPrivate(data, keyData);
            return res;
        }

        public static string RsaEncryptWithPrivate(string clearText, string privateKey)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);

            var encryptEngine = new Pkcs1Encoding(new RsaEngine());

            using (var txtreader = new StringReader(privateKey))
            {
                var keyPair = (AsymmetricCipherKeyPair)new PemReader(txtreader).ReadObject();

                encryptEngine.Init(true, keyPair.Private);
            }

            var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
            return encrypted;
        }

        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                = Encoding.ASCII.GetBytes(toEncode);
            string returnValue
                = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = Convert.FromBase64String(encodedData);
            string returnValue =
                Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static byte[] GetBytes(string s)
        {
            return Convert.FromBase64String(EncodeTo64(s));
        }

        public static string GetString(byte[] b)
        {
            return DecodeFrom64(Convert.ToBase64String(b));
        }
    }
}
