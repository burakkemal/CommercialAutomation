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
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();


        void Listele()
        {
            SqlCommand komut = new SqlCommand("Select * FROM TBL_FATURADETAY where FaturaID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", dr);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public string dr;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FaturaUrunDuzenleme fr = new FaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.urunid = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }

        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
