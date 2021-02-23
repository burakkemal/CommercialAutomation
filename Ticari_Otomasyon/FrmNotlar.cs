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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            txtid.Text = "";
            msktarih.Text = "";
            msksaat.Text = "";
            txtbaslik.Text = "";
            rchdetay.Text = "";
            txtolusturan.Text = "";
            txthitap.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (TARIH,NOTSAAT,NOTBASLIK,DETAY,NOTOLUSTURAN,NOTHITAP) values (@P1,@P2,@P3,@P4,@P5,@P6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", msktarih.Text);
            komut.Parameters.AddWithValue("@P2", msksaat.Text);
            komut.Parameters.AddWithValue("@P3", txtbaslik.Text);
            komut.Parameters.AddWithValue("@P4", rchdetay.Text);
            komut.Parameters.AddWithValue("@P5", txtolusturan.Text);
            komut.Parameters.AddWithValue("@P6", txthitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgisi Sisteme EKlendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["NOTID"].ToString();
                msktarih.Text = dr["TARIH"].ToString();
                msksaat.Text = dr["NOTSAAT"].ToString();
                txtbaslik.Text = dr["NOTBASLIK"].ToString();
                rchdetay.Text = dr["DETAY"].ToString();
                txtolusturan.Text = dr["NOTOLUSTURAN"].ToString();
                txthitap.Text = dr["NOTHITAP"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_NOTLAR where NOTID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme İşlemi Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_NOTLAR set TARIH=@P1,NOTSAAT=@P2,NOTBASLIK=@P3,DETAY=@P4,NOTOLUSTURAN=@P5,NOTHITAP=@P6 where NOTID=@P7", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", msktarih.Text);
            komut.Parameters.AddWithValue("@P2", msksaat.Text);
            komut.Parameters.AddWithValue("@P3", txtbaslik.Text);
            komut.Parameters.AddWithValue("@P4", rchdetay.Text);
            komut.Parameters.AddWithValue("@P5", txtolusturan.Text);
            komut.Parameters.AddWithValue("@P6", txthitap.Text);
            komut.Parameters.AddWithValue("@P7", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();


            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
            }
            fr.Show();
        }
    }
}
