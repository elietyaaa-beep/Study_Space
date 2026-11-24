using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Space
{
    public partial class Pilih_Pelajaran : Form
    {
        public Pilih_Pelajaran()
        {
            InitializeComponent();

            // Berhenti otomatis hanya jika ini jendela terakhir yang ditutup.
            FormClosed += Navigasi.FormDitutup;

            // Menghubungkan event yang belum ada di Designer tanpa mengubah tampilan form.
            Load += Pilih_Pelajaran_Load;
            button1.Click += button1_Click;

            // Seluruh bagian kartu Matematika membuka materi, kecuali label skor yang
            // menampilkan penjelasan nilai. Kartu lain belum punya materi di desain.
            SambungKartu(BukaMateri, flowLayoutPanel9, pictureBox3, label2, label5);
            SambungKartu(() => TampilkanBelumTersedia("IPA"), flowLayoutPanel7, pictureBox4, label7, label8, label9);
            SambungKartu(() => TampilkanBelumTersedia("Bahasa Inggris"), flowLayoutPanel8, pictureBox5, label10, label11, label12);
            SambungKartu(() => TampilkanBelumTersedia("Sejarah"), flowLayoutPanel10, pictureBox6, label13, label14, label15);

            label6.Cursor = Cursors.Hand;
        }

        // Ketika form tampil, teks skor mengikuti hasil kuis terakhir yang tersimpan.
        private void Pilih_Pelajaran_Load(object? sender, EventArgs e)
        {
            label6.Text = SesiBelajar.TeksSkorTerbaik;
        }

        // Tombol "Keluar" meminta konfirmasi sebelum menutup aplikasi.
        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.Keluar();
        }

        // Judul "Matematika" pada kartu pertama membuka halaman materi.
        private void label2_Click(object? sender, EventArgs e)
        {
            BukaMateri();
        }

        // Label skor menampilkan penjelasan singkat mengenai nilai terbaik pengguna.
        private void label6_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                $"Skor terbaik kamu di pelajaran Matematika adalah {SesiBelajar.SkorTerbaik}/{SesiBelajar.TotalSoal}.",
                "Skor Terbaik",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Judul "IPA" pada kartu kedua memberi tahu bahwa materinya belum tersedia.
        private void label7_Click(object? sender, EventArgs e)
        {
            TampilkanBelumTersedia("IPA");
        }

        // Memasang satu aksi ke seluruh kontrol yang masih berada di dalam satu kartu.
        private static void SambungKartu(Action aksi, params Control[] kontrol)
        {
            foreach (Control item in kontrol)
            {
                item.Cursor = Cursors.Hand;
                item.Click += (sender, e) => aksi();
            }
        }

        // Membuka materi Matematika sesuai isi yang sudah ada di desain.
        private void BukaMateri()
        {
            Navigasi.Buka(this, new Materi());
        }

        // Tidak ada materi dan kuis untuk tiga pelajaran lain pada desain yang ada,
        // jadi pengguna diberi keterangan yang jujur, bukan dibawa ke halaman kosong.
        private static void TampilkanBelumTersedia(string pelajaran)
        {
            MessageBox.Show(
                $"Materi dan kuis {pelajaran} belum tersedia. Saat ini yang bisa dipelajari adalah Matematika.",
                "Belum tersedia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void Pilih_Pelajaran_Load_1(object sender, EventArgs e)
        {

        }
    }
}
