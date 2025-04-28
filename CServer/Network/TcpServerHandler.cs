using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CServer.Models;

namespace CServer.Network
{
    public static class TcpServerHandler
    {
        private const int TcpPort = 9999;

        public static async Task StartServerAsync(Action<ClientProfile> onClientDataReceived)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, TcpPort);
            listener.Start();

            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client, onClientDataReceived);
            }
        }

        private static async Task HandleClientAsync(TcpClient tcpClient, Action<ClientProfile> onClientDataReceived)
        {
            try
            {
                using var client = tcpClient;
                var stream = client.GetStream();

                byte[] buffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string jsonData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                var profile = JsonSerializer.Deserialize<ClientProfile>(jsonData);

                onClientDataReceived?.Invoke(profile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TCP client handling error: {ex.Message}");
            }
        }
    }
}
