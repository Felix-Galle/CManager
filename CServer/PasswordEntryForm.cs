using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CServer
{
    public partial class PasswordEntryForm : Form
    {
        public bool IsPasswordCorrect { get; private set; } = false;

        public PasswordEntryForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text; // Assuming you have a TextBox named txtPassword
            string[] storedPasswords = File.ReadAllLines("resources/info.dat");

            if (storedPasswords.Length >= 2)
            {
                string hashedPassword = storedPasswords[0];
                string hashedBackupPassword = storedPasswords[1];

                if (VerifyPassword(enteredPassword, hashedPassword) || VerifyPassword(enteredPassword, hashedBackupPassword))
                {
                    IsPasswordCorrect = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("No passwords set. Please set a password first.");
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword == storedHash;
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