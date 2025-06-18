namespace index
{
    partial class RegisterPerusahaan
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelUsername = new Label(); // Label "Masukkan Username"
            labelPassword = new Label(); // Label "Masukkan Password"
            labelNamaPerusahaan = new Label(); // Label "Masukkan Nama Perusahaan"
            labelNomorPerusahaan = new Label(); // Label "Masukkan Nomor Perusahaan"
            textBoxInputUsername = new TextBox(); // Input username
            textBoxInputPassword = new TextBox(); // Input password
            textBoxInputNamaPerusahaan = new TextBox(); // Input nama perusahaan
            textBoxInputNoPerusahaan = new TextBox(); // Input nomor perusahaan
            buttonDaftar = new Button(); // Tombol "Daftar"
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(270, 141);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(117, 15);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Masukkan Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(270, 169);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(114, 15);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Masukkan Password";
            // 
            // labelNamaPerusahaan
            // 
            labelNamaPerusahaan.AutoSize = true;
            labelNamaPerusahaan.Location = new Point(270, 198);
            labelNamaPerusahaan.Name = "labelNamaPerusahaan";
            labelNamaPerusahaan.Size = new Size(160, 15);
            labelNamaPerusahaan.TabIndex = 2;
            labelNamaPerusahaan.Text = "Masukkan Nama Perusahaan";
            // 
            // labelNomorPerusahaan
            // 
            labelNomorPerusahaan.AutoSize = true;
            labelNomorPerusahaan.Location = new Point(270, 225);
            labelNomorPerusahaan.Name = "labelNomorPerusahaan";
            labelNomorPerusahaan.Size = new Size(166, 15);
            labelNomorPerusahaan.TabIndex = 3;
            labelNomorPerusahaan.Text = "Masukkan Nomor Perusahaan";
            // 
            // textBoxInputUsername
            // 
            textBoxInputUsername.Location = new Point(460, 141);
            textBoxInputUsername.Name = "textBoxInputUsername";
            textBoxInputUsername.Size = new Size(150, 23);
            textBoxInputUsername.TabIndex = 4;
            // 
            // textBoxInputPassword
            // 
            textBoxInputPassword.Location = new Point(460, 170);
            textBoxInputPassword.Name = "textBoxInputPassword";
            textBoxInputPassword.Size = new Size(150, 23);
            textBoxInputPassword.TabIndex = 5;
            // 
            // textBoxInputNamaPerusahaan
            // 
            textBoxInputNamaPerusahaan.Location = new Point(460, 199);
            textBoxInputNamaPerusahaan.Name = "textBoxInputNamaPerusahaan";
            textBoxInputNamaPerusahaan.Size = new Size(150, 23);
            textBoxInputNamaPerusahaan.TabIndex = 6;
            // 
            // textBoxInputNoPerusahaan
            // 
            textBoxInputNoPerusahaan.Location = new Point(460, 228);
            textBoxInputNoPerusahaan.Name = "textBoxInputNoPerusahaan";
            textBoxInputNoPerusahaan.Size = new Size(150, 23);
            textBoxInputNoPerusahaan.TabIndex = 7;
            // 
            // buttonDaftar
            // 
            buttonDaftar.Location = new Point(350, 280);
            buttonDaftar.Name = "buttonDaftar";
            buttonDaftar.Size = new Size(100, 30);
            buttonDaftar.TabIndex = 8;
            buttonDaftar.Text = "Daftar";
            buttonDaftar.UseVisualStyleBackColor = true;
            buttonDaftar.Click += buttonDaftar_Click;
            // 
            // RegisterPerusahaan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonDaftar);
            Controls.Add(textBoxInputNoPerusahaan);
            Controls.Add(textBoxInputNamaPerusahaan);
            Controls.Add(textBoxInputPassword);
            Controls.Add(textBoxInputUsername);
            Controls.Add(labelNomorPerusahaan);
            Controls.Add(labelNamaPerusahaan);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Name = "RegisterPerusahaan";
            Text = "Register Perusahaan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private Label labelPassword;
        private Label labelNamaPerusahaan;
        private Label labelNomorPerusahaan;
        private TextBox textBoxInputUsername;
        private TextBox textBoxInputPassword;
        private TextBox textBoxInputNamaPerusahaan;
        private TextBox textBoxInputNoPerusahaan;
        private Button buttonDaftar;
    }
}
