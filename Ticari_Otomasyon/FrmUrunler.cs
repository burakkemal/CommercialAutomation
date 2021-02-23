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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();  
        void listele()
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER",bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;

            }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2",txtmarka.Text);
            komut.Parameters.AddWithValue("@p3",txtmodel.Text);
            komut.Parameters.AddWithValue("@p4",mskyil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nmrcadet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtaliş.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtsatiş.Text));
            komut.Parameters.AddWithValue("@p8", rchdetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata", ex.Message);
            }          
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_URUNLER where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silme gerçekleşmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txctid.Text = dr["ID"].ToString();
            txtad.Text = dr["URUNAD"].ToString();
            txtmarka.Text = dr["MARKA"].ToString();
            txtmodel.Text = dr["MODEL"].ToString();
            mskyil.Text = dr["YIL"].ToString();
            nmrcadet.Value = decimal.Parse(dr["ADET"].ToString());
            txtaliş.Text = dr["ALISFIYAT"].ToString();
            txtsatiş.Text = dr["SATISFIYAT"].ToString();
            rchdetay.Text = dr["DETAY"].ToString();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4, ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 where ID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtmarka.Text);
            komut.Parameters.AddWithValue("@P3", txtmodel.Text);
            komut.Parameters.AddWithValue("@P4", mskyil.Text);
            komut.Parameters.AddWithValue("@P5", int.Parse((nmrcadet.Value).ToString()));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(txtaliş.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(txtsatiş.Text));
            komut.Parameters.AddWithValue("@P8", rchdetay.Text);
            komut.Parameters.AddWithValue("@P9", txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme İşlemi Tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }
        void Temizle()
        {
            txctid.Text = "";
            txtad.Text = "";
            txtaliş.Text = "";
            txtmarka.Text = "";
            txtmodel.Text = "";
            txtsatiş.Text = "";
            mskyil.Text = "";
            rchdetay.Text = "";
            nmrcadet.TextAlign =0;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
