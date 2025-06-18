using System;
using System.Linq;

namespace TubesV3
{
    public class PelamarLogin : IUserLogin
    {
        private readonly DaftarSemuaPelamar _semuaPelamar;
        private readonly DaftarPerusahaanVerified _daftarPerusahaan;

        public PelamarLogin(DaftarSemuaPelamar semuaPelamar, DaftarPerusahaanVerified daftarPerusahaan)
        {
            _semuaPelamar = semuaPelamar;
            _daftarPerusahaan = daftarPerusahaan;
        }

        public void Login()
        {
            string username = Program.GetNonEmptyInput("Username: ");
            string password = Program.GetNonEmptyInput("Password: ");

            if (_semuaPelamar.verfikasiPelamar(username, password))
            {
                Pelamar pelamar = _semuaPelamar.cariPelamar(username, password);
                Program.PelamarMenu(pelamar, _daftarPerusahaan);
            }
            else
            {
                Console.WriteLine("Pelamar tidak terdaftar\n");
            }
        }
    }
}