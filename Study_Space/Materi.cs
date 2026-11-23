using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Space
{
    public partial class Materi : Form
    {
        public Materi()
        {
            InitializeComponent();

            // Berhenti otomatis hanya jika ini jendela terakhir yang ditutup.
            FormClosed += Navigasi.FormDitutup;

            // Event tombol dan tautan dipasang di kode agar Designer tetap sama persis.
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            label2.Click += label2_Click;
            label7.Click += label7_Click;

            // Contoh materi hanya untuk dibaca agar isinya tidak berubah saat diketik.
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
        }

        // Judul "Matematika" kembali ke daftar pelajaran.
        private void label3_Click(object? sender, EventArgs e)
        {
            KembaliKePelajaran();
        }

        // Tautan "< Semua pelajaran" melakukan hal yang sama.
        private void label2_Click(object? sender, EventArgs e)
        {
            KembaliKePelajaran();
        }

        // Kalimat pembahasan mengarahkan fokus ke contoh yang bersangkutan.
        private void label5_Click(object? sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void label6_Click(object? sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void label7_Click(object? sender, EventArgs e)
        {
            textBox4.Focus();
        }

        // Tombol "Keluar" menutup aplikasi setelah ada konfirmasi.
        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.Keluar();
        }

        // Tombol "Mulai Quiz" mengawali rangkaian tiga soal dari awal.
        private void button2_Click(object? sender, EventArgs e)
        {
            MulaiKuis();
        }

        // Tab "Materi" sudah aktif, jadi cukup mengembalikan fokus ke halaman ini.
        private void button3_Click(object? sender, EventArgs e)
        {
            AutoScrollPosition = Point.Empty;
            ActiveControl = button2;
        }

        // Tab "Quiz" berpindah ke soal pertama dan mengulang perhitungan skor.
        private void button4_Click(object? sender, EventArgs e)
        {
            MulaiKuis();
        }

        // Helper untuk kembali ke daftar pelajaran.
        private void KembaliKePelajaran()
        {
            Navigasi.Buka(this, new Pilih_Pelajaran());
        }

        // Helper untuk memulai kuis dari soal pertama dengan skor yang sudah dikosongkan.
        private void MulaiKuis()
        {
            SesiBelajar.MulaiKuis();
            Navigasi.Buka(this, new Quiz1());
        }
    }
}
