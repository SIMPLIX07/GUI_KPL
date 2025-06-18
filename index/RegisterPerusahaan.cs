using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TubesV3;

namespace index
{
    public partial class RegisterPerusahaan : Form
    {
        public RegisterPerusahaan()
        {
            InitializeComponent();
        }

        private void buttonDaftar_Click(object sender, EventArgs e)
        {
            string usernamePerusahaan = textBoxInputUsername.Text;
            string passwordPerusahaan = textBoxInputPassword.Text;
            string namaPerusahaan = textBoxInputNamaPerusahaan.Text;
            string nomorPerusahaan = textBoxInputNoPerusahaan.Text;

            if (string.IsNullOrWhiteSpace(usernamePerusahaan) || string.IsNullOrWhiteSpace(passwordPerusahaan)
                || string.IsNullOrWhiteSpace(namaPerusahaan) || string.IsNullOrWhiteSpace(nomorPerusahaan))
            {
                MessageBox.Show("Semua field harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newPerusahaan = new Perusahaan(usernamePerusahaan, passwordPerusahaan, namaPerusahaan, nomorPerusahaan);
            Database.Context.Perusahaans.Add(newPerusahaan);
            Database.Context.SaveChanges();

            MessageBox.Show("Perusahaan berhasil didaftarkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }

}
