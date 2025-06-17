using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesV3;

/// <summary>
/// Command untuk menangani proses registrasi pelamar baru ke dalam sistem.
/// </summary>
/// <remarks>
/// Implementasi dari ICommand yang bertanggung jawab untuk:
/// 1. Memvalidasi username unik
/// 2. Mengumpulkan data pelamar
/// 3. Menyimpan data ke database
/// </remarks>
public class RegisterPelamarCommand : ICommand
{
    /// <summary>
    /// Menjalankan alur registrasi pelamar secara interaktif melalui console.
    /// Username yang diinput harus berbeda dengan username lainnya
    /// </summary>
    /// <remarks>
    /// Proses yang dilakukan:
    /// 1. Meminta input username yang unik
    /// 2. Mengumpulkan data pribadi pelamar
    /// 3. Membuat objek Pelamar baru
    /// 4. Menyimpan ke database
    /// 5. Memberikan konfirmasi registrasi
    /// </remarks>
    public void Execute()
    {
        Console.WriteLine("=== Registrasi Pelamar ===");
        string username;
        bool exists;
        do
        {
            Console.Write("Username: ");
            username = Console.ReadLine()?.Trim();
            exists = Database.Context.Pelamars.Any(p => p.username == username);
            if (exists) Console.WriteLine("Username sudah digunakan!");
        } while (exists);

        Console.Write("Password: ");
        string password = Console.ReadLine()?.Trim();
        Console.Write("Nama Lengkap: ");
        string nama = Console.ReadLine()?.Trim();
        Console.Write("Skill: ");
        string skill = Console.ReadLine()?.Trim();
        Console.Write("Pengalaman: ");
        string pengalaman = Console.ReadLine()?.Trim();

        Pelamar pelamar = new Pelamar(username, password, nama, skill, pengalaman);
        Database.Context.Pelamars.Add(pelamar);
        Database.Context.SaveChanges();

        Console.WriteLine("Pelamar berhasil didaftarkan.\n");
    }
}