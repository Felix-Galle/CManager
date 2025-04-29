using System;
using System.Windows.Forms;

namespace Cclient
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;

        public Form1() { // FOrm1 construcotr
            //InitializeComponent();

            // Initialize NotifyIcon
            notifyIcon = new NotifyIcon {
                Icon = SystemIcons.Application, // Set icon here
                Visible = true,
                Text = "Cclient"
            };

            // Add a context menu
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exit", null, Exit_Click);
            notifyIcon.ContextMenuStrip = contextMenu;

            // Show balloon tip (optional)
            notifyIcon.ShowBalloonTip(1000, "Tray App", "Application is running in the system tray.", ToolTipIcon.Info);

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Hide();
        }

        private void Exit_Click(object? sender, EventArgs e)
        {
            // Dispose of the NotifyIcon
            this.Close();
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}