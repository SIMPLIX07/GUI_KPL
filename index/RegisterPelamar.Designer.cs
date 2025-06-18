namespace index
{
    partial class RegisterPelamar
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
            labelNamaLengkap = new Label(); // Label "Masukkan Nama Perusahaan"
            labelSkill = new Label(); // Label "Masukkan Nomor Perusahaan"
            textBoxInUsername = new TextBox(); // Input username
            textBoxInPassword = new TextBox(); // Input password
            textBoxInNamaPelamar = new TextBox(); // Input nama perusahaan
            textBoxInSkill = new TextBox(); // Input nomor perusahaan
            buttonDaftarPelamar = new Button(); // Tombol "Daftar"
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(275, 156);
            label.Margin = new Padding(4, 0, 4, 0);
            label.Name = "label";
            label.Size = new Size(117, 15);
            label.TabIndex = 0;
            label.Text = "Masukkan Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(275, 186);
            labelPassword.Margin = new Padding(4, 0, 4, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(114, 15);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Masukkan Password";
            // 
            // labelNamaLengkap
            // 
            labelNamaLengkap.AutoSize = true;
            labelNamaLengkap.Location = new Point(276, 223);
            labelNamaLengkap.Margin = new Padding(4, 0, 4, 0);
            labelNamaLengkap.Name = "labelNamaLengkap";
            labelNamaLengkap.Size = new Size(87, 15);
            labelNamaLengkap.TabIndex = 2;
            labelNamaLengkap.Text = "Nama Lengkap";
            // 
            // labelSkill
            // 
            labelSkill.AutoSize = true;
            labelSkill.Location = new Point(272, 263);
            labelSkill.Margin = new Padding(4, 0, 4, 0);
            labelSkill.Name = "labelSkill";
            labelSkill.Size = new Size(79, 15);
            labelSkill.TabIndex = 3;
            labelSkill.Text = "Masukan Skill";
            // 
            // labelPengalaman
            // 
            labelPengalaman.AutoSize = true;
            labelPengalaman.Location = new Point(276, 306);
            labelPengalaman.Margin = new Padding(4, 0, 4, 0);
            labelPengalaman.Name = "labelPengalaman";
            labelPengalaman.Size = new Size(124, 15);
            labelPengalaman.TabIndex = 4;
            labelPengalaman.Text = "Masukan Pengalaman";
            // 
            // textBoxInUsername
            // 
            textBoxInUsername.Location = new Point(433, 148);
            textBoxInUsername.Margin = new Padding(4, 3, 4, 3);
            textBoxInUsername.Name = "textBoxInUsername";
            textBoxInUsername.Size = new Size(116, 23);
            textBoxInUsername.TabIndex = 5;
            // 
            // textBoxInPassword
            // 
            textBoxInPassword.Location = new Point(433, 186);
            textBoxInPassword.Margin = new Padding(4, 3, 4, 3);
            textBoxInPassword.Name = "textBoxInPassword";
            textBoxInPassword.Size = new Size(116, 23);
            textBoxInPassword.TabIndex = 6;
            // 
            // textBoxInNamaPelamar
            // 
            textBoxInNamaPelamar.Location = new Point(433, 223);
            textBoxInNamaPelamar.Margin = new Padding(4, 3, 4, 3);
            textBoxInNamaPelamar.Name = "textBoxInNamaPelamar";
            textBoxInNamaPelamar.Size = new Size(116, 23);
            textBoxInNamaPelamar.TabIndex = 7;
            // 
            // textBoxInSkill
            // 
            textBoxInSkill.Location = new Point(433, 263);
            textBoxInSkill.Margin = new Padding(4, 3, 4, 3);
            textBoxInSkill.Name = "textBoxInSkill";
            textBoxInSkill.Size = new Size(116, 23);
            textBoxInSkill.TabIndex = 8;
            // 
            // textBoxInPengalaman
            // 
            textBoxInPengalaman.Location = new Point(433, 298);
            textBoxInPengalaman.Margin = new Padding(4, 3, 4, 3);
            textBoxInPengalaman.Name = "textBoxInPengalaman";
            textBoxInPengalaman.Size = new Size(116, 23);
            textBoxInPengalaman.TabIndex = 9;
            // 
            // buttonDaftarPelamar
            // 
            buttonDaftarPelamar.Location = new Point(340, 365);
            buttonDaftarPelamar.Margin = new Padding(4, 3, 4, 3);
            buttonDaftarPelamar.Name = "buttonDaftarPelamar";
            buttonDaftarPelamar.Size = new Size(88, 27);
            buttonDaftarPelamar.TabIndex = 10;
            buttonDaftarPelamar.Text = "Daftar";
            buttonDaftarPelamar.UseVisualStyleBackColor = true;
            buttonDaftarPelamar.Click += buttonDaftarPelamar_Click_1;
            // 
            // RegisterPelamar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(buttonDaftarPelamar);
            Controls.Add(textBoxInPengalaman);
            Controls.Add(textBoxInSkill);
            Controls.Add(textBoxInNamaPelamar);
            Controls.Add(textBoxInPassword);
            Controls.Add(textBoxInUsername);
            Controls.Add(labelPengalaman);
            Controls.Add(labelSkill);
            Controls.Add(labelNamaLengkap);
            Controls.Add(labelPassword);
            Controls.Add(label);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RegisterPelamar";
            Text = "Form Registrasi Pelamar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelNamaLengkap;
        private System.Windows.Forms.Label labelSkill;
        private System.Windows.Forms.Label labelPengalaman;
        private System.Windows.Forms.TextBox textBoxInUsername;
        private System.Windows.Forms.TextBox textBoxInPassword;
        private System.Windows.Forms.TextBox textBoxInNamaPelamar;
        private System.Windows.Forms.TextBox textBoxInSkill;
        private System.Windows.Forms.TextBox textBoxInPengalaman;
        private System.Windows.Forms.Button buttonDaftarPelamar;
    }
}
