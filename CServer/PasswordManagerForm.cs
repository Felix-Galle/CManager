using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CServer
{
    public partial class PasswordManagerForm : Form
    {
        private const string BypassPassword = "yourBackupPassword"; // Set your bypass password here

        public PasswordManagerForm()
        {
            InitializeComponent();
            LoadPasswords();
        }

        private void LoadPasswords()
        {
            // Load existing hashed passwords if the file exists
            if (File.Exists("resources/info.dat"))
            {
                string[] passwords = File.ReadAllLines("resources/info.dat");
                if (passwords.Length >= 2)
                {
                    txtNewPassword.Text = passwords[0]; // Load the hashed password (for display purposes)
                    txtBackupPassword.Text = passwords[1]; // Load the hashed backup password (for display purposes)
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text; 
            // The backup password should not be changed
            string hashedPassword = HashPassword(newPassword);

            // Store the hashed password securely (e.g., in a file)
            File.WriteAllText("resources/info.dat", $"{hashedPassword}\n{HashPassword(BypassPassword)}");

            MessageBox.Show("Password saved successfully.");
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Remove the password by deleting the file or clearing its content
            if (File.Exists("resources/info.dat"))
            {
                File.Delete("resources/info.dat");
                MessageBox.Show("Password removed successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No password file found to remove.");
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}