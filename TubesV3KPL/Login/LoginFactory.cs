using System;
using System.Linq;
using System;

namespace TubesV3
{
    public static class LoginFactory
    {
        public static IUserLogin CreateLogin(string role, DaftarSemuaPelamar semuaPelamar, DaftarPerusahaanVerified daftar)
        {
            return role.ToLower() switch
            {
                "pelamar" => new PelamarLogin(semuaPelamar, daftar),
                "perusahaan" => new PerusahaanLogin(daftar),
                _ => throw new ArgumentException("Role tidak dikenal."),
            };
        }
    }

}