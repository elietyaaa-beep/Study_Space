namespace Study_Space
{
    internal static class Program
    {
        // Titik masuk aplikasi. Sesuai desain yang ada, hanya form Login yang tampil saat startup.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Login ditampilkan manual. Application.Run() tanpa form utama penting supaya
            // aplikasi tidak ikut berhenti saat Login ditutup untuk pindah ke halaman lain.
            Login halamanAwal = new Login();
            halamanAwal.Show();
            Application.Run();
        }
    }

    // Data sesi yang dipakai bersama oleh seluruh form.
    // Dibuat static supaya nilainya tetap ada walaupun form kuis ditutup dan diganti.
    internal static class SesiBelajar
    {
        // Jumlah soal mengikuti tiga form kuis pada desain, yaitu Quiz1, quiz2, dan Quiz3.
        public const int TotalSoal = 3;

        // Nilai awal 2 diambil dari teks desain "Skor terbaik 2/3" pada kartu Matematika.
        private static int skorTerbaik = 2;

        // Skor kuis yang sedang berjalan, dihitung ulang setiap kali kuis dimulai.
        public static int Skor { get; private set; }

        // Skor tertinggi yang pernah diraih pengguna.
        public static int SkorTerbaik => skorTerbaik;

        // Teks kartu pelajaran, misalnya "Skor terbaik 2/3".
        public static string TeksSkorTerbaik => $"Skor terbaik {skorTerbaik}/{TotalSoal}";

        // Mengosongkan skor sebelum rangkaian tiga soal dimulai.
        public static void MulaiKuis()
        {
            Skor = 0;
        }

        // Menambah satu poin hanya jika jawaban yang dipilih benar.
        public static void CatatJawaban(bool benar)
        {
            if (benar)
            {
                Skor++;
            }
        }

        // Menyimpan skor terbaik setelah soal terakhir selesai dijawab.
        public static void SelesaikanKuis()
        {
            if (Skor > skorTerbaik)
            {
                skorTerbaik = Skor;
            }
        }
    }

    // Aksi navigasi umum supaya perpindahan antarform konsisten di semua halaman.
    internal static class Navigasi
    {
        // Menampilkan form tujuan lebih dulu, lalu menutup form saat ini.
        public static void Buka(Form saatIni, Form tujuan)
        {
            tujuan.Show();
            saatIni.Close();
        }

        // Menandai bahwa penutupan berasal dari tombol Keluar, bukan dari klik X.
        private static bool sedangKeluar;

        // Tombol Keluar menutup aplikasi hanya jika pengguna menyetujui konfirmasi.
        public static void Keluar()
        {
            DialogResult jawaban = MessageBox.Show(
                "Yakin ingin keluar dari Study Space?",
                "Keluar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (jawaban == DialogResult.Yes)
            {
                sedangKeluar = true;
                Application.Exit();
            }
        }

        // Dipanggil setiap form ditutup. Aplikasi berhenti hanya jika tidak ada
        // form yang tersisa, misalnya ketika pengguna menutup jendela terakhir.
        public static void FormDitutup(object? sender, FormClosedEventArgs e)
        {
            if (!sedangKeluar && Application.OpenForms.Count == 0)
            {
                sedangKeluar = true;
                Application.Exit();
            }
        }
    }
}
