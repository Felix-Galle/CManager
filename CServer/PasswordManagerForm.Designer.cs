namespace CServer
{
    partial class PasswordManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblBackupPassword = new System.Windows.Forms.Label();
            this.txtBackupPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(12, 29);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(260, 20);
            this.txtNewPassword.TabIndex = 0;
            this.txtNewPassword.PlaceholderText = "New Password";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(197, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(116, 85);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(12, 13);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(78, 13);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password:";
            // 
            // lblBackupPassword
            // 
            this.lblBackupPassword.AutoSize = true;
            this.lblBackupPassword.Location = new System.Drawing.Point(12, 55);
            this.lblBackupPassword.Name = "lblBackupPassword";
            this.lblBackupPassword.Size = new System.Drawing.Size(94, 13);
            this.lblBackupPassword.TabIndex = 4;
            this.lblBackupPassword.Text = "Backup Password:";
            // 
            // txtBackupPassword
            // 
            this.txtBackupPassword.Location = new System.Drawing.Point(12, 71);
            this.txtBackupPassword.Name = "txtBackupPassword";
            this.txtBackupPassword.PasswordChar = '*';
            this.txtBackupPassword.Size = new System.Drawing.Size(260, 20);
            this.txtBackupPassword.TabIndex = 5;
            this.txtBackupPassword.Text = "yourBackupPassword"; // Display the bypass password (not editable)
            this.txtBackupPassword.ReadOnly = true; // Make it read-only
            // 
            // PasswordManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.txtBackupPassword);
            this.Controls.Add(this.lblBackupPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNewPassword);
            this.Name = "PasswordManagerForm";
            this.Text = "Manage Passwords";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblBackupPassword;
        private System.Windows.Forms.TextBox txtBackupPassword;
    }
}