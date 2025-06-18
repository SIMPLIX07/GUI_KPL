using System;
using System.Linq;

namespace TubesV3
{
    public class PerusahaanLogin : IUserLogin
    {
        private readonly DaftarPerusahaanVerified _daftarPerusahaan;

        public PerusahaanLogin(DaftarPerusahaanVerified daftarPerusahaan)
        {
            _daftarPerusahaan = daftarPerusahaan;
        }

        public void Login()
        {
            string username = Program.GetNonEmptyInput("Username: ");
            string password = Program.GetNonEmptyInput("Password: ");

            _daftarPerusahaan.initializeDataPerusahaanVerified(Database.Context.Perusahaans.ToList());

            if (_daftarPerusahaan.cekPerusahaan(username, password))
            {
                Perusahaan perusahaan = _daftarPerusahaan.verifPerusahaan(username, password);
                Program.PerusahaanMenu(perusahaan);
            }
            else
            {
                Console.WriteLine("Perusahaan tidak terdaftar atau belum diverifikasi.\n");
            }
        }
    }
}