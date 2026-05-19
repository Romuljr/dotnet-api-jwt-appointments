using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace API02.CrossCutting.Cryptography
{
    public class MD5Cryptography
    {
        public static string Encrypt(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            string result = string.Empty;
            foreach (var item in hash) 
            {
                result += item.ToString("X2").ToUpper();
            }

            return result;
        }
    }
}
