using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesV3;

public class RegisterPelamarCommand : ICommand
{
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
