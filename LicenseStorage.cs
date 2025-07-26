using Microsoft.Win32;

namespace MukeshShop
{
    public static class LicenseStorage
    {
        private const string RegistryPath = @"SOFTWARE\reg\data";
        private const string LicenseKeyName = "LicenseKey";

        // Check if license is already saved
        public static bool IsLicenseSaved()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath))
            {
                return key?.GetValue(LicenseKeyName) != null;
            }
        }

        // Save license key in registry
        public static void SaveLicense(string licenseKey)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath))
            {
                key.SetValue(LicenseKeyName, licenseKey);
            }
        }

        // Load license key from registry
        public static string LoadLicense()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath))
            {
                return key?.GetValue(LicenseKeyName)?.ToString();
            }
        }
    }
}
