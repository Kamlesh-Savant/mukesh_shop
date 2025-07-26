using System;
using System.Security.Cryptography;
using System.Text;

namespace MukeshShop
{
    public static class LicenseManager
    {
        private const string _secretSalt = "MukeshShop2025"; // Must match with tool

        public static bool ValidateKey(string enteredKey)
        {
            string machineId = MachineHelper.GetMachineId();
            string expectedKey = GenerateKey(machineId);
            return string.Equals(enteredKey, expectedKey, StringComparison.OrdinalIgnoreCase);
        }

        public static string GenerateKey(string machineId)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretSalt)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(machineId));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}
