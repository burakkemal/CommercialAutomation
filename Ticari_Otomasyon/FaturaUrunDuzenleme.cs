using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FaturaUrunDuzenleme : Form
    {
        public FaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        public string urunid;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtürünid.Text = urunid;
            SqlCommand komut = new SqlCommand("Select * fROM tbl_faturadetay where FaturaurunID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtürünid.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtürünad.Text = dr[1].ToString();
                txtmiktar.Text = dr[2].ToString();
                txtfiyat.Text = dr[3].ToString();
                txttutar.Text = dr[4].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_faturadetay set URUN=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 WHERE FATURAURUNID=@P5", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtürünad.Text);
            komut.Parameters.AddWithValue("@P2", txtmiktar.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(txtfiyat.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse(txttutar.Text));
            komut.Parameters.AddWithValue("@P5", txtürünid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ÜRÜN GÜNCELLEME İŞLEMİ TAMAMLANDI");
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_FATURADETAY where FATURAURUNID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtürünid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
