using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CClient.Services
{
    public static class SystemInfoService
    {
        public static Dictionary<string, string> GatherSystemInfo()
        {
            var info = new Dictionary<string, string>
            {
                { "MachineName", Environment.MachineName },
                { "UserName", Environment.UserName },
                { "OSVersion", Environment.OSVersion.ToString() },
                { "ProcessorCount", Environment.ProcessorCount.ToString() },
                { "SystemDirectory", Environment.SystemDirectory },
                { "CurrentDirectory", Environment.CurrentDirectory }
            };

            return info;
        }

        public static List<string> GetRunningApplications()
        {
            List<string> runningApps = new List<string>();

            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    if (!string.IsNullOrEmpty(process.MainWindowTitle))
                        runningApps.Add(process.ProcessName);
                }
                catch { /* ignored */ }
            }

            return runningApps;
        }
    }
}
