using System;
using System.Windows.Forms;
using System.Drawing;

namespace CClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotifyIcon trayIcon = new NotifyIcon
            {
                Text = "CClient Running",
                Icon = SystemIcons.Application, // You can replace with custom .ico
                Visible = true
            };

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exit", null, (s, e) =>
            {
                trayIcon.Visible = false;
                Application.Exit();
            });

            trayIcon.ContextMenuStrip = contextMenu;

            Application.Run(); // Keeps app alive without window
        }
    }
}
