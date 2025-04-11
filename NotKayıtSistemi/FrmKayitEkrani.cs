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

namespace NotKayıtSistemi
{
    public partial class FrmKayitEkrani : Form
    {
        public FrmKayitEkrani()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=NotKayitVt;Integrated Security=True;");

        void OgrenciKayit()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Ogr (OgrAdSoyad, OgrKullaniciAdi, OgrSifre) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtkullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p3", txtsifre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Kaydı Başarılı", "Kayıt İşlemi Tamamlanmıştır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void OgretmenKayit()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Ogrt (OgrtAdSoyad, OgrtKullaniciAdi, OgrtSifre) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtkullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p3", txtsifre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğretmen Kaydı Başarılı", "Kayıt İşlemi Tamamlanmıştır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void Temizle()
        {
            txtAd.Text = "";
            txtkullaniciAdi.Text = "";
            txtsifre.Text = "";
            rbOgr.Checked = false;
            rbOgrt.Checked = false; 
        }
        private void btnKayıt_Click(object sender, EventArgs e)
        {
            if (rbOgr.Checked == true)
            {
                OgrenciKayit();
                Temizle();
            }
            if (rbOgrt.Checked == true)
            {
                OgretmenKayit();
                Temizle();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
