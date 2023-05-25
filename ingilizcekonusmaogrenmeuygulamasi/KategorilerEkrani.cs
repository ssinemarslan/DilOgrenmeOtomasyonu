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
    public partial class KategorilerEkrani : Form
    {
        public KategorilerEkrani()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            EgitmenEkrani e1 = new EgitmenEkrani();
            this.Hide();
            e1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            KursiyerEkrani k1 = new KursiyerEkrani();
            this.Hide();
            k1.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            KonuEkrani k2 = new KonuEkrani();
            this.Hide();
            k2.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           RaporEkrani r1=new RaporEkrani();
            this.Hide();
            r1.Show();
        }
    }
}
