using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        void Stoklar()
        {
            //Stoklar
            gridControlstoklar.DataSource = dbtools.MyGetDataTable("Select UrunAD,Sum(Adet) as 'Adet' From TBL_URUNLER group by Urunad having Sum(adet) <= 20order by Sum(Adet)");
        }
        void Ajanda()
        {
            gridControlajanda.DataSource = dbtools.MyGetDataTable("Select top 5 TARIH,NOTSAAT,NOTBASLIK from TBL_NOTLAR order by NOTID desc ");
        }
        private void FirmaHareketleri()
        {
            gridControlhareketler.DataSource = dbtools.MyGetDataTable("Exec FirmaHareket2");
        }
        void Fihrist()
        {
            gridControlFİHRİST.DataSource = dbtools.MyGetDataTable("Select AD,TELEFON1 From TBL_FIRMALAR");

        }
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
                
            }
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            Stoklar();
            Ajanda();
            FirmaHareketleri();
            Fihrist();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            haberler();
        }
    }
}
