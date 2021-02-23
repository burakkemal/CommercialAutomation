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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {

            SqlCommand komut = new SqlCommand("Select * from TBL_FATURABILGI", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            txtalici.Text = "";
            txctid.Text = "";
            txtseri.Text = "";
            txtsirano.Text = "";
            txtteslimalan.Text = "";
            txtteslimeden.Text = "";
            txtvergidaire.Text = "";
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtfaturaid.Text ==null)
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtseri.Text);
                komut.Parameters.AddWithValue("@p2", txtsirano.Text);
                komut.Parameters.AddWithValue("@p3", msktarih.Text);
                komut.Parameters.AddWithValue("@p4", msksaat.Text);
                komut.Parameters.AddWithValue("@p5", txtvergidaire.Text);
                komut.Parameters.AddWithValue("@p6", txtalici.Text);
                komut.Parameters.AddWithValue("@p7", txtteslimeden.Text);
                komut.Parameters.AddWithValue("@p8", txtteslimalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
                MessageBox.Show("Kaydetme işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txtfaturaid.Text !="" && comboBox1.Text == "Firma")
            {
                try
                {
                    double miktar, tutar, fiyat;
                    fiyat = Convert.ToDouble(txtfiyat.Text);
                    miktar = Convert.ToDouble(txtmiktar.Text);
                    tutar = miktar * fiyat;
                    txttutar.Text = tutar.ToString();
                    SqlCommand komut = new SqlCommand("insert into TBL_FATURADETAY (URUN,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@P1", txtürünad.Text);
                    komut.Parameters.AddWithValue("@P2", txtmiktar.Text);
                    komut.Parameters.AddWithValue("@P3", decimal.Parse(txtfiyat.Text));
                    komut.Parameters.AddWithValue("@P4", decimal.Parse(txttutar.Text));
                    komut.Parameters.AddWithValue("@P5", txtfaturaid.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    Listele();
                    MessageBox.Show("Faturaya ait ürün Kaydetme işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bgl.baglanti().Close();

                    //Hareketler tablosuna veri girişi
                    SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@h1", txtürünid.Text);
                    komut3.Parameters.AddWithValue("@h2", txtmiktar.Text);
                    komut3.Parameters.AddWithValue("@h3", txtpersonel.Text);
                    komut3.Parameters.AddWithValue("@h4", txtfirma.Text);
                    komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtfiyat.Text));
                    komut3.Parameters.AddWithValue("@h6", decimal.Parse(txttutar.Text));
                    komut3.Parameters.AddWithValue("@h7", txtfaturaid.Text);
                    komut3.Parameters.AddWithValue("@h8", msktarih.Text);
                    komut3.ExecuteNonQuery();
                    MessageBox.Show("faturaya ait ürün kaydedildi");
                    bgl.baglanti().Close();


                    // stok sayısını azaltma
                    SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@S1 where ID=@S2", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@S1", txtmiktar.Text);
                    komut4.Parameters.AddWithValue("@S2", txtürünid.Text);
                    komut4.ExecuteNonQuery();
                    MessageBox.Show("Faturaya Ait Ürün Güncellendi");
                    bgl.baglanti().Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //MÜŞTERİ CARİSİ
                if (txtfaturaid.Text != null && comboBox1.Text == "müşteri")
                {
                    try
                    {
                        double miktar, tutar, fiyat;
                        fiyat = Convert.ToDouble(txtfiyat.Text);
                        miktar = Convert.ToDouble(txtmiktar.Text);
                        tutar = miktar * fiyat;
                        txttutar.Text = tutar.ToString();
                        SqlCommand komut = new SqlCommand("insert into TBL_FATURADETAY (URUN,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                        komut.Parameters.AddWithValue("@P1", txtürünad.Text);
                        komut.Parameters.AddWithValue("@P2", txtmiktar.Text);
                        komut.Parameters.AddWithValue("@P3", decimal.Parse(txtfiyat.Text));
                        komut.Parameters.AddWithValue("@P4", decimal.Parse(txttutar.Text));
                        komut.Parameters.AddWithValue("@P5", txtfaturaid.Text);
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        Listele();
                        MessageBox.Show("Faturaya ait ürün Kaydetme işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bgl.baglanti().Close();

                        //Hareketler tablosuna veri girişi
                        SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKET (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@h1", txtürünid.Text);
                        komut3.Parameters.AddWithValue("@h2", txtmiktar.Text);
                        komut3.Parameters.AddWithValue("@h3", txtpersonel.Text);
                        komut3.Parameters.AddWithValue("@h4", txtfirma.Text);
                        komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtfiyat.Text));
                        komut3.Parameters.AddWithValue("@h6", decimal.Parse(txttutar.Text));
                        komut3.Parameters.AddWithValue("@h7", txtfaturaid.Text);
                        komut3.Parameters.AddWithValue("@h8", msktarih.Text);
                        komut3.ExecuteNonQuery();
                        MessageBox.Show("faturaya ait ürün kaydedildi");
                        bgl.baglanti().Close();


                        // stok sayısını azaltma
                        SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@S1 where ID=@S2", bgl.baglanti());
                        komut4.Parameters.AddWithValue("@S1", txtmiktar.Text);
                        komut4.Parameters.AddWithValue("@S2", txtürünid.Text);
                        komut4.ExecuteNonQuery();
                        MessageBox.Show("Faturaya Ait Ürün Güncellendi");
                        bgl.baglanti().Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txctid.Text = dr["FATURABILGIID"].ToString();
                txtsirano.Text = dr["SIRANO"].ToString();
                txtseri.Text = dr["SERI"].ToString();
                msktarih.Text = dr["TARIH"].ToString();
                msksaat.Text = dr["SAAT"].ToString();
                txtteslimalan.Text = dr["TESLIMALAN"].ToString();
                txtteslimeden.Text = dr["TESLIMEDEN"].ToString();
                txtvergidaire.Text = dr["VERGIDAIRE"].ToString();
            }
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURABILGI where FATURABILGIID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtfaturaid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("FAtura silme işlemi gerçekleştirildi", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 where FATURABILGIID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtseri.Text);
            komut.Parameters.AddWithValue("@P2", txtsirano.Text);
            komut.Parameters.AddWithValue("@P3", msktarih.Text);
            komut.Parameters.AddWithValue("@P4", msksaat.Text);
            komut.Parameters.AddWithValue("@P5", txtvergidaire.Text);
            komut.Parameters.AddWithValue("@P6", txtalici.Text);
            komut.Parameters.AddWithValue("@P7", txtteslimeden.Text);
            komut.Parameters.AddWithValue("@P8", txtteslimalan.Text);
            komut.Parameters.AddWithValue("@P9", txctid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            Listele();
            MessageBox.Show("Faturaya ait ürün Güncelleme işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.dr = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void btnbul_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT from TBL_URUNLER where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtürünid.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtürünad.Text = dr[0].ToString();
                txtfiyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
