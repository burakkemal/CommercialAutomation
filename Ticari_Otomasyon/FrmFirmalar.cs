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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void FirmaListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }
        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());            
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchkod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
        void  Temizle()
        {
            txtad.Text = "";
            txctid.Text = "";
            txtkod1.Text = "";
            txtkod2.Text = "";
            txtkod3.Text = "";
            txtmail.Text = "";
            txtsektör.Text = "";
            txtvergi.Text = "";
            txtyetkili.Text = "";
            txtyetkiligorev.Text = "";
            rchadres.Text = "";            
            mskfax.Text = "";
            msktel.Text = "";
            msktel2.Text = "";
            msktel3.Text = "";
            txtad.Focus();
        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListesi();
            
            Temizle();
            carikodaciklamalar();
            SehirListesi();
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txctid.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtsektör.Text = dr["SEKTOR"].ToString();
                txtyetkili.Text = dr["YETKILIADSOYAD"].ToString();
                txtyetkiligorev.Text = dr["YETKILISTATU"].ToString();
                yetkilitc.Text = dr["YETKILITC"].ToString();
                msktel.Text = dr["TELEFON1"].ToString();
                msktel2.Text = dr["TELEFON2"].ToString();
                msktel3.Text = dr["TELEFON3"].ToString();
                mskfax.Text = dr["FAX"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtvergi.Text = dr["VERGIDAIRE"].ToString();
                rchadres.Text = dr["ADRES"].ToString();
                txtkod1.Text = dr["OZELKOD1"].ToString();
                txtkod2.Text = dr["OZELKOD2"].ToString();
                txtkod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtyetkiligorev.Text);
            komut.Parameters.AddWithValue("@P3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@P4", yetkilitc.Text);
            komut.Parameters.AddWithValue("@P5", txtsektör.Text);
            komut.Parameters.AddWithValue("@P6", msktel.Text);
            komut.Parameters.AddWithValue("@P7", msktel2.Text);
            komut.Parameters.AddWithValue("@P8", msktel3.Text);
            komut.Parameters.AddWithValue("@P9", txtmail.Text);
            komut.Parameters.AddWithValue("@P10", mskfax.Text);
            komut.Parameters.AddWithValue("@P11", cmbil.Text);
            komut.Parameters.AddWithValue("@P12", cmbilce.Text);
            komut.Parameters.AddWithValue("@P13", txtvergi.Text);
            komut.Parameters.AddWithValue("@P14", rchadres.Text);
            komut.Parameters.AddWithValue("@P15", txtkod1.Text);
            komut.Parameters.AddWithValue("@P16", txtkod2.Text);
            komut.Parameters.AddWithValue("@P17", txtkod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListesi();
            Temizle();
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

        private void btnsil_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_FIRMALAR where ID=@P1", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", txctid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                FirmaListesi();
                MessageBox.Show("Firma Silme İşlemi Gerçekleştirilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Temizle();
            }
            catch(Exception ex)
            {
                MessageBox.Show("HATA "+ex.Message);
            }
           

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FIRMALAR set AD=@p1,YETKILISTATU=@P2 ,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAIL=@P9,IL=@P10,ILCE=@P11,FAX=@P12,VERGIDAIRE=@P13,ADRES=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 where ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtyetkiligorev.Text);
            komut.Parameters.AddWithValue("@P3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@P4", yetkilitc.Text);
            komut.Parameters.AddWithValue("@P5", txtsektör.Text);
            komut.Parameters.AddWithValue("@P6", msktel.Text);
            komut.Parameters.AddWithValue("@P7", msktel2.Text);
            komut.Parameters.AddWithValue("@P8", msktel3.Text);
            komut.Parameters.AddWithValue("@P9", txtmail.Text);
            komut.Parameters.AddWithValue("@P12", mskfax.Text);
            komut.Parameters.AddWithValue("@P10", cmbil.Text);
            komut.Parameters.AddWithValue("@P11", cmbilce.Text);
            komut.Parameters.AddWithValue("@P13", txtvergi.Text);
            komut.Parameters.AddWithValue("@P14", rchadres.Text);
            komut.Parameters.AddWithValue("@P15", txtkod1.Text);
            komut.Parameters.AddWithValue("@P16", txtkod2.Text);
            komut.Parameters.AddWithValue("@P17", txtkod3.Text);
            komut.Parameters.AddWithValue("@P18", txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Firma Bilgiler Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListesi();
            Temizle();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
