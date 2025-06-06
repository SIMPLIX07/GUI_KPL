using System;
using System.Windows.Forms;
using TubesV3;

namespace index
{
    public partial class RegisterPelamar : Form
    {
        public RegisterPelamar()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;port=3306;database=pencari_kerja;user=root;password=";
            Database.Init(connectionString);

            // Mengambil input dari TextBox
            string username = textBox1.Text;
            string password = textBox2.Text;
            string namaLengkap = textBox3.Text;
            string skill = textBox4.Text;
            string pengalaman = textBox5.Text;

            // Validasi input (pastikan tidak ada yang kosong)
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(namaLengkap) || string.IsNullOrEmpty(skill) ||
                string.IsNullOrEmpty(pengalaman))
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            // Membuat objek Pelamar baru
            Pelamar pelamar = new Pelamar(username, password, namaLengkap, skill, pengalaman);

            try
            {
                Database.Context.Pelamars.Add(pelamar);
                Database.Context.SaveChanges();
                MessageBox.Show("Pelamar berhasil didaftarkan!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }
}
