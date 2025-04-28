using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CServer.Network
{
    public static class UdpListener
    {
        private const int UdpPort = 8888;

        public static async Task StartListeningAsync(Action<string, IPEndPoint> onClientDiscovered)
        {
            using var udpClient = new UdpClient(UdpPort);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, UdpPort);

            while (true)
            {
                var result = await udpClient.ReceiveAsync();
                string message = Encoding.UTF8.GetString(result.Buffer);
                onClientDiscovered?.Invoke(message, result.RemoteEndPoint);
            }
        }
    }
}
