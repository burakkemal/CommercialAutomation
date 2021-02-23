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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {             
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_PERSONEL", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void Temizle()
        {
            txctid.Text ="";
            txtad.Text = "";
            txtsoyad.Text="";
            msktel.Text ="";
            msktc.Text = "";
            txtmail.Text="";
            cmbil.Text = "";
            cmbilce.Text ="";
            rchadres.Text="";
            txtgorev.Text="";

        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();
            sehirlistesi();
            Temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONEL (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",msktel.Text);
            komut.Parameters.AddWithValue("@p4",msktc.Text);
            komut.Parameters.AddWithValue("@p5",txtmail.Text);
            komut.Parameters.AddWithValue("@p6",cmbil.Text);
            komut.Parameters.AddWithValue("@p7",cmbilce.Text);
            komut.Parameters.AddWithValue("@p8",rchadres.Text);
            komut.Parameters.AddWithValue("@p9",txtgorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                txctid.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtsoyad.Text = dr["SOYAD"].ToString();
                msktel.Text = dr["TELEFON"].ToString();
                msktc.Text = dr["TC"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                rchadres.Text = dr["ADRES"].ToString();
                txtgorev.Text = dr["GOREV"].ToString();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_PERSONEL where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silme İşlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Listele();
            Temizle();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_personel set AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 where ID=@P10",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.Parameters.AddWithValue("@p5", txtmail.Text);
            komut.Parameters.AddWithValue("@p6", cmbil.Text);
            komut.Parameters.AddWithValue("@p7", cmbilce.Text);
            komut.Parameters.AddWithValue("@p8", rchadres.Text);
            komut.Parameters.AddWithValue("@p9", txtgorev.Text);
            komut.Parameters.AddWithValue("@p10", txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }
    }
}
