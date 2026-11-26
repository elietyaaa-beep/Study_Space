using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Space
{
    public partial class HasilQuiz : Form
    {
        // Konstruktor tanpa argumen memakai skor sesi yang sedang berjalan.
        public HasilQuiz() : this(SesiBelajar.Skor, SesiBelajar.TotalSoal)
        {
        }

        // Konstruktor berisi data memudahkan penampilan hasil tanpa data hard-coded.
        public HasilQuiz(int skor, int total)
        {
            InitializeComponent();

            // Berhenti otomatis hanya jika ini jendela terakhir yang ditutup.
            FormClosed += Navigasi.FormDitutup;

            label6.Text = $"{skor}/{total}";
            label5.Text = PesanHasil(skor, total);

            // Dua tautan hasil sengaja tetap berupa Label sesuai desain.
            // Kursor tangan ditambahkan supaya terlihat bisa diklik.
            label2.Cursor = Cursors.Hand;
            label7.Cursor = Cursors.Hand;
            label8.Cursor = Cursors.Hand;

            // Event dipasang di kode agar file Designer tidak berubah.
            label2.Click += label2_Click;
            label7.Click += UlangiKuis;
            label8.Click += BacaMateri;
            button1.Click += button1_Click;
            button2.Click += BacaMateri;
            button3.Click += UlangiKuis;
        }

        // "Keluar" menutup aplikasi setelah pengguna menyetujui konfirmasi.
        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.Keluar();
        }

        // Tombol "Materi" dan tautan "Baca Materi" menuju halaman materi.
        private void BacaMateri(object? sender, EventArgs e)
        {
            Navigasi.Buka(this, new Materi());
        }

        // Tombol "Quiz" dan tautan "Ulangi Quiz" mengulang kuis dari soal pertama.
        private void UlangiKuis(object? sender, EventArgs e)
        {
            SesiBelajar.MulaiKuis();
            Navigasi.Buka(this, new Quiz1());
        }

        // Tautan "> Semua Pelajaran" kembali ke daftar pelajaran.
        private void label2_Click(object? sender, EventArgs e)
        {
            Navigasi.Buka(this, new Pilih_Pelajaran());
        }

        // Kalimat evaluasi tetap memakai teks desain untuk skor 2 dari 3.
        private static string PesanHasil(int skor, int total)
        {
            if (skor == total)
            {
                return "Luar biasa, semua jawabanmu tepat!";
            }

            if (skor >= 2)
            {
                return "Bagus! Baca materinya sekali lagi untuk hasil yang lebih baik.";
            }

            return "Baca materinya sekali lagi, lalu coba kuisnya kembali.";
        }

        private void HasilQuiz_Load(object sender, EventArgs e)
        {

        }
    }
}
