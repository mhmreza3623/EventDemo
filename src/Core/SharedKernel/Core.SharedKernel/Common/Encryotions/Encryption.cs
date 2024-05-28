using System.Security.Cryptography;
using System.Text;

namespace SharedKernel.Common.Encryotions
{
    public static class Encryption
    {
        public static string ComputeSha256Hash(string channel, string serviceName, string accountNumber, string secret)
        {
            var rawData = channel + ";" + serviceName + ";" + accountNumber + ";" + secret;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        /// <summary>
        /// امضا rds
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string SignData(string text)
        {
            bool isRsaEnable=true;
            //اگر در appsetting فعال باشد امضا میشود
            //bool.TryParse(IocManager.Instance.Resolve<IAppConfigurationAccessor>().Configuration["App:RSAEnableForAdanic"], out isRsaEnable);
            if (isRsaEnable)
            {
                string privateKey = "";
                //try
                //{
                //    privateKey = File.ReadAllText(AppConsts.PrivateKeyAbrishamPath);
                //}
                //catch
                //{
                //    throw new DpkException(AdanicConsts.Messages.PrivateKeyNotFound);
                //}

                return text.ToLower().Signn(privateKey); //CryptoProvider.SignDate(text, privateKey);
            }

            return text;
        }


    }
}
