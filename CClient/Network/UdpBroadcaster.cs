using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CClient.Network
{
    public static class UdpBroadcaster
    {
        private const int UdpPort = 8888;

        public static async Task BroadcastPresenceAsync()
        {
            using var udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;

            string message = $"{Environment.MachineName}|{Environment.UserName}";
            byte[] sendBytes = Encoding.UTF8.GetBytes(message);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, UdpPort);

            while (true)
            {
                await udpClient.SendAsync(sendBytes, sendBytes.Length, endPoint);
                await Task.Delay(5000); // Broadcast every 5 seconds
            }
        }
    }
}
