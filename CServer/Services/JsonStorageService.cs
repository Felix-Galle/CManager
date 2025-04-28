using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CServer.Models;

namespace CServer.Services
{
    public static class JsonStorageService
    {
        private static readonly string ClientsListPath = "clients_list.json";
        private static readonly string ClientsFolder = "clients";

        static JsonStorageService()
        {
            if (!Directory.Exists(ClientsFolder))
                Directory.CreateDirectory(ClientsFolder);
        }

        public static void SaveClientProfile(ClientProfile profile)
        {
            string clientFilePath = Path.Combine(ClientsFolder, $"{profile.MachineName}.json");
            string jsonData = JsonSerializer.Serialize(profile, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(clientFilePath, jsonData);

            UpdateClientsList(profile);
        }

        private static void UpdateClientsList(ClientProfile profile)
        {
            List<ClientSummary> summaries;

            if (File.Exists(ClientsListPath))
            {
                string existingData = File.ReadAllText(ClientsListPath);
                summaries = JsonSerializer.Deserialize<List<ClientSummary>>(existingData) ?? new List<ClientSummary>();
            }
            else
            {
                summaries = new List<ClientSummary>();
            }

            var existing = summaries.Find(c => c.PcName == profile.MachineName);
            if (existing == null)
            {
                summaries.Add(new ClientSummary
                {
                    PcName = profile.MachineName,
                    MacAddress = profile.MacAddress ?? "Unknown"
                });

                string newJson = JsonSerializer.Serialize(summaries, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ClientsListPath, newJson);
            }
        }
    }

    public class ClientSummary
    {
        public string PcName { get; set; }
        public string MacAddress { get; set; }
    }
}
