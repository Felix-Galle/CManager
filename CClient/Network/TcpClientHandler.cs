using System;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using CClient.Services; // <-- for SystemInfoService

namespace CClient.Network
{
    public static class TcpClientHandler
    {
        public static async Task ConnectAndSendSystemInfoAsync(string serverIp, int serverPort)
        {
            try
            {
                using var client = new TcpClient();
                await client.ConnectAsync(serverIp, serverPort);

                var systemInfo = SystemInfoService.GatherSystemInfo();
                string jsonData = JsonSerializer.Serialize(systemInfo);

                var stream = client.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonData);

                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TCP Connection error: {ex.Message}");
            }
        }
    }
}
