using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotKayıtSistemi
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmenGiris frmOgretmenGiris = new FrmOgretmenGiris();
            frmOgretmenGiris.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgrenciGiris frmOgrenciGiris = new FrmOgrenciGiris();
            frmOgrenciGiris.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
