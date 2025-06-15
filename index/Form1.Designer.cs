using System;
using System.Drawing;
using System.Windows.Forms;

namespace index
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Membersihkan resource yang sedang digunakan.
        /// </summary>
        /// <param name="disposing">true jika sedang menghapus resource yang dikelola; sebaliknya, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                // Pastikan semua komponen dibersihkan dengan benar
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Inisialisasi komponen UI pada Form1.
        /// </summary>
        private void InitializeComponent()
        {
            // Deklarasi komponen
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();

            SuspendLayout(); // Menunda layout untuk meningkatkan performa saat setup

            // Setup Label
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(250, 80);
            label1.Name = "label1";
            label1.Size = new Size(300, 120);
            label1.TabIndex = 0;
            label1.Text =
                "1. Register Pelamar\n" +
                "2. Register Perusahaan\n" +
                "3. Login Pelamar\n" +
                "4. Login Perusahaan\n" +
                "5. Login Admin\n\n" +
                "Masukkan Pilihan (1-5):";

            // Setup TextBox untuk input user
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(305, 210);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(190, 25);
            textBox1.TabIndex = 1;

            // Setup Button
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.BackColor = Color.MediumSlateBlue;
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(345, 250);
            button1.Name = "button1";
            button1.Size = new Size(110, 30);
            button1.TabIndex = 2;
            button1.Text = "Pilih";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click; // Menghubungkan ke event handler

            // Setup Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            BackColor = Color.WhiteSmoke;
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Menu Awal";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout(); // Aktifkan kembali layout setelah semua kontrol ditambahkan
        }

        #endregion

        // Deklarasi komponen UI
        private Label label1;      // Menampilkan daftar pilihan menu
        private TextBox textBox1;  // Input pilihan user
        private Button button1;    // Tombol untuk mengonfirmasi pilihan
    }
}
