using System;
using System.Windows.Forms;

namespace CServer
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        public Form1() {
            InitializeComponent();

            notifyIcon = new NotifyIcon {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "CManager"
            };

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exit", null, Exit_Click);
            notifyIcon.ContextMenuStrip = contextMenu;


        }

        private void Exit_Click(object? sender, EventArgs e) {
            this.Close();
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}
