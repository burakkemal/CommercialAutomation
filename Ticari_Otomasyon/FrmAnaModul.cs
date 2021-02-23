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
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }
        FrmUrunler fr;
        private void btnurunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        public string kullanici;
        FrmAnaSayfa FR15;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (FR15==null || FR15.IsDisposed)
            {
                FR15 = new FrmAnaSayfa();
                FR15.MdiParent = this;
                FR15.Show();
            }
        }
        FrmMusteriler fr2;
        private void btnmusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmFirmalar frm3;
        private void btnfirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new FrmFirmalar();
                frm3.MdiParent = this;
                frm3.Show();

            }
        }
        FrmPersonel fr4;
        private void btnpersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FrmPersonel();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        FrmRehber fr5;
        private void btnrehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        FrmGiderler fr6;
        private void btngiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6==null || fr6.IsDisposed)
            {
                fr6 = new FrmGiderler();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        public static FrmBankalar fr7;
        private void btnbankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7==null || fr7.IsDisposed)
            {
                fr7 = new FrmBankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }
            else
            {
                fr7.Focus();
            }
        }
        FrmFaturalar fr8;
        private void brnfaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8==null || fr8.IsDisposed)
            {
                fr8 = new FrmFaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        FrmNotlar fr9;
        private void btnnotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9==null || fr9.IsDisposed)
            {
                fr9 = new FrmNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
        FrmHareketler fr10;
        private void BTN_HAREKETLER_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10==null || fr10.IsDisposed)
            {
                fr10 = new FrmHareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }
        FrmRaporlar fr11;
        private void BTN_RAPORLAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new FrmRaporlar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        private void FrmAnaModul_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmadmin.Close();
        }


        FrmStoklar fr12; 
        private void btnstoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new FrmStoklar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }
        FrmAyarlar fr13;
        private void btnayarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr13 = new FrmAyarlar();
            fr13.Show();
        }
        FrmKasa fr14;
        private void btnkasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14==null || fr14.IsDisposed)
            {
                fr14 = new FrmKasa();
                fr14.ad = kullanici;
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
    }
}
