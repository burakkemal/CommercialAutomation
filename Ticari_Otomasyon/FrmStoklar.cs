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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 8);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 7);
            //chartControl1.Series["Series 1"].Points.AddPoint("Adana", 5);
            SqlDataAdapter da = new SqlDataAdapter("select urunad,Sum(adet) as 'Miktar' from tbl_urunler group by urunad", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            //charta stok mıktarı listeleme
            SqlCommand komut = new SqlCommand("select urunad,Sum(adet) as 'Miktar' from tbl_urunler group by urunad", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();

            //CHARTA firma şehir sayısı çekme
            SqlCommand komu2 = new SqlCommand("Select IL,count(*) from TBL_FIRMALAR group by IL", bgl.baglanti());
            SqlDataReader dr2 = komu2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            bgl.baglanti().Close();
                
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay fr = new FrmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.ad = dr["URUNAD"].ToString();
            }
            fr.Show();
        }
    }
}
