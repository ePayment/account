using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;
using System.IO;

namespace Account.Common.Utilities
{
    public class CryptProvider
    {
        protected const string key = "9F3A521B-14B7-4A73-84FB-42A13BF07FE5";
        public string Encrypt(string data)
        {
            return Encrypt(key, data);
        }
        public string Decrypt(string data)
        {
            return Decrypt(key, data);
        }
        public string Encrypt(string key, string data)
        {
            try
            {
                data = data.Trim();
                byte[] keydata = Encoding.UTF8.GetBytes(key);
                string md5String = BitConverter.ToString(new
                                                             MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").ToLower();
                byte[] tripleDesKey = Encoding.UTF8.GetBytes(md5String.Substring(0, 24));
                TripleDES tripdes = TripleDESCryptoServiceProvider.Create();
                tripdes.Mode = CipherMode.ECB;
                tripdes.Key = tripleDesKey;
                tripdes.GenerateIV();
                MemoryStream ms = new MemoryStream();
                CryptoStream encStream = new CryptoStream(ms, tripdes.CreateEncryptor(),
                                                          CryptoStreamMode.Write);
                encStream.Write(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));
                encStream.FlushFinalBlock();
                byte[] cryptoByte = ms.ToArray();
                ms.Close();
                encStream.Close();
                return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0)).Trim();
            }
            catch
            {
                return "";
            }

        }
        public string Decrypt(string key, string data)
        {
            try
            {
                byte[] keydata = Encoding.UTF8.GetBytes(key);
                string md5String = BitConverter.ToString(new
                                                             MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").ToLower();
                byte[] tripleDesKey = Encoding.UTF8.GetBytes(md5String.Substring(0, 24));
                TripleDES tripdes = TripleDESCryptoServiceProvider.Create();
                tripdes.Mode = CipherMode.ECB;
                tripdes.Key = tripleDesKey;
                byte[] cryptByte = Convert.FromBase64String(data);
                var ms = new MemoryStream(cryptByte, 0, cryptByte.Length);
                ICryptoTransform cryptoTransform = tripdes.CreateDecryptor();
                var decStream = new CryptoStream(ms, cryptoTransform,
                                                 CryptoStreamMode.Read);
                var read = new StreamReader(decStream);
                return (read.ReadToEnd());
            }
            catch
            {
                return "";
            }
        }
    }
}