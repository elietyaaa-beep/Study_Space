using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Space
{
    public partial class quiz2 : Form
    {
        // Kunci jawaban mengikuti warna hijau pada desain, yaitu tombol 6 "60%".
        private const string PembahasanBenar = "Tepat sekali, 3÷5= 0,6, lalu x100= 60%";
        private const string PembahasanSalah = "Belum tepat, 3÷5= 0,6, lalu x100= 60%";

        // Pencegah pengguna menjawab dua kali pada soal yang sama.
        private bool sudahDijawab;

        public quiz2()
        {
            InitializeComponent();

            // Berhenti otomatis hanya jika ini jendela terakhir yang ditutup.
            FormClosed += Navigasi.FormDitutup;

            // Event yang belum terhubung di Designer dipasang melalui kode ini.
            button1.Click += button1_Click;
            button4.Click += PilihJawaban;
            button5.Click += PilihJawaban;
            button6.Click += PilihJawaban;
            button7.Click += PilihJawaban;
            button9.Click += button9_Click;
        }

        // "Keluar" menutup aplikasi setelah pengguna menyetujui konfirmasi.
        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.Keluar();
        }

        // Tombol "Materi" yang sudah terhubung di Designer membuka materi lagi.
        private void button2_Click(object? sender, EventArgs e)
        {
            Navigasi.Buka(this, new Materi());
        }

        // Tautan "<Semua pelajaran" kembali ke daftar pelajaran.
        private void label2_Click(object? sender, EventArgs e)
        {
            Navigasi.Buka(this, new Pilih_Pelajaran());
        }

        // Tautan "÷Matematika" kembali ke halaman materi.
        private void label3_Click(object? sender, EventArgs e)
        {
            Navigasi.Buka(this, new Materi());
        }

        // Tombol "Quiz" mengulang kuis dari soal pertama.
        private void button3_Click(object? sender, EventArgs e)
        {
            SesiBelajar.MulaiKuis();
            Navigasi.Buka(this, new Quiz1());
        }

        // Tombol "Lanjut" membuka soal ketiga setelah satu jawaban dipilih.
        private void button9_Click(object? sender, EventArgs e)
        {
            if (!sudahDijawab)
            {
                MessageBox.Show("Pilih salah satu jawaban dulu sebelum lanjut.", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Navigasi.Buka(this, new Quiz3());
        }

        // Memeriksa pilihan pengguna, menyimpan poin, lalu menampilkan pembahasan.
        private void PilihJawaban(object? sender, EventArgs e)
        {
            if (sudahDijawab)
            {
                return;
            }

            sudahDijawab = true;
            bool benar = ReferenceEquals(sender, button6);

            SesiBelajar.CatatJawaban(benar);
            label8.Text = benar ? PembahasanBenar : PembahasanSalah;
            label8.ForeColor = benar ? Color.Green : Color.IndianRed;
        }
    }
}
