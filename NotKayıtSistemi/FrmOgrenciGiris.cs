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
    public partial class FrmOgrenciGiris : Form
    {
        public FrmOgrenciGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=NotKayitVt;Integrated Security=True;");

        public string kullanici;

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Ogr where OgrKullaniciAdi=@p1 and OgrSifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);

            SqlDataReader sqlDataReader = komut.ExecuteReader();
            if (sqlDataReader.Read())
            {
                FrmOgrenciNotEkrani frmOgrenciNotEkrani = new FrmOgrenciNotEkrani(txtkullaniciAdi.Text);
                frmOgrenciNotEkrani.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre girişi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
            FrmKayitEkrani frmKayitEkrani = new FrmKayitEkrani();
            frmKayitEkrani.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmOgrenciGiris_Load(object sender, EventArgs e)
        {
            kullanici = txtkullaniciAdi.Text;
        }
    }
}
