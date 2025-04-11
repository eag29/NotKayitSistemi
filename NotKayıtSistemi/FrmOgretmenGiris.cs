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
    public partial class FrmOgretmenGiris : Form
    {
        public FrmOgretmenGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=NotKayitVt;Integrated Security=True;");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Ogrt where OgrtKullaniciAdi=@p1 and OgrtSifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);

            SqlDataReader sqlDataReader = komut.ExecuteReader();
            if (sqlDataReader.Read())
            {
                FrmOgretmenNotEkrani frmOgretmenNotEkrani = new FrmOgretmenNotEkrani(txtkullaniciAdi.Text);
                frmOgretmenNotEkrani.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre girişi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
        private void btnKayıt_Click(object sender, EventArgs e)
        {
            FrmKayitEkrani frmKayitEkrani = new FrmKayitEkrani();
            frmKayitEkrani.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
