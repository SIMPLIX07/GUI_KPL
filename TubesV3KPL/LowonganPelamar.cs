using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class LowonganPelamar
    {
        public int Id { get; set; }
        public int PelamarId { get; set; }
        public Pelamar Pelamar { get; set; }

        public int PerusahaanId { get; set; }
        public Perusahaan Perusahaan { get; set; }

        public int LowonganId { get; set; }
        public Lowongan Lowongan { get; set; }
        public string state { get; set; }

        public LowonganPelamar() { }

        public LowonganPelamar(int pelamarId, int perusahaanId, int lowonganId)
        {
            // Menginisialisasi ID pelamar yang melamar pekerjaan
            PelamarId = pelamarId;
            // Menginisialisasi ID perusahaan yang membuka lowongan
            PerusahaanId = perusahaanId;
            // Menginisialisasi ID lowongan yang dilamar oleh pelamar
            LowonganId = lowonganId;
            // Menetapkan status awal pelamar menjadi "Process" (proses seleksi)
            // Status ini menandakan bahwa pelamar masih dalam tahap seleksi
            this.state = "Process";
        }

        // Daftar statis untuk mengambil semua LowonganPelamar
        public static List<LowonganPelamar> semuaLowonganPelamar = Database.Context.Lamarans.ToList();

        // Getter untuk informasi entitas
        public string GetPerusahaanTertarik()
        {
            return Perusahaan.namaPerusahaan;
        }

        public string GetNamaPelamar()
        {
            return Pelamar.namaLengkap;
        }

        public string GetPosisi()
        {
            return Lowongan.kriteria;
        }

        public void getAllPelamarByPerusahaanId(List<LowonganPelamar> listlowongan, int id)
        {
            foreach (LowonganPelamar list in listlowongan)
            {
                if (list.Perusahaan.Id == id)
                {
                    Console.WriteLine("Nama: " + list.Pelamar.namaLengkap + "\nPosisi: " + list.Lowongan.title + " \nSkill: " + list.Pelamar.skill + " \nPengalaman: " + list.Pelamar.pengalaman);
                }

            }

        }

        public void Hire()
        {
            // Memeriksa apakah status saat ini adalah "Process" (masih dalam proses)
            if (state == "Process")
            {
                // Mengubah status pelamar menjadi "Hired" (diterima bekerja)
                state = "Hired";
                Console.WriteLine("Pelamar diterima bekerja.");

                // Mengakses konteks database
                var context = Database.Context;
                context.Lamarans.Attach(this);
                context.Entry(this).Property(x => x.state).IsModified = true;
                // Menyimpan perubahan ke dalam database
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Pelamar sudah berstatus Hired.");
            }
        }
        
        //
        public void Reject()
        {
            // Memeriksa apakah status saat ini adalah "Process" (masih dalam proses)
            if (state == "Process")
            {
                // Mengubah status pelamar menjadi "Rejected" (ditolak)
                state = "Rejected";
                Console.WriteLine("Pelamar ditolak.");

                try
                {
                    // Mengakses konteks database
                    var context = Database.Context;
                    context.Lamarans.Attach(this);
                    context.Entry(this).Property(x => x.state).IsModified = true;
                    // Menyimpan perubahan ke dalam database
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Jika terjadi kesalahan saat menyimpan status, tampilkan pesan error
                    Console.WriteLine(" Gagal menyimpan status penolakan.");
                    // Menampilkan pesan error yang lebih detail jika ada inner exception
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Detail error: " + ex.InnerException.Message);
                    }
                    else
                    {
                        // Menampilkan error utama jika tidak ada inner exception
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    // Mengembalikan status ke "Process" jika terjadi error
                    state = "Process";
                }
            }
        }

        public static void getLowonganPelamarById(int pelamarId)
        {
            List<LowonganPelamar> lowonganPelamar = Database.Context.Lamarans
                .Where(lp => lp.PelamarId == pelamarId)
                .ToList();

            if (lowonganPelamar.Count == 0)
            {
                Console.WriteLine("Belum ada lamaran yang diajukan.");
                return;
            }

            foreach (LowonganPelamar list in lowonganPelamar)
            {
                if (list.state == "Hired")
                {
                    Console.WriteLine($"Anda Diterima di Perusahaan: {list.Perusahaan.namaPerusahaan}\n");
                }
                else if (list.state == "Rejected")
                {
                    Console.WriteLine($"Anda Ditolak di Perusahaan: {list.Perusahaan.namaPerusahaan}\n");
                }
                else
                {
                    Console.WriteLine($"Lamaran Anda Masih Diproses di: {list.Perusahaan.namaPerusahaan}\n");
                }
            }
        }

    }
}
