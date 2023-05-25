using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ingilizcekonusmaogrenmeuygulamasi
{
    public partial class KonuEkrani : Form
    {
        public KonuEkrani()
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
            dataGridView1.DataSource = baglan.Konulars.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Konular save = new Konular();
            save.KonuAdi = textBox1.Text;
            save.EgitmenNo = Convert.ToInt32(comboBox1.Text);
            baglan.Konulars.Add(save);
            baglan.SaveChanges();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int KonuNo = Convert.ToInt32(textBox1.Tag);
            var update = baglan.Konulars.Where(x => x.KonuNo == KonuNo).FirstOrDefault();

            update.KonuAdi = textBox1.Text;
            update.EgitmenNo = Convert.ToInt32(comboBox1.Text);
            baglan.Konulars.Add(update);
            baglan.SaveChanges();
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int KonuNo = Convert.ToInt32(textBox1.Tag);
            var sil = baglan.Konulars.Where(x => x.KonuNo == KonuNo).FirstOrDefault();
            baglan.Konulars.Remove(sil);
            baglan.SaveChanges();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglan.Konulars.Where(s => s.KonuAdi.Contains(textBox1.Text)).ToList();
        }

        private void KonuEkrani_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglan.Egitmenlers.ToList();
            comboBox1.ValueMember = "egitmenno";
        }
    }
}
