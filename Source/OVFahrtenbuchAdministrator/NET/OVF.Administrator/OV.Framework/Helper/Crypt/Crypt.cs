using System;
using System.Security.Cryptography;
using System.Text;

namespace OV.Framework.Helper.Crypt
{
    public static class Crypt
    {
        public static string EncryptString(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }                
        }
    }
}
