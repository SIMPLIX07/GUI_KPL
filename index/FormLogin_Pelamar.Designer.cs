namespace index
{
    partial class FormLogin_Pelamar
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(86, 40);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(137, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Masukan Username";
            lblUsername.Click += lblUsername_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(245, 40);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(86, 90);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(132, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Masukan Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(245, 87);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(295, 141);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 35);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FormLogin_Pelamar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 343);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Name = "FormLogin_Pelamar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Pelamar";
            Load += FormLogin_Pelamar_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
