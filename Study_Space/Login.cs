namespace Study_Space
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Berhenti otomatis hanya jika ini jendela terakhir yang ditutup.
            FormClosed += Navigasi.FormDitutup;

            // Event ini dipasang di kode supaya file Designer tidak perlu diubah.
            // Enter pada kedua kolom langsung menjalankan Login, bukan menambah baris.
            textBox1.KeyDown += textBoxKunci_KeyDown;
            textBox2.KeyDown += textBoxKunci_KeyDown;
            textBox2.TextChanged += textBox2_TextChanged;
        }

        // Panel ini hanya berfungsi sebagai wadah visual, jadi tidak ada gambar kustom.
        private void panel1_Paint(object? sender, PaintEventArgs e)
        {
        }

        // Kolom email didesain multiline. Buang karakter enter agar isinya tetap satu baris.
        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
            HapusBarisBaru(textBox1);
        }

        // Perlakuan yang sama untuk kolom kata sandi.
        private void textBox2_TextChanged(object? sender, EventArgs e)
        {
            HapusBarisBaru(textBox2);
        }

        // Judul, subjudul, dan label "Email" mengarahkan fokus ke kolom email.
        private void label1_Click(object? sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void label3_Click(object? sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void label2_Click(object? sender, EventArgs e)
        {
            textBox1.Focus();
        }

        // Label "Kata Sandi" mengarahkan fokus ke kolom kata sandi.
        private void label4_Click(object? sender, EventArgs e)
        {
            textBox2.Focus();
        }

        // Saat form pertama tampil, siapkan sesi baru dan mulai dari kolom email.
        private void Login_Load(object? sender, EventArgs e)
        {
            SesiBelajar.MulaiKuis();
            ActiveControl = textBox1;
        }

        // Tombol Login memeriksa kelengkapan input sebelum membuka daftar pelajaran.
        private void button1_Click(object? sender, EventArgs e)
        {
            CobaLogin();
        }

        // Tekan Enter dari dalam kolom teks memanggil prosedur login yang sama.
        private void textBoxKunci_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CobaLogin();
            }
        }

        // Menghapus enter yang muncul karena kedua kolom berstatus multiline di desain.
        private static void HapusBarisBaru(TextBox kolom)
        {
            if (!kolom.Text.Contains("\r") && !kolom.Text.Contains("\n"))
            {
                return;
            }

            int posisiKursor = kolom.SelectionStart;
            kolom.Text = kolom.Text.Replace("\r", string.Empty).Replace("\n", string.Empty);
            kolom.SelectionStart = Math.Min(posisiKursor, kolom.Text.Length);
        }

        // Desain tidak menyediakan basis data pengguna, sehingga validasi hanya
        // memastikan email berformat wajar dan kata sandi tidak kosong.
        private void CobaLogin()
        {
            string email = textBox1.Text.Trim();
            string kataSandi = textBox2.Text.Trim();

            if (email.Length == 0)
            {
                MessageBox.Show("Email belum diisi.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Format email belum benar. Contoh: siswa@sekolah.com", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (kataSandi.Length == 0)
            {
                MessageBox.Show("Kata sandi belum diisi.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            Navigasi.Buka(this, new Pilih_Pelajaran());
        }
    }
}
