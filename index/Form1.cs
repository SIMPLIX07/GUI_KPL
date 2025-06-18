using System;
using System.Windows.Forms;
using TubesV3;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace index
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pilihan = textBox1.Text;

            switch (pilihan)
            {
                case "1":
                    // Buka form Register Pelamar
                    var registerPelamarForm = new RegisterPelamar();
                    registerPelamarForm.ShowDialog();
                    break;
                case "2":
                    // Buka form Register Perusahaan
                    var registerPerusahaanForm = new RegisterPerusahaan();
                    registerPerusahaanForm.ShowDialog();
                    break;
                case "3":
                   // Buka form Login Pelamar
                   var loginPelamarForm = new LoginPelamar();
                   loginPelamarForm.ShowDialog();
                   break;
                //case "4":
                //    // Buka form Login Perusahaan
                //    var loginPerusahaanForm = new LoginPerusahaanForm();
                //    loginPerusahaanForm.ShowDialog();
                //    break;
                //case "5":
                //    // Buka form Login Admin
                //    var adminLoginForm = new AdminLoginForm();
                //    adminLoginForm.ShowDialog();
                //    break;
                default:
                    MessageBox.Show("Pilihan tidak valid. Masukkan angka antara 1 hingga 5.");
                    break;
            }
        }
    }
}
