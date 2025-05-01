using System;
using System.Drawing; // Add this for Icon
using System.Windows.Forms;

namespace CServer
{
    public partial class MainWindowForm : Form
    {
        private NotifyIcon notifyIcon;

        public MainWindowForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            InitializeGUI();
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = new Icon("resources/app_icon.ico"),
                Visible = true,
                Text = "CManager"
            };

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exit", null, Exit_Click);
            notifyIcon.ContextMenuStrip = contextMenu;
        }

        private void InitializeGUI()
        {
            this.Icon = new Icon("resources/app_icon.ico");
            this.CenterToScreen();
            // Create and configure panels
            Panel panelTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.LightGray
            };
            this.Controls.Add(panelTop);

            Panel panelBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.LightGray
            };
            this.Controls.Add(panelBottom);

            Panel panelLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = Color.White
            };
            this.Controls.Add(panelLeft);

            Panel panelCenter = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(panelCenter);

            // Create buttons
            Button btnManagePasswords = new Button
            {
                Location = new Point(20, 20),
                Size = new Size(160, 30),
                Text = "Manage Passwords"
            };
            btnManagePasswords.Click += btnManagePasswords_Click;
            panelLeft.Controls.Add(btnManagePasswords);

            Button btnStartServer = new Button
            {
                Location = new Point(20, 60),
                Size = new Size(160, 30),
                Text = "Start Server"
            };
            btnStartServer.Click += BtnStartServer_Click; // Add event handler
            panelLeft.Controls.Add(btnStartServer);

            Button btnStopServer = new Button
            {
                Location = new Point(20, 100),
                Size = new Size(160, 30),
                Text = "Stop Server"
            };
            btnStopServer.Click += BtnStopServer_Click; // Add event handler
            panelLeft.Controls.Add(btnStopServer);

            Button btnSettings = new Button
            {
                Location = new Point(20, 140),
                Size = new Size(160, 30),
                Text = "Settings"
            };
            panelLeft.Controls.Add(btnSettings);

            Button btnAbout = new Button
            {
                Location = new Point(20, 180),
                Size = new Size(160, 30),
                Text = "About"
            };
            panelLeft.Controls.Add(btnAbout);
        }

        private void btnManagePasswords_Click(object sender, EventArgs e)
        {
            using (var passwordManagerForm = new PasswordManagerForm())
            {
                passwordManagerForm.ShowDialog();
            }
        }

        private void Exit_Click(object? sender, EventArgs e)
        {
            this.Close();
            notifyIcon.Dispose();
            Application.Exit();
        }

        // Event handlers for new buttons
        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            // Logic to start the server
            notifyIcon.ShowBalloonTip(1000, "CServer", "Server started...", ToolTipIcon.Info);
        }

        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            // Logic to stop the server
            notifyIcon.ShowBalloonTip(1000, "CServer", "Server stopped...", ToolTipIcon.Info);
        }
    }
}