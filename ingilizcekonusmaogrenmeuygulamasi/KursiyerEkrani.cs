using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ingilizcekonusmaogrenmeuygulamasi
{
    public partial class KursiyerEkrani : Form
    {
        public KursiyerEkrani()
        {
            InitializeComponent();
        }
        İngilizceKonusmaOgrenmeUygulamasiEntities baglan=new İngilizceKonusmaOgrenmeUygulamasiEntities();
        private void KursiyerEkrani_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglan.Kursiyerlers.ToList();
            comboBox1.ValueMember = "Kursiyerdilseviyesi";
        }
        public void Listele()
        {
            dataGridView1.DataSource = baglan.Kursiyerlers.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kursiyerler save=new Kursiyerler();
            save.KursiyerAdSoyad = textBox1.Text;
            save.KursiyerTelefon= textBox2.Text;
            save.KursiyerAdres = textBox3.Text;
            save.KursiyerDilSeviyesi = comboBox1.Text;
            baglan.Kursiyerlers.Add(save);
            baglan.SaveChanges();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int KursiyerNo = Convert.ToInt32(textBox1.Tag);
            var update = baglan.Kursiyerlers.Where(x => x.KursiyerNo == KursiyerNo).FirstOrDefault();
            
            update.KursiyerAdSoyad= textBox1.Text;
            update.KursiyerTelefon= textBox2.Text;
            update.KursiyerAdres= textBox3.Text;
            update.KursiyerDilSeviyesi= comboBox1.Text;
            
            baglan.SaveChanges();
            Listele();
        }
        //sil butonu
        private void button4_Click(object sender, EventArgs e)
        {
            int KursiyerNo=Convert.ToInt32(textBox1.Tag);
            var sil = baglan.Kursiyerlers.Where(x => x.KursiyerNo == KursiyerNo).FirstOrDefault();
            baglan.Kursiyerlers.Remove(sil);
            baglan.SaveChanges();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=baglan.Kursiyerlers.Where(s=>s.KursiyerAdSoyad.Contains(textBox1.Text)).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["kursiyerNo"].Value.ToString();
            textBox1.Text = satir.Cells["kursiyeradsoyad"].Value.ToString();
            textBox2.Text = satir.Cells["kursiyertelefon"].Value.ToString();
            textBox3.Text = satir.Cells["kursiyeradres"].Value.ToString();
            comboBox1.Text = satir.Cells["kursiyerdilseviyesi"].Value.ToString();
        }
    }
}
