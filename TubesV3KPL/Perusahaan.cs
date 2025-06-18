using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    /// <summary>
    /// Kelas Perusahaan mengimplementasikan IObserver untuk menerima notifikasi dari Pelamar.
    /// Menyimpan daftar karyawan dan lowongan, serta melakukan proses perekrutan.
    /// </summary>
    public class Perusahaan : IObserver
    {
        // Properti utama perusahaan
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string namaPerusahaan { get; set; }
        public string nomorPerusahaan { get; set; }
        public bool IsVerified { get; set; } = false;

        // Daftar statik untuk menyimpan data karyawan dan lowongan
        public static List<Pelamar> daftarKaryawan { get; set; } = new List<Pelamar>();
        public static List<Lowongan> daftarLowongan { get; set; } = new List<Lowongan>();

        /// <summary>
        /// Konstruktor default
        /// </summary>
        public Perusahaan() { }

        /// <summary>
        /// Konstruktor dengan parameter data perusahaan
        /// </summary>
        public Perusahaan(string username, string password, string namaPerusahaan, string nomorPerusahaan)
        {
            this.username = username;
            this.password = password;
            this.namaPerusahaan = namaPerusahaan;
            this.nomorPerusahaan = nomorPerusahaan;
        }

        /// <summary>
        /// Menambahkan pelamar yang diterima ke daftar karyawan
        /// </summary>
        public static void addKaryawan(Pelamar karyawan)
        {
            daftarKaryawan.Add(karyawan);
        }

        /// <summary>
        /// Menambahkan lowongan baru ke daftar lowongan perusahaan
        /// </summary>
        public static void addLowongan(Lowongan lowongan)
        {
            daftarLowongan.Add(lowongan);
        }

        /// <summary>
        /// Menampilkan semua karyawan milik perusahaan berdasarkan ID-nya
        /// </summary>
        public static void getAllKaryawan(Perusahaan perusahaan)
        {
            List<KaryawanPerusahaan> karyawan = Database.Context.KaryawanPerusahaans
                .Include(k => k.Pelamar)
                .Include(k => k.Perusahaan)
                .Where(k => k.Perusahaan.Id == perusahaan.Id)
                .ToList();

            foreach (var daftar in karyawan)
            {
                if (daftar.Pelamar != null && daftar.Perusahaan != null)
                {
                    Console.WriteLine("Nama: " + daftar.Pelamar.namaLengkap);
                    Console.WriteLine("Skill: " + daftar.Pelamar.skill);
                    Console.WriteLine("Pengalaman: " + daftar.Pelamar.pengalaman);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Data pelamar atau perusahaan tidak lengkap (null).");
                }
            }
        }

        /// <summary>
        /// Implementasi method observer, menerima notifikasi dari pelamar yang statusnya berubah
        /// </summary>
        public void Update(Pelamar pelamar)
        {
            Console.WriteLine($"Perusahaan {namaPerusahaan} diberitahu: Pelamar {pelamar.namaLengkap} statusnya berubah menjadi {pelamar.state}.");
        }

        /// <summary>
        /// Method untuk menerima atau menolak pelamar dari admin
        /// </summary>
        public void accPelamar(Admin admin)
        {
            // Ambil semua lamaran untuk perusahaan ini yang masih dalam proses
            List<LowonganPelamar> pelamars = Database.Context.Lamarans
                .Include(l => l.Pelamar)
                .Include(l => l.Lowongan)
                .Include(l => l.Perusahaan)
                .Where(l => l.PerusahaanId == this.Id && l.state == "Process")
                .ToList();

            if (pelamars.Count == 0)
            {
                Console.WriteLine("Belum ada pelamar.");
                return;
            }

            // Tampilkan seluruh pelamar
            var listView = new LowonganPelamar();
            listView.getAllPelamarByPerusahaanId(pelamars, this.Id);

            Console.WriteLine("1. Rekrut \n2. Delete \n0. Keluar");
            string input = Console.ReadLine();

            while (input != "0")
            {
                switch (input)
                {
                    case "1": // Rekrut pelamar
                        Console.Write("Masukkan nama pelamar yang ingin direkrut: ");
                        string namaRekrut = Console.ReadLine();

                        Pelamar pelamar = Database.Context.Pelamars
                            .FirstOrDefault(p => p.namaLengkap.ToLower() == namaRekrut.ToLower());

                        if (pelamar != null)
                        {
                            var lamaran = Database.Context.Lamarans
                                .FirstOrDefault(l => l.PelamarId == pelamar.Id && l.PerusahaanId == this.Id);

                            if (lamaran != null)
                            {
                                // Pasang observer dan update status pelamar
                                pelamar.Attach(admin);
                                pelamar.Attach(this);
                                pelamar.Notify();
                                pelamar.Hire();
                                lamaran.Hire();

                                // Tambah ke tabel karyawan perusahaan
                                KaryawanPerusahaan newKaryawan = new KaryawanPerusahaan(pelamar.Id, this.Id);
                                Database.Context.KaryawanPerusahaans.Add(newKaryawan);
                                Database.Context.SaveChanges();

                                Console.WriteLine("Pelamar berhasil direkrut.");
                            }
                            else
                            {
                                Console.WriteLine("Lamaran tidak ditemukan.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pelamar tidak ditemukan.");
                        }
                        break;

                    case "2": // Tolak pelamar
                        Console.Write("Masukkan nama pelamar yang ingin dihapus: ");
                        string namaHapus = Console.ReadLine();

                        Pelamar pelamarDelete = Database.Context.Pelamars
                            .FirstOrDefault(p => p.namaLengkap.ToLower() == namaHapus.ToLower());

                        if (pelamarDelete != null)
                        {
                            var lamaranToDelete = Database.Context.Lamarans
                                .FirstOrDefault(l => l.PelamarId == pelamarDelete.Id && l.PerusahaanId == this.Id);

                            if (lamaranToDelete != null)
                            {
                                lamaranToDelete.Reject();
                                Database.Context.SaveChanges();

                                Console.WriteLine("Lamaran berhasil ditolak dan dihapus.");
                            }
                            else
                            {
                                Console.WriteLine("Lamaran tidak ditemukan.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pelamar tidak ditemukan.");
                        }
                        break;

                    default:
                        Console.WriteLine("Menu tidak valid.");
                        break;
                }

                // Tampilkan ulang menu
                Console.WriteLine("1. Rekrut \n2. Delete \n0. Keluar");
                input = Console.ReadLine();
            }
        }
    }
}
