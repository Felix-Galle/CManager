using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CServer.Models;
using CServer.Services;
using CServer.Network;
using System.Windows;
using System.Windows.Input;

namespace CServer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartUdpListener();
        }

        private async void StartUdpListener()
        {
            await UdpListener.StartListeningAsync((message, remoteEP) =>
            {
                Dispatcher.Invoke(() =>
                {
                    AddClientCard(message, remoteEP.Address.ToString());
                });
            });
        }

        private void AddClientCard(string message, string ipAddress)
        {
            string[] parts = message.Split('|');
            string machineName = parts[0];
            string userName = parts.Length > 1 ? parts[1] : "Unknown";

            var border = new Border
            {
                Width = 80,
                Height = 80,
                Margin = new Thickness(5),
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Gray,
                Background = System.Windows.Media.Brushes.LightGray,
                Child = new TextBlock
                {
                    Text = machineName,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 12
                }
            };

            border.MouseLeftButtonUp += (s, e) =>
            {
                MessageBox.Show($"Clicked on {machineName} ({ipAddress})");
                // TODO: Open detailed view
            };

            ClientsGrid.Children.Add(border);
        }
    }
}
