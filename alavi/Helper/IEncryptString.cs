using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace alavi.Helper
{
    public interface IEncryptString
    {
        string Encrypt(string value);
        string Decrypt(string value);
        string Prefix { get; }
    }

    public class ConfigurationBasedStringEncrypter : IEncryptString
    {
        private static readonly ICryptoTransform Encrypter;
        private static readonly ICryptoTransform Decrypter;
        private static readonly string _prefix;
        static ConfigurationBasedStringEncrypter()
        {
            //read settings from configuration     
            var key = ConfigurationManager.AppSettings["EncryptionKey"];
            var useHashingString = ConfigurationManager.AppSettings["UseHashingForEncryption"];
            bool useHashing = true;
            if (string.Compare(useHashingString, "false", true) == 0)
            {
                useHashing = false;
            }
            var prefix = ConfigurationManager.AppSettings["EncryptionPrefix"];
            if (string.IsNullOrWhiteSpace(prefix))
            {
                _prefix = "encryptedHidden_";
            }
            byte[] keyArray = null;
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            Encrypter = tdes.CreateEncryptor();
            Decrypter = tdes.CreateDecryptor();
            tdes.Clear();
        }
        #region IEncryptionSettingsProvider Members
        /// <summary>
        /// متدی برای رمزنگاری
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Encrypt(string value)
        {
            var bytes = UTF8Encoding.UTF8.GetBytes(value);
            var encryptedBytes = Encrypter.TransformFinalBlock(bytes, 0, bytes.Length);
            var encrypted = Convert.ToBase64String(encryptedBytes);
            return encrypted;
        }

        /// <summary>
        /// متدی برای رمز گشایی
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Decrypt(string value)
        {
            var bytes = Convert.FromBase64String(value);
            var decryptedBytes = Decrypter.TransformFinalBlock(bytes, 0, bytes.Length);
            var decrypted = UTF8Encoding.UTF8.GetString(decryptedBytes);
            return decrypted;
        }
        public string Prefix
        {
            get { return _prefix; }
        }
        #endregion
    }   
}
