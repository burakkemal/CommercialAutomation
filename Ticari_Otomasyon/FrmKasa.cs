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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void MusteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void FirmaHareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }
        void Giderler()
        {
            gridControl2.DataSource = dbtools.MyGetDataTable("Select * From TBL_GIDERLER");

        }
        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            Giderler();
            lblaktifkullanici.Text = ad;
            FirmaHareketler();
            MusteriHareket();

            //toplam tutarı hesaplama 
            SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) FROM TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                lbltoplam.Text = dr[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            //SON AYIN FATURALARI

            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblodemeler.Text = dr2[0].ToString() + "TL";
            }
            bgl.baglanti().Close();


            //SON AYIN PERSONLE MAASLARI
            SqlCommand komut3 = new SqlCommand("Select MAASLAR from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblpersonelmaas.Text = dr3[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            // TOPLAM MUSTERI SAYISI
            SqlCommand komut4 = new SqlCommand("Select COUNT(*) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblmusteisayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            // TOPLAM FIRMA SAYISI
            SqlCommand komut5 = new SqlCommand("Select COUNT(*) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblfirmasayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            // TOPLAM FIRMA şehir SAYISI
            SqlCommand komut6 = new SqlCommand("Select COUNT(distinct(IL)) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblsehirsayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            // TOPLAM müşteri şehir SAYISI
            SqlCommand komut7 = new SqlCommand("Select COUNT(distinct(IL)) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblsehirsayisi2.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            // TOPLAM PERSONEL SAYISI
            SqlCommand komut8 = new SqlCommand("Select COUNT(*) from TBL_PERSONEL", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                personelsayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();
            // TOPLAM ÜRÜN SAYISI
            SqlCommand komut9 = new SqlCommand("Select sum(adet) FROM TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                stoksayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();




        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Elektrik
            sayac++;
            if (sayac > 0 && sayac <= 5)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac > 5 && sayac <= 10)
            {
                chartControl1.Series["Aylar"].Points.Clear();               
                groupControl10.Text = "Su";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac > 10 && sayac <= 15)
            {
                chartControl1.Series["Aylar"].Points.Clear();                
                groupControl10.Text = "Doğalgaz";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //Internet
            if (sayac > 15 && sayac <= 20)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Internet";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();

            }
            //Ekstra
            
            if (sayac > 20 && sayac <= 25)
            {
                chartControl1.Series["Aylar"].Points.Clear();                
                groupControl10.Text = "Ekstra";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,Ekstra from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac==26)
            {
                sayac = 0;
            }
        }
        int sayac2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Elektrik
            sayac2++;
            if (sayac2 > 0 && sayac2 <= 5)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Su";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Doğalgaz";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //Internet
            if (sayac2 > 15 && sayac2 <= 20)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Internet";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();

            }
            //Ekstra

            if (sayac2 > 20 && sayac2 <= 25)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Ekstra";
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,Ekstra from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
