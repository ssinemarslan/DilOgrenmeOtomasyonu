using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ingilizcekonusmaogrenmeuygulamasi
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog =İngilizceKonusmaOgrenmeUygulamasi;Integrated security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from Kullanicilar where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", baglan);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                KategorilerEkrani go = new KategorilerEkrani();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("İşlem başarısız tekrar deneyiniz");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
