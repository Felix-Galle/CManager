using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CServer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the password entry form
            using (var passwordForm = new PasswordEntryForm())
            {
                if (passwordForm.ShowDialog() == DialogResult.OK && passwordForm.IsPasswordCorrect)
                {
                    // Only show Form1 if the password is correct
                    Application.Run(new MainWindowForm());
                }
                else
                {
                    // Optionally, you can exit the application if the password is incorrect
                    MessageBox.Show("Access Denied.");
                }
            }
        }
    }
}