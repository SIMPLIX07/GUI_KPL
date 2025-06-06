﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TubesV3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250516075315_FixAdminModel")]
    partial class FixAdminModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TubesV3.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("TubesV3.KaryawanPerusahaan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PelamarId")
                        .HasColumnType("int");

                    b.Property<int>("PerusahaanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PelamarId");

                    b.HasIndex("PerusahaanId");

                    b.ToTable("KaryawanPerusahaans");
                });

            modelBuilder.Entity("TubesV3.Lowongan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("deskripsi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("gaji")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("kriteria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("lokasi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("namaPerusahaan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Lowongans");
                });

            modelBuilder.Entity("TubesV3.LowonganPelamar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LowonganId")
                        .HasColumnType("int");

                    b.Property<int>("PelamarId")
                        .HasColumnType("int");

                    b.Property<int>("PerusahaanId")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LowonganId");

                    b.HasIndex("PelamarId");

                    b.HasIndex("PerusahaanId");

                    b.ToTable("Lamarans");
                });

            modelBuilder.Entity("TubesV3.Pelamar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("namaLengkap")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("pengalaman")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("skill")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pelamars");
                });

            modelBuilder.Entity("TubesV3.Perusahaan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int?>("AdminId1")
                        .HasColumnType("int");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("namaPerusahaan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nomorPerusahaan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("AdminId1");

                    b.ToTable("Perusahaans");
                });

            modelBuilder.Entity("TubesV3.KaryawanPerusahaan", b =>
                {
                    b.HasOne("TubesV3.Pelamar", "Pelamar")
                        .WithMany()
                        .HasForeignKey("PelamarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubesV3.Perusahaan", "Perusahaan")
                        .WithMany()
                        .HasForeignKey("PerusahaanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelamar");

                    b.Navigation("Perusahaan");
                });

            modelBuilder.Entity("TubesV3.LowonganPelamar", b =>
                {
                    b.HasOne("TubesV3.Lowongan", "Lowongan")
                        .WithMany()
                        .HasForeignKey("LowonganId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubesV3.Pelamar", "Pelamar")
                        .WithMany()
                        .HasForeignKey("PelamarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubesV3.Perusahaan", "Perusahaan")
                        .WithMany()
                        .HasForeignKey("PerusahaanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lowongan");

                    b.Navigation("Pelamar");

                    b.Navigation("Perusahaan");
                });

            modelBuilder.Entity("TubesV3.Perusahaan", b =>
                {
                    b.HasOne("TubesV3.Admin", null)
                        .WithMany("daftarPerusahaanVerified")
                        .HasForeignKey("AdminId");

                    b.HasOne("TubesV3.Admin", null)
                        .WithMany("queuePerusahaan")
                        .HasForeignKey("AdminId1");
                });

            modelBuilder.Entity("TubesV3.Admin", b =>
                {
                    b.Navigation("daftarPerusahaanVerified");

                    b.Navigation("queuePerusahaan");
                });
#pragma warning restore 612, 618
        }
    }
}
