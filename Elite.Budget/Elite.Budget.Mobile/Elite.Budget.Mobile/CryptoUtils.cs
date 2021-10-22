using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Elite.Budget.Mobile
{
    static class CryptoUtils
    {
        public static string Hash(string original)
        {
            using (SHA256 algorithm = SHA256.Create())
            {
                byte[] data = algorithm.ComputeHash(
                    Encoding.UTF8.GetBytes(original));

                return Convert.ToBase64String(data);
            }
        }
    }
}
