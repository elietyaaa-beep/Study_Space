using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Space
{
    public partial class Quiz1 : Form
    {
        // Kunci jawaban mengikuti warna hijau pada desain, yaitu tombol 5 "50%".
        private const string PembahasanBenar = "Tepat sekali, 1÷2= 0,5, lalu x100= 50%";
        private const string PembahasanSalah = "Belum tepat. 1÷2 = 0,5, lalu x100 = 50%.";

        // Pencegah pengguna menjawab dua kali pada soal yang sama.
        private bool sudahDijawab;

        public Quiz1()
        {
            InitializeComponent();

            // Berhenti otomatis hanya jika ini jendela terakhir yang ditutup.
            FormClosed += Navigasi.FormDitutup;

            // Seluruh event dipasang di sini supaya file Designer tidak berubah.
            button1.Click += button1_Click;
            button4.Click += PilihJawaban;
            button5.Click += PilihJawaban;
            button6.Click += PilihJawaban;
            button7.Click += PilihJawaban;
            button8.Click += button8_Click;
            button9.Click += button9_Click;
            button10.Click += button10_Click;
            label2.Click += label2_Click;
            label3.Click += label3_Click;
        }

        // "Keluar" menutup aplikasi setelah pengguna menyetujui konfirmasi.
        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.Keluar();
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

        // Tombol "Materi" juga membuka kembali halaman materi.
        private void button8_Click(object? sender, EventArgs e)
        {
            Navigasi.Buka(this, new Materi());
        }

        // Tombol "Lanjut" membuka soal kedua setelah satu jawaban dipilih.
        private void button9_Click(object? sender, EventArgs e)
        {
            if (!sudahDijawab)
            {
                MessageBox.Show("Pilih salah satu jawaban dulu sebelum lanjut.", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Navigasi.Buka(this, new quiz2());
        }

        // Tombol "Quiz" mengulang kuis dari soal pertama.
        private void button10_Click(object? sender, EventArgs e)
        {
            SesiBelajar.MulaiKuis();
            Navigasi.Buka(this, new Quiz1());
        }

        // Memeriksa pilihan pengguna, menyimpan poin, lalu menampilkan pembahasan.
        private void PilihJawaban(object? sender, EventArgs e)
        {
            if (sudahDijawab)
            {
                return;
            }

            sudahDijawab = true;
            bool benar = ReferenceEquals(sender, button5);

            SesiBelajar.CatatJawaban(benar);
            label8.Text = benar ? PembahasanBenar : PembahasanSalah;
            label8.ForeColor = benar ? Color.Green : Color.IndianRed;
        }
    }
}
