using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TechnicalChallenge
{
    internal class OTP
    {

        public static string GeneratePassword(string userId, DateTime dateTime)
        {
            string inputString = userId + dateTime.ToString("yyyyMMddHHmmss");
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);

            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string password = Convert.ToBase64String(hashBytes);
                return password;
            }
        }
    }

}
