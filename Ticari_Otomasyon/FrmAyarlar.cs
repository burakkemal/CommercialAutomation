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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            Listele();
            txtkullanici.Text = "";
            txtsifre.Text = "";
        }

        private void Listele()
        {
            gridControl1.DataSource = dbtools.MyGetDataTable("Select * From TBL_ADMIN");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN (KullaniciAdi,Sifre) Values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtkullanici.Text);
                komut.Parameters.AddWithValue("@p2", txtsifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Admin Kullanıcı Kaydı Oluşturuldu", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("Update TBL_ADMIN set KullaniciAdi=@p1 where Sifre=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1",txtkullanici.Text);
                komut2.Parameters.AddWithValue("@p2",txtsifre.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
                MessageBox.Show("Güncelleme İşlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtkullanici.Text = dr["KullaniciAdi"].ToString();
                txtsifre.Text = dr["Sifre"].ToString();
            }
        }

        private void txtkullanici_TextChanged(object sender, EventArgs e)
        {
            if (txtkullanici.Text != "")
            {
                button1.Text = "Güncelle";
                button1.BackColor = Color.Red;
            }
            else
            {
                button1.Text = "Kaydet";
            }
        }
    }
}
