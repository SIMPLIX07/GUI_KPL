using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TubesV3;

class Program
{
    // Delegate untuk aksi menu
    delegate void MenuAction();

    static Admin admin = new Admin("admin", "admin123");

    static void Main(string[] args)
    {
        InitDatabase();
        SeedInitialData();

        var semuaLowongan = Database.Context.Lowongans.ToList();
        var semuaPelamar = new DaftarSemuaPelamar();
        var daftarVerified = new DaftarPerusahaanVerified();

        SimulasikanNotifikasiPelamar(admin);

        // Mapping menu utama ke aksi
        var menuActions = new Dictionary<string, MenuAction>
        {
            { "1", RegisterPerusahaan },
            { "2", () => ExecuteCommand(new RegisterPelamarCommand()) },
            { "3", () => AdminMenu(admin) },
            { "4", () => LoginFactory.CreateLogin("perusahaan", semuaPelamar, daftarVerified).Login() },
            { "5", () => LoginFactory.CreateLogin("pelamar", semuaPelamar, daftarVerified).Login() }
        };

        // Menu utama
        string input;
        do
        {
            Menu.menuLogin();
            Console.Write("Pilih menu: ");
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input tidak boleh kosong!");
                continue;
            }

            if (menuActions.TryGetValue(input, out var action))
            {
                action();
            }
            else if (input != "0")
            {
                Console.WriteLine("Menu tidak tersedia.");
            }

        } while (input != "0");

