using System;
using System.Windows.Forms;

namespace index
{
    public partial class FormLogin_Perusahaan : Form
    {
        public FormLogin_Perusahaan()
        {
            InitializeComponent();
        }

        private void FormLogin_Perusahaan_Load(object sender, EventArgs e)
        {
            // Bisa dikosongin atau isi inisialisasi awal
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "perusahaan" && password == "123")
            {
                MessageBox.Show("Login berhasil sebagai Perusahaan!");
                // TODO: Arahkan ke form dashboard perusahaan
            }
            else
            {
                MessageBox.Show("Username atau password salah.");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Kosongkan atau isi validasi input username
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
