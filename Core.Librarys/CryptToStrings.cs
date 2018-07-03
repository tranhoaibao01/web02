using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Core.Librarys
{
    public class CryptToStrings
    {
        #region Region: Khai báo hằng

        #endregion

        #region Region: Khai báo biến

        #endregion

        #region Region: Định nghĩa thuộc tính

        #endregion

        #region Region: Định nghĩa các phương thức
        
        /// <summary>
        /// Mã hóa
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public static string EncryptToUTF8(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("123abcR"));
            }
            else keyArray = Encoding.UTF8.GetBytes("123abcR");
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// Giải mã
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public string DecryptUTF8(string toDecrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("123abcR"));
            }
            else keyArray = Encoding.UTF8.GetBytes("123abcR");
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
        /// <summary>
        /// Mã hóa MD5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EncryptToMD5(string text)
        {
            MD5CryptoServiceProvider _md5Hasher = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(text);
            bs = _md5Hasher.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }
        /// <summary>
        /// Giải mã MD5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DecryptToMD5(string text)
        {
            //MD5CryptoServiceProvider _md5Hasher = new MD5CryptoServiceProvider();
            //byte[] bs = Encoding.UTF8.GetBytes(text);
            //bs = _md5Hasher.ComputeHash(bs);
            
            //StringBuilder s = new StringBuilder();
            //foreach (byte b in bs)
            //{
            //    s.Append(b.ToString("x2"));
            //}
            //return s.ToString();
            return "";
        }
        
        #endregion
    }
}
