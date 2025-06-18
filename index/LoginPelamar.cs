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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace index
{
    public partial class LoginPelamar : Form
    {
        public LoginPelamar()
        {
            InitializeComponent();
        }

        private List<Pelamar> semuaPelamar; // Declare globally or fetch it elsewhere

        private void button1_Click(object sender, EventArgs e)
        {
            // Mengambil input dari TextBox
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Validasi input
            if (!IsInputValid(username, password))
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            // Inisialisasi koneksi database
            if (!InitializeDatabase())
            {
                MessageBox.Show("Database context tidak terinisialisasi.");
                return;
            }

            // Ambil daftar pelamar dari database
            List<Pelamar> semuaPelamar = Database.Context.Pelamars.ToList();

            // Cek apakah daftar pelamar kosong
            if (semuaPelamar == null || semuaPelamar.Count == 0)
            {
                MessageBox.Show("Tidak ada pelamar dalam database.");
                return;
            }

            // Verifikasi pelamar berdasarkan username dan password
            Pelamar pelamar = VerifyPelamar(semuaPelamar, username, password);

            // Tampilkan hasil verifikasi
            if (pelamar != null)
            {
                MessageBox.Show("Login Berhasil!"); // Pesan sukses
                                                    // Lakukan aksi lain setelah login berhasil, seperti membuka form lain
            }
            else
            {
                MessageBox.Show("Pelamar tidak terdaftar atau password salah.");
            }
        }

        // Metode untuk memvalidasi input
        private bool IsInputValid(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }

        // Metode untuk inisialisasi koneksi database
        private bool InitializeDatabase()
        {
            try
            {
                string connectionString = "server=localhost;port=3306;database=pencari_kerja;user=root;password=";
                Database.Init(connectionString);
                return Database.Context != null; // Mengembalikan true jika konteks database berhasil diinisialisasi
            }
            catch (Exception ex)
            {
                // Menangani error koneksi atau lainnya
                MessageBox.Show($"Kesalahan koneksi database: {ex.Message}");
                return false;
            }
        }

        // Metode untuk memverifikasi pelamar berdasarkan username dan password
        private Pelamar VerifyPelamar(List<Pelamar> semuaPelamar, string username, string password)
        {
            return semuaPelamar.FirstOrDefault(p => p.username == username && p.password == password);
        }

    }
}
