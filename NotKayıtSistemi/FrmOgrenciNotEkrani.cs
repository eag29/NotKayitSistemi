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
    public partial class FrmOgrenciNotEkrani : Form
    {
        public string kullanici;

        public FrmOgrenciNotEkrani(string kullanici)
        {
            InitializeComponent();
            this.kullanici = kullanici;
            label1.Text = "Hoşgeldiniz: " + kullanici;
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=NotKayitVt;Integrated Security=True;");
        string ogrenciId = "";

        void OgrenciGetir()
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Ogr where OgrKullaniciAdi=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", kullanici);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                ogrenciId = dr[0].ToString();
                lblid.Text = ogrenciId;
            }
            baglanti.Close();
        }
        void NotGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Sinav1,Sinav2,Sinav3,Ort from Tbl_Not where Ogr=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", ogrenciId);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void FrmOgrenciNotEkrani_Load(object sender, EventArgs e)
        {
            OgrenciGetir();
            NotGetir();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
