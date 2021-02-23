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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void GiderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txctid.Text = "";
            cmbay.Text = "";
            cmbyil.Text = "";
            txtelektrik.Text = "";
            txtsu.Text = "";
            txtdogalgaz.Text = "";
            txtinternet.Text = "";
            txtmaaslar.Text = "";
            txtextra.Text = "";
            rchnotlar.Text = "";

        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            GiderListesi();
            temizle();
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", cmbay.Text);
            komut.Parameters.AddWithValue("@P2", cmbyil.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(txtelektrik.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@P5", decimal.Parse(txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(txtinternet.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(txtmaaslar.Text));
            komut.Parameters.AddWithValue("@P8", decimal.Parse(txtextra.Text));
            komut.Parameters.AddWithValue("@P9", rchnotlar.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Gider Tabloya Girildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            GiderListesi();
            temizle();

        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow DR = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (DR!=null)
            {
                txctid.Text = DR["ID"].ToString();
                cmbay.Text = DR["AY"].ToString();
                cmbyil.Text = DR["YIL"].ToString();
                txtelektrik.Text = DR["ELEKTRIK"].ToString();
                txtsu.Text = DR["SU"].ToString();
                txtdogalgaz.Text = DR["DOGALGAZ"].ToString();
                txtinternet.Text = DR["INTERNET"].ToString();
                txtmaaslar.Text = DR["MAASLAR"].ToString();
                txtextra.Text = DR["EKSTRA"].ToString();
                rchnotlar.Text = DR["NOTLAR"].ToString();                
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            temizle();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_GIDERLER where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            GiderListesi();
            MessageBox.Show("Gider Listeden Silindi", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
 SqlCommand komut = new SqlCommand("Update TBL_GIDERLER set AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 where ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", cmbay.Text);
            komut.Parameters.AddWithValue("@P2", cmbyil.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(txtelektrik.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@P5", decimal.Parse(txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(txtinternet.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(txtmaaslar.Text));
            komut.Parameters.AddWithValue("@P8", decimal.Parse(txtextra.Text));
            komut.Parameters.AddWithValue("@P9", rchnotlar.Text);
            komut.Parameters.AddWithValue("@P10", txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            GiderListesi();
            MessageBox.Show("Gider Güncellemesi Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

        }
    }

}
