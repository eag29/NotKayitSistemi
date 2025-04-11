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
    public partial class FrmOgretmenNotEkrani : Form
    {
        public string kullanici;
        public FrmOgretmenNotEkrani(string kullanici)
        {
            InitializeComponent();
            this.kullanici = kullanici;
            label1.Text = "Hoşgeldiniz: " + kullanici;
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=NotKayitVt;Integrated Security=True;");

        void OrtalamaHesapla()
        {
            int sinav1, sinav2, sinav3, ort;
            sinav1 = Convert.ToInt32(txt2sinav1.Text);
            sinav2 = Convert.ToInt32(txt2sinav2.Text);
            sinav3 = Convert.ToInt32(txt2sinav3.Text);

            ort = (sinav1 + sinav2 + sinav3) / 3;
            lblOrt.Text = ort.ToString();
        }
        void NotListele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Not", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            baglanti.Close();
        }
        void OgrenciListele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select OgrID, OgrAdSoyad from Tbl_Ogr", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            baglanti.Close();
        }
        void NotEkle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Not (Sinav1,Sinav2,Sinav3,Ort,Ogr) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt2sinav1.Text);
            komut.Parameters.AddWithValue("@p2", txt2sinav2.Text);
            komut.Parameters.AddWithValue("@p3", txt2sinav3.Text);
            komut.Parameters.AddWithValue("@p4", lblOrt.Text);
            komut.Parameters.AddWithValue("@p5", txtid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("NOT EKLEME İŞLEMİ BAŞARILI", "İŞLEM TAMAMLANDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotListele();
            NotTemizle();
        }
        void NotSil()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From Tbl_Not where Ogr=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("KAYIT SİLİNMİŞTİR", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotTemizle();
            NotListele();
        }
        void NotGuncelle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Not set Sinav1=@p1, Sinav2=@p2, Sinav3=@p3, Ort=@p4 where Ogr=@p5", baglanti);
            komut.Parameters.AddWithValue("@p1", txt2sinav1.Text);
            komut.Parameters.AddWithValue("@p2", txt2sinav2.Text);
            komut.Parameters.AddWithValue("@p3", txt2sinav3.Text);
            OrtalamaHesapla();
            komut.Parameters.AddWithValue("@p4", lblOrt.Text);
            komut.Parameters.AddWithValue("@p5", txtid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Not Güncelleme Başarılı", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotListele();
            NotTemizle();
        }
        void NotTemizle()
        {
            txtid.Text = "";
            txt2sinav1.Text = "";
            txt2sinav2.Text = "";
            txt2sinav3.Text = "";
            lblOrt.Text = "";
        }
        private void FrmOgretmenNotEkrani_Load(object sender, EventArgs e)
        {
            NotListele();
            OgrenciListele();
        }
        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            NotEkle();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            NotSil();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            NotGuncelle();
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            NotTemizle();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt2sinav1.Text = dataGridView1.SelectedCells[e.RowIndex].ToString();
            txt2sinav2.Text = dataGridView1.SelectedCells[e.RowIndex].ToString();
            txt2sinav3.Text = dataGridView1.SelectedCells[e.RowIndex].ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrtalamaHesapla();
        }
    }
}
