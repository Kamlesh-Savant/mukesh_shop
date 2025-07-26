using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace MukeshShop
{
    public static class MachineHelper
    {
        public static string GetMachineId()
        {
            try
            {
                string cpuId = GetWMIProperty("Win32_Processor", "ProcessorId");
                string motherboardId = GetWMIProperty("Win32_BaseBoard", "SerialNumber");
                string diskId = GetWMIProperty("Win32_LogicalDisk", "VolumeSerialNumber");

                string rawId = cpuId + motherboardId + diskId;

                // Hash it with SHA256
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(rawId);
                    byte[] hashBytes = sha256.ComputeHash(bytes);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("X2")); // Uppercase hex
                    }
                    return sb.ToString(); // Final unique machine ID
                }
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        private static string GetWMIProperty(string wmiClass, string property)
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT {property} FROM {wmiClass}"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj[property]?.ToString() ?? "";
                    }
                }
            }
            catch { }
            return "";
        }
    }
}
