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
    public partial class FrmStokDetay : Form
    {
        public FrmStokDetay()
        {
            InitializeComponent();
        }
        public string ad;
        private void FrmStokDetay_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dbtools.MyGetDataTable("Select * From TBL_URUNLER where URUNAD='" + ad + "'");
        }
    }
}
