using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    public class ClassEncrypt
    {
        string key = "HvaDpgEZ5oMin IIpsW7Q9kpHSnoltGzeCBgQA6HZg=";
        string IV = "MSDyyaDjwMmR6giMeyUpTA==";
        public static string EncryptText(string textString, string key, string IV)
        {
            if (string.IsNullOrEmpty(textString) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(IV))
                throw new Exception("Строка пустая");
            byte[] encrypted;
            using(AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(IV);
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(textString);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return 
                Convert.ToBase64String(encrypted);
        }
        public static string DecryptText(string decryptTextString, string key, string IV)
        {
            if (string.IsNullOrEmpty(decryptTextString) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(IV))
                throw new Exception("Строка пустая");
            string plaintext = null;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(IV);
                ICryptoTransform decryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(decryptTextString)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            
            return plaintext;
        }
    }
}
