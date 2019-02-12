using System;
using System.Security.Cryptography;
using System.Text;

namespace mlp
{
    public class MyEncoding
    {
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public string EncodeToBase62(int number)
        {
            string s = @"0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string res = string.Empty;
            int temp = number;

            while (temp > 0)
            {
                res = s[temp % 62] + res;
                Console.WriteLine($"Current result = {res}");
                temp /= 62;
                Console.WriteLine($"Current temp = {temp}");
            }

            return res;
        }
    }
}