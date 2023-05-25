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
    public partial class EgitmenEkrani : Form
    {
        public EgitmenEkrani()
        {
            InitializeComponent();
        }
        İngilizceKonusmaOgrenmeUygulamasiEntities baglan=new İngilizceKonusmaOgrenmeUygulamasiEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            dataGridView1.DataSource = baglan.Egitmenlers.ToList();
        }
        //kaydet ekle butonu
        private void button2_Click(object sender, EventArgs e)
        {
            Egitmenler save = new Egitmenler();
            save.EgitmenAdSoyad = textBox1.Text;
            save.EgitmenTelefon = textBox2.Text;
            save.EgitmenAdres = textBox3.Text;
            save.EgitmenUzmanlastigiKonu = comboBox1.Text;
            save.KursiyerNo = Convert.ToInt32(comboBox2.Text);
            baglan.Egitmenlers.Add(save);
            baglan.SaveChanges();
            Listele();
        }
        //sil butonu
        private void button4_Click(object sender, EventArgs e)
        {
            int EgitmenNo = Convert.ToInt32(textBox1.Tag);
            var sil = baglan.Egitmenlers.Where(x => x.EgitmenNo == EgitmenNo).FirstOrDefault();
            baglan.Egitmenlers.Remove(sil);
            baglan.SaveChanges();
            Listele();
        }
        //yenile butonu
        private void button3_Click(object sender, EventArgs e)
        {
            int EgitmenNo = Convert.ToInt32(textBox1.Tag);
            var update = baglan.Egitmenlers.Where(x => x.EgitmenNo == EgitmenNo).FirstOrDefault();

            update.EgitmenAdSoyad = textBox1.Text;
            update.EgitmenTelefon = textBox2.Text;
            update.EgitmenAdres = textBox3.Text;
            update.EgitmenUzmanlastigiKonu = comboBox1.Text;
            update.KursiyerNo = Convert.ToInt32(comboBox2.Text);
            
            baglan.SaveChanges();
            Listele();
        }
        //ara butonu
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=baglan.Egitmenlers.Where(s=>s.EgitmenAdSoyad.Contains(textBox1.Text)).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["EgitmenNo"].Value.ToString();
            textBox1.Text = satir.Cells["egitmenadsoyad"].Value.ToString();
            textBox2.Text = satir.Cells["egitmentelefon"].Value.ToString();
            textBox3.Text = satir.Cells["egitmenadres"].Value.ToString();
            comboBox1.Text = satir.Cells["egitmenuzmanlastigikonu"].Value.ToString();
            comboBox2.Text = satir.Cells["kursiyerno"].Value.ToString();
        }

        private void EgitmenEkrani_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglan.Egitmenlers.ToList();
            comboBox1.ValueMember = "egitmenuzmanlastigikonu";
            comboBox2.DataSource=baglan.Kursiyerlers.ToList();
            comboBox2.ValueMember = "kursiyerno";
        }
    }
}
