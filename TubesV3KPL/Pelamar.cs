using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    /// <summary>
    /// Kelas Pelamar mewakili entitas pencari kerja yang memiliki relasi observer.
    /// </summary>
    public class Pelamar
    {
        // Daftar observer yang akan diberi notifikasi ketika status pelamar berubah
        private List<IObserver> _observers = new List<IObserver>();

        // Properti utama dari Pelamar
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string namaLengkap { get; set; }
        public bool status { get; set; } // status = true jika sudah diterima
        public string state { get; set; } // state bisa berupa "Registered", "Hired", atau "Rejected"
        public string skill { get; set; }
        public string pengalaman { get; set; }

        /// <summary>
        /// Konstruktor default
        /// </summary>
        public Pelamar() { }

        /// <summary>
        /// Konstruktor dengan parameter input saat pendaftaran
        /// </summary>
        public Pelamar(string username, string password, string namaLengkap, string skill, string pengalaman)
        {
            this.username = username;
            this.password = password;
            this.namaLengkap = namaLengkap;
            this.skill = skill;
            this.pengalaman = pengalaman;
            this.status = false; // default belum bekerja
            this.state = "Registered"; // default state saat pendaftaran
        }

        /// <summary>
        /// Menambahkan observer ke pelamar
        /// </summary>
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// Menghapus observer dari pelamar
        /// </summary>
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// Memberi notifikasi ke semua observer terkait perubahan state pelamar
        /// </summary>
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        /// <summary>
        /// Menampilkan semua lowongan kerja (dari helper class lain)
        /// </summary>
        public static void getAllLowongan()
        {
            ListLowonganPerusahaan.getAllLowongan();
        }

        /// <summary>
        /// Menandai pelamar sebagai diterima kerja, mengubah state dan mengirim notifikasi ke observer
        /// </summary>
        public void Hire()
        {
            if (state == "Registered")
            {
                state = "Hired";
                status = true;
                Console.WriteLine($"{namaLengkap} diterima bekerja.");
                Notify();
            }
            else
            {
                Console.WriteLine($"{namaLengkap} sudah berstatus {state}.");
            }
        }

        /// <summary>
        /// Menampilkan state/status pelamar saat ini
        /// </summary>
        public void PrintStatus()
        {
            Console.WriteLine($"Status {namaLengkap}: {state}");
        }

        /// <summary>
        /// Menolak pelamar, mengubah state menjadi "Rejected"
        /// </summary>
        public void Reject()
        {
            state = "Rejected";
            status = false;
            Console.WriteLine($"Pelamar {namaLengkap} telah ditolak (state = Rejected).");
        }
    }
}
