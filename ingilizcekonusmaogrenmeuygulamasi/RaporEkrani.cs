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
    public partial class RaporEkrani : Form
    {
        public RaporEkrani()
        {
            InitializeComponent();
        }
        İngilizceKonusmaOgrenmeUygulamasiEntities baglan=new İngilizceKonusmaOgrenmeUygulamasiEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //kursiyerleri seviyesine göre sırala
            var query = from Kursiyer in baglan.Kursiyerlers
                        select new
                        {
                            Kursiyer.KursiyerAdSoyad,
                            Kursiyer.KursiyerDilSeviyesi
                        };


            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //egitmenleri uzmanlaştığı konuya göre sırala
            var query = from egitmen in baglan.Egitmenlers
                        select new
                        {
                            egitmen.EgitmenAdSoyad,
                            egitmen.EgitmenUzmanlastigiKonu
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = baglan.Egitmenlers.Where(egitmen => egitmen.EgitmenUzmanlastigiKonu == "Reading");
            dataGridView1.DataSource= query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = baglan.Egitmenlers.Where(egitmen => egitmen.EgitmenAdres == "Kadıköy");
            dataGridView1.DataSource= query.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var query = baglan.Kursiyerlers.Where(kursiyer => kursiyer.KursiyerAdres == "Ataşehir");
            dataGridView1.DataSource=query.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {//kursiyer ve egitmen bilgileri
            var query = from kursiyer in baglan.Kursiyerlers
                        join egitmen in baglan.Egitmenlers on kursiyer.KursiyerNo equals egitmen.KursiyerNo
                        select new
                        {
                            kursiyer.KursiyerAdSoyad,
                            kursiyer.KursiyerTelefon,
                            kursiyer.KursiyerAdres,
                            kursiyer.KursiyerDilSeviyesi,
                            egitmen.EgitmenAdSoyad,
                            egitmen.EgitmenTelefon,
                            egitmen.EgitmenAdres,
                            egitmen.EgitmenUzmanlastigiKonu
                        };
            dataGridView1.DataSource=query.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var query = from kursiyer in baglan.Kursiyerlers
                        join egitmen in baglan.Egitmenlers on kursiyer.KursiyerNo equals egitmen.KursiyerNo
                        select new
                        {
                            kursiyer.KursiyerAdSoyad,
                            kursiyer.KursiyerDilSeviyesi,
                            egitmen.EgitmenAdSoyad,
                            egitmen.EgitmenUzmanlastigiKonu
                        };
            dataGridView1.DataSource = query.ToList();
        }
    }
}
