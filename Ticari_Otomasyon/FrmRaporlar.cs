using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ticari_Otomasyon
{
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
        }

        private void btnFirmaRaporYazdir_Click(object sender, EventArgs e)
        {
            //XtraReport1 report = new XtraReport1();
            //report.DataSource = dbtools.MyGetDataTable("select * from TBL_FIRMALAR ");
            //report.txtToplam.Text = dbtools.MyGetItem("toplam", "select count(*) as toplam from TBL_FIRMALAR");
            //report.ShowPreview();
            ////report.Print();

            //report.CreateDocument();
            //PrintPreviewFormEx Preview = new PrintPreviewFormEx();
            //Preview.PrintingSystem = report.PrintingSystem;
            //Preview.Text = "Firma Raporu";
            ////Preview.TopLevel = false;
            //Preview.MdiParent = Program.frmadmin.fr; // why can I not embed the previewer form in the tab?
            //Preview.Show();
            XtraReport11 xtraReport11 = new XtraReport11();
            xtraReport11.ShowPreview();
        }
        private void btnFirmaPdfYazdir_Click(object sender, EventArgs e)
        {
            //gridView_firma.ExportToPdf(@"C:\cc\deneme"+ sayi++ + ".pdf");
            //gridView_firma.ExportToXlsx(@"C:\cc\deneme"+ sayi++ + ".xlsx");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            XtraReport2 xtraReport2 = new XtraReport2(); 
            xtraReport2.ShowPreview();           
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GiderlerRapor giderlerRapor = new GiderlerRapor();
            giderlerRapor.ShowPreview();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraReport3 xtraReport3 = new XtraReport3();
            xtraReport3.ShowPreview();
        }
    }
}