        Console.WriteLine("Terima kasih telah menggunakan sistem rekrutmen!");
    }

    #region === Setup Awal ===

    static void InitDatabase()
    {
        string connection = "server=localhost;port=3306;database=pencari_kerja;user=root;password=";
        Database.Init(connection);
    }

    static void SeedInitialData()
    {
        ConfigPerusahaan.InitializeDefaultPerusahaan();
        ConfigPelamar.InitializeDefaultPelamars();
        ConfigLowongan.InitializeDefaultLowongan();
    }

    /// <summary>
    /// Simulasi notifikasi observer saat pelamar diterima kerja
    /// </summary>
    static void SimulasikanNotifikasiPelamar(Admin admin)
    {
        var perusahaan = new Perusahaan("company1", "password", "TechCorp", "123456789");
        var pelamar = new Pelamar("johndoe", "password123", "John Doe", "C#", "3 years");

        pelamar.Attach(admin);
        pelamar.Attach(perusahaan);

        Console.WriteLine("\nMenerima pelamar...");
        pelamar.Hire();
    }

    #endregion

    #region === Utilitas ===

    static void ExecuteCommand(ICommand cmd) => cmd.Execute();

    public static string GetNonEmptyInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input))
                Console.WriteLine("Input tidak boleh kosong!");
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    static bool IsValidUsername(string username)
    {
        return Regex.IsMatch(username, @"^[a-zA-Z0-9]{4,}$");
    }

    #endregion

    #region === Menu Registrasi/Login ===

    static void RegisterPerusahaan()
    {
        string username;
        do
        {
            username = GetNonEmptyInput("Masukkan Username: ");
            if (!IsValidUsername(username))
            {
                Console.WriteLine("Username hanya boleh huruf/angka dan minimal 4 karakter.");
                username = null;
            }
            else if (Database.Context.Perusahaans.Any(p => p.username == username))
            {
                Console.WriteLine("Username sudah digunakan.");
                username = null;
            }
        } while (string.IsNullOrWhiteSpace(username));

        var password = GetNonEmptyInput("Masukkan Password: ");
        var nama = GetNonEmptyInput("Masukkan Nama Perusahaan: ");
        var nomor = GetNonEmptyInput("Masukkan Nomor Perusahaan: ");

        var perusahaan = new Perusahaan(username, password, nama, nomor);
        Database.Context.Perusahaans.Add(perusahaan);
        Database.Context.SaveChanges();

        Console.WriteLine("Perusahaan berhasil didaftarkan.\n");
    }

    #endregion

    #region === Menu Pelamar ===

    public static void PelamarMenu(Pelamar pelamar, DaftarPerusahaanVerified daftar)
    {
        var lowongan = Database.Context.Lowongans.ToList();
        daftar.initializeDataPerusahaanVerified(Database.Context.Perusahaans.ToList());

        var menu = new Dictionary<string, MenuAction>
        {
            { "1", () => LihatLowongan(lowongan) },
            { "2", () => LamarLowongan(pelamar, daftar, lowongan) },
            { "3", () => LowonganPelamar.getLowonganPelamarById(pelamar.Id) }
        };

        string pilihan;
        do
        {
            Menu.menuPelamar();
            pilihan = GetNonEmptyInput("Pilih: ");

            if (menu.TryGetValue(pilihan, out var action))
                action();
            else if (pilihan != "0")
                Console.WriteLine("Pilihan tidak tersedia.");

        } while (pilihan != "0");
    }

    static void LihatLowongan(List<Lowongan> daftar)
    {
        new Lowongan().getAllLowongan(daftar);
    }

    static void LamarLowongan(Pelamar pelamar, DaftarPerusahaanVerified daftar, List<Lowongan> lowongan)
    {
        new Lowongan().getAllLowongan(lowongan);

        var perusahaanNama = GetNonEmptyInput("Nama Perusahaan: ");
        var posisi = GetNonEmptyInput("Posisi: ");

        var lowonganDipilih = new Lowongan().getLowonganByPosisi(posisi, lowongan);
        if (lowonganDipilih == null)
        {
            Console.WriteLine("Lowongan tidak ditemukan.");
            return;
        }

        var perusahaan = daftar.cekIdPerusahaan(perusahaanNama);
        if (perusahaan == null)
        {
            Console.WriteLine("Perusahaan tidak terverifikasi.");
            return;
        }

        var lp = new LowonganPelamar(pelamar.Id, perusahaan.Id, lowonganDipilih.Id);
        Database.Context.Lamarans.Add(lp);
        Database.Context.SaveChanges();

        Console.WriteLine("Lamaran berhasil diajukan!\n");
    }

    #endregion

    #region === Menu Perusahaan ===

    public static void PerusahaanMenu(Perusahaan perusahaan)
    {
        var menu = new Dictionary<string, MenuAction>
        {
            { "1", () => PostLowongan(perusahaan) },
            { "2", () => perusahaan.accPelamar(admin) },
            { "3", () => Perusahaan.getAllKaryawan(perusahaan) }
        };

        string pilihan;
        do
        {
            Menu.menuPerusahaan();
            pilihan = GetNonEmptyInput("Pilih: ");

            if (menu.TryGetValue(pilihan, out var action))
                action();
            else if (pilihan != "0")
                Console.WriteLine("Pilihan tidak tersedia.");

        } while (pilihan != "0");
    }

    static void PostLowongan(Perusahaan perusahaan)
    {
        var judul = GetNonEmptyInput("Posisi: ");
        var kriteria = GetNonEmptyInput("Kriteria: ");
        var deskripsi = GetNonEmptyInput("Deskripsi: ");
        var lokasi = GetNonEmptyInput("Lokasi: ");
        var gaji = GetNonEmptyInput("Gaji: ");

        var lowongan = new Lowongan(perusahaan.namaPerusahaan, judul, kriteria, deskripsi, lokasi, gaji);
        Database.Context.Lowongans.Add(lowongan);
        Database.Context.SaveChanges();

        Console.WriteLine("Lowongan berhasil diposting!\n");
    }

    #endregion

    #region === Menu Admin ===

    static void AdminMenu(Admin admin)
    {
        var menu = new Dictionary<string, MenuAction>
        {
            { "1", () => admin.Verifikasi(Database.Context.Perusahaans.ToList()) }
        };

        string pilihan;
        do
        {
            Menu.menuAdmin();
            pilihan = GetNonEmptyInput("Pilih: ");

            if (menu.TryGetValue(pilihan, out var action))
                action();
            else if (pilihan != "0")
                Console.WriteLine("Pilihan tidak tersedia.");

        } while (pilihan != "0");
    }

    #endregion
}
