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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute BankaBilgileri", bgl.baglanti());
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
        void Firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD from TBL_FIRMALAR", bgl.baglanti()); ;
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;
        }
        void temizle()
        {
            txtbankaad.Text = "";
            txthesapno.Text = "";
            txthesaptürü.Text = "";
            txtiban.Text = "";
            txtsube.Text = "";
            txttid.Text = "";
            txtyetkili.Text = "";
            msktarih.Text = "";
            msktel.Text = "";
            lookUpEdit1.Text = "";
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            temizle();
            Listele();
            SehirListesi();
            Firmalistesi();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAAD,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtbankaad.Text);
                komut.Parameters.AddWithValue("@p2", cmbil.Text);
                komut.Parameters.AddWithValue("@p3", cmbilce.Text);
                komut.Parameters.AddWithValue("@p4", txtsube.Text);
                komut.Parameters.AddWithValue("@p5", txtiban.Text);
                komut.Parameters.AddWithValue("@p6", txthesapno.Text);
                komut.Parameters.AddWithValue("@p7", txtyetkili.Text);
                komut.Parameters.AddWithValue("@p8", msktel.Text);
                komut.Parameters.AddWithValue("@p9", msktarih.Text);
                komut.Parameters.AddWithValue("@p10", txthesaptürü.Text);
                komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
                komut.ExecuteNonQuery();
                Listele();
                bgl.baglanti().Close();
                MessageBox.Show("Banka Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA" + ex);
            }
            
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

        
        public void changed() // filter index -2147483646
        {
            DataRow DR = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (DR != null)
            {
                txttid.Text = DR["ID"].ToString();
                txtbankaad.Text = DR["BANKAAD"].ToString();
                cmbil.Text = DR["IL"].ToString();
                cmbilce.Text = DR["ILCE"].ToString();
                txtsube.Text = DR["SUBE"].ToString();
                txtiban.Text = DR["IBAN"].ToString();
                txthesapno.Text = DR["HESAPNO"].ToString();
                txtyetkili.Text = DR["YETKILI"].ToString();
                msktel.Text = DR["TELEFON"].ToString();
                msktarih.Text = DR["TARIH"].ToString();
                txthesaptürü.Text = DR["HESAPTURU"].ToString();
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_BANKALAR where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txttid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka Silme İşlemi Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
       SqlCommand komut = new SqlCommand("update TBL_BANKALAR set BANKAAD=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 where ID=@P12", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtbankaad.Text);
            komut.Parameters.AddWithValue("@P2", cmbil.Text);
            komut.Parameters.AddWithValue("@P3", cmbilce.Text);
            komut.Parameters.AddWithValue("@P4", txtsube.Text);
            komut.Parameters.AddWithValue("@P5", txtiban.Text);
            komut.Parameters.AddWithValue("@P6", txthesapno.Text);
            komut.Parameters.AddWithValue("@P7", txtyetkili.Text);
            komut.Parameters.AddWithValue("@P8", msktel.Text);
            komut.Parameters.AddWithValue("@P9", msktarih.Text);
            komut.Parameters.AddWithValue("@P10", txthesaptürü.Text);
            komut.Parameters.AddWithValue("@P11", lookUpEdit1.EditValue);
            komut.Parameters.AddWithValue("@P12", txttid.Text);
            komut.ExecuteNonQuery();
            Listele();
            bgl.baglanti().Close();
            MessageBox.Show("Güncellme işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata"+ex);
            }
     
        }
        private void FrmBankalar_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmAnaModul.fr7 = null;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            changed();
        }
    }
}
