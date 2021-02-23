using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Ticari_Otomasyon
{
    public static class dbtools
    {
        //public  StreamReader okuGuvenlik = new StreamReader("WinlinePos.dll");

        public static string server = "DESKTOP-OVO6QPR";//Crypto.Decrypt(Convert.ToString(okuGuvenlik.ReadLine()), "keykubat");
        public static string users = "sa";//Crypto.Decrypt(Convert.ToString(okuGuvenlik.ReadLine()), "keykubat");
        public static string pwd = "123456";//Crypto.Decrypt(Convert.ToString(okuGuvenlik.ReadLine()), "keykubat");
        public static string database = "DboTicariOtomasyon";// Crypto.Decrypt(Convert.ToString(okuGuvenlik.ReadLine()), "keykubat");

        public static string connstr = "";
        public static SqlConnection con = new SqlConnection("server=" + server + "; Initial Catalog=" + database + ";User id=" + users + ";Password=" + pwd + ";Integrated Security=SSPI");
        public static string MyClass = "dbtoolsAcente";
        public static SqlTransaction tran;



        public static StreamReader oku = null;
      public static  string direkKullaniciAd = "rmosxyzrm", direkKullaniciSifre = "19830126x";
        public static void varsayilanSirketOlustur() // ilk şirketi oluştur
        {
            string server = dbtools.server;
            string pwd = dbtools.pwd;
            string users = dbtools.users;
            string database = dbtools.database;

            string sql = "select top 1 uSirket_id from uSirket where uSirket_server='" + server + "' and uSirket_database='" + database + "' and uSirket_user='" + users + "' and uSirket_password='" + pwd + "'";
            int uSirket_id = Convert.ToInt32(dbtools.MyGetItem("uSirket_id", sql));

            if (uSirket_id == -1)
            {
                uSirket_id = dbtools.MySetQuery1("insert into uSirket(uSirket_server,uSirket_database,uSirket_user,uSirket_password,uSirket_ad) output INSERTED.uSirket_id values('" + server + "','" + database + "','" + users + "','" + pwd + "','" + database + "')");
            }



            string id = "-1";
            if (uSirket_id != -1)
            {
                string sqlKullanici = "select * from uSirketKullanici where uSirketKullanici_uSirket_id='" + uSirket_id + "' and uSirketKullanici_ad='" + direkKullaniciAd + "' and uSirketKullanici_sifre='" + direkKullaniciSifre + "'";

                id = dbtools.MyGetItem("uSirketKullanici_id", sqlKullanici);


                bool admin = false;
                if (direkKullaniciAd.ToLower().Equals("rmosxyzrm"))
                {
                    admin = true;
                }

                if (id.Equals("-1")&&!direkKullaniciAd.Equals(""))
                {
                    string sqlKullanici1 = @"insert into uSirketKullanici(
                                                          uSirketKullanici_uSirket_id, 
                                                          uSirketKullanici_ad, 
                                                          uSirketKullanici_soyad, 
                                                          uSirketKullanici_sifre,
                                                          uSirketKullanici_tema,
                                                          uSirketKullanici_colorRezAktarilan,
                                                          uSirketKullanici_colorRezAktarilmayan,
                                                          uSirketKullanici_colorRezNew,
                                                          uSirketKullanici_colorRezModified,
                                                          uSirketKullanici_colorRezCancelled,
                                                          uSirketKullanici_admin
                                                          )
                                                          output INSERTED.uSirketKullanici_id
                                                           values(
                                                          '" + uSirket_id + @"', 
                                                          '" + direkKullaniciAd + @"', 
                                                          '" + direkKullaniciAd + @"', 
                                                          '" + direkKullaniciSifre + @"',
                                                          'Money Twins',
                                                          'White#Black',
                                                          'White#Black',
                                                          'White#Black',
                                                          'White#Black',
                                                          'White#Black',
                                                          '"+ admin + "'  )";

                    id = dbtools.MySetQuery1(sqlKullanici1).ToString();

                }
            }



            DataTable dtKullanici = dbtools.MyGetDataTable("select * from uSirketKullanici where uSirketKullanici_id='" + id + "'");

            if (dtKullanici == null || dtKullanici.Rows.Count < 1)
            {
                RHMesaj.MyMessageInformation("Yanlış veya Eksik Bilgi! Lütfen Bilgileri Kontrol Ediniz.");
                return;
            }


        }

        public static void varsayilanParametreOlustur() // sıfır veri tabanı kurarken varsayılan paremetreleri oluşturur
        {
            try
            {
                dbtools.MySetQuery("exec defaultParametre");
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "varsayilanParametreOlustur", "", ex);
            }
        }

        public static string colorRezAktarilan_back = "White";
        public static string colorRezAktarilmayan_back = "White";
        public static string colorRezNew_back = "White";
        public static string colorRezModified_back = "White";
        public static string colorRezCancelled_back = "White";

        public static string colorRezAktarilan_fore = "Black";
        public static string colorRezAktarilmayan_fore = "Black";
        public static string colorRezNew_fore = "Black";
        public static string colorRezModified_fore = "Black";
        public static string colorRezCancelled_fore = "Black";



        //public dbtools()
        //{
        //    connstr = "Data Source='" + server + "';Initial Catalog=" + database + "; Persist Security Info=True;uid='" + users + "';pwd='" + pwd + "'";
        //    con = new SqlConnection(connstr);
        //}

        //RHVeritabani.MyServerInfo("RAMAZANPC", "OrderTakerUltimate", "sa", "19830126");
        /// <summary>
        /// Veri tabanı bağlantıları için constructor(kurucu metot)
        /// </summary>
        /// <param name="pServerName"></param>
        /// <param name="pVeriTabani"></param>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        public static void MyServerInfo(string pServerName, string pVeriTabani, string pUserName, string pPassword) // KULLANILMIYOR ARTIK
        { // yüklenince
            try
            {
                con = new SqlConnection("server=" + pServerName + "; Initial Catalog=" + pVeriTabani + ";User id=" + pUserName + ";Password=" + pPassword + ";Integrated Security=SSPI");
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "RHVeritabani_C", "Bağlantı Açılamıyor!", ex);
            }
        }

        public static void MyConYenile()
        {
            try
            {
                connstr = "Data Source='" + server + "';Initial Catalog=" + database + "; Persist Security Info=True;uid='" + users + "';pwd='" + pwd + "'";
                con = new SqlConnection(connstr);
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyConYenile", "", ex);
            }
        }

        public static void MyConYenileParametre(string server, string database, string users, string pwd)
        {
            try
            {
                connstr = "Data Source='" + server + "';Initial Catalog=" + database + "; Persist Security Info=True;uid='" + users + "';pwd='" + pwd + "'";
                con = new SqlConnection(connstr);
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyConYenile", "", ex);
            }
        }


        /// <summary>
        /// Transaction başlatır
        /// </summary>
        public static void MyBeginTransaction()
        {
            try
            {
                MyOpen();
                tran = con.BeginTransaction();
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyBeginTransaction", "Beklenmedik Hata!", ex);
            }
        }

        /// <summary>
        /// Transaction kayıt eder
        /// </summary>
        public static void MyCommit()
        {
            try
            {
                MyOpen();
                tran.Commit();
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyCommit", "Beklenmedik Hata!", ex);
            }
        }

        /// <summary>
        /// Transaction iptal eder
        /// </summary>
        public static void MyRollback()
        {
            try
            {
                MyOpen();
                tran.Rollback();
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyRollback", "Beklenmedik Hata!", ex);
            }
        }


        public static void MyOpen()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                { // kapalıysa aç
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyOpen", "Bağlantı Açılamıyor!", ex);
            }
        }
        public static void MyClose()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                { // açıksa kapat
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyClose", "Bağlantı Kapatılamıyor!", ex);
            }
        }


        static object lockerDbtools = new object();
        /// <summary>
        /// Gelen Sql Sorgusuna Göre Geriye DataTable Döndürür. Tablo Boş veya Sorgu hatalıysa NULL döner
        /// </summary>
        /// <param name="pSqlText"></param>
        /// <returns></returns>
        public static DataTable MyGetDataTable(string pSqlText) // 
        { // datatable boş ise veya hata verirse null döner

            try
            {
                lock (lockerDbtools)
                {
                    MyOpen();
                    SqlCommand command = new SqlCommand(pSqlText, con);
                    command.CommandTimeout = 0; // sınırsız bekle
                    SqlDataReader dataReader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);
                    foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false; // 
                    dataReader.Close();
                    MyClose();
                    return dt;
                }

            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyGetDataTable", "Beklenmedik Hata!", ex);
                MyClose();
                return null;
            }
        }


        public static DateTime MyGetDateTime() // 
        { // datatable boş ise veya hata verirse null döner
            try
            {
                return Convert.ToDateTime(dbtools.MyGetItem("tarih", "select GETDATE() as tarih")); ;
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyGetDateTime", "Beklenmedik Hata!", ex);
                MyClose();
                return DateTime.Now;
            }
        }


        /// <summary>
        /// insert,update,delete için Bu metodu kullan! HATALI VEYA YANLIŞ BİLGİ GİRİLİRSE -1 DÖNER
        /// </summary>
        /// <param name="pSqlText"></param>
        /// <returns></returns>
        public static int MySetQuery(string pSqlText)
        { // insert,update,delete de kullanılır. -1 dönerse hatalı veya yanlış giriştir. aksi durumda başarılı
            try
            {
                lock (lockerDbtools)
                {
                    MyOpen();
                    SqlCommand command = new SqlCommand(pSqlText, con);
                    command.CommandTimeout = 0;
                    int value = command.ExecuteNonQuery();
                    MyClose();
                    return value;
                }
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MySetQuery", "Beklenmedik Hata! \n " + pSqlText, ex);
                MyClose();
                return -1;
            }
        }

        public static int MySetQuery1(string pSqlText)
        { // insert,update,delete de kullanılır. -1 dönerse hatalı veya yanlış giriştir. aksi durumda başarılı
            try
            {
                lock (lockerDbtools)
                {
                    MyOpen();
                    SqlCommand command = new SqlCommand(pSqlText, con);
                    command.CommandTimeout = 0;
                    int value = (int)command.ExecuteScalar();

                    MyClose();
                    return value;
                }
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MySetQuery", "Beklenmedik Hata!", ex);
                MyClose();
                return -1;
            }
        }




        /// <summary>
        /// TOP 1 ile veya SUM,MAX gibi tek alan döndüreceksek kullanılır. Veri yoksa veya hataya düşerse -1 döner
        /// </summary>
        /// <param name="pDonecekDeger"></param>
        /// <param name="pSqlText"></param>
        /// <returns></returns>
        public static string MyGetItem(string pDonecekDeger, string pSqlText)
        { // hatalı veya veri yoksa -1 döner . aksi durumda veri döner. Dikkat tek değer döner "Top 1","id" gibi alanlar için kullan!
            try
            {
                lock (lockerDbtools)
                {
                    MyOpen();
                    string DonecekDeger = "-1";
                    SqlCommand command = new SqlCommand(pSqlText, con);
                    command.CommandTimeout = 0;
                    SqlDataReader dataReader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);
                    if (dt.Rows.Count > 0)
                    { // 
                        foreach (DataRow item in dt.Rows)
                        {
                            DonecekDeger = item[pDonecekDeger].ToString();
                        }
                    }
                    dataReader.Close();
                    MyClose();
                    return DonecekDeger;
                }
            }
            catch (Exception ex)
            {
                MyClose();
                throw new Exception(ex.Message);
            }
        }

        public static byte[] MyGetItemBinary(string pDonecekDeger, string pSqlText) // select case when resimarka is not null then resimarka else resimon end from ocr where id=85
        {
            try
            {
                MyOpen();
                byte[] DonecekDeger = null;
                SqlCommand command = new SqlCommand(pSqlText, con);
                command.CommandTimeout = 0;
                SqlDataReader dataReader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                if (dt.Rows.Count > 0)
                { // 
                    foreach (DataRow item in dt.Rows)
                    {
                        DonecekDeger = (byte[])item[pDonecekDeger];
                    }
                }
                dataReader.Close();
                MyClose();
                return DonecekDeger;
            }
            catch (Exception ex)
            {
                MyClose();
                throw new Exception(ex.Message);
            }
        }

        /******** aşağısını procedure kullancaksan kullan *************/
        /// <summary>
        /// Procedureli -> insert,update,delete için Bu metodu kullan! HATALI VEYA YANLIŞ BİLGİ GİRİLİRSE -1 DÖNER
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static int MySetQuery_P(string pProcedureName, List<SqlParameter> pSqlParameter = null)
        {
            try
            {
                lock (lockerDbtools)
                {
                    MyOpen();
                    int value = -1;
                    SqlCommand command = new SqlCommand(pProcedureName, con);
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    if (pSqlParameter != null)
                    {
                        command.Parameters.AddRange(pSqlParameter.ToArray());
                    }
                    value = command.ExecuteNonQuery();
                    MyClose();
                    return value;
                }
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MySetQuery_P", "Beklenmedik Hata!", ex);
                MyClose();
                return -1;
            }
        }
        /* MySetQuery_P metodunun kullanımı aşağıda "SqlDbType" yazmaya bilirsin sıralamaya dikkat et yeter
         List<SqlParameter> sp = new List<SqlParameter>(){
    new SqlParameter() {ParameterName = "@uAlanTanim_ad", SqlDbType = SqlDbType.NVarChar, Value= txtAd.EditValue.ToString()},
    new SqlParameter() {ParameterName = "@uAlanTanim_durum", SqlDbType = SqlDbType.Bit, Value = radioAktif.Checked}};
                RHVeritabani.MySetQuery_P("uAlanTanimEkle", sp);

            // SqlDbType olmamış şeklinde
            List<SqlParameter> sp = new List<SqlParameter>(){
    new SqlParameter() {ParameterName = "@uAlanTanim_ad", Value= txtAd.EditValue.ToString()},
    new SqlParameter() {ParameterName = "@uAlanTanim_durum", Value = radioAktif.Checked}};
                RHVeritabani.MySetQuery_P("uAlanTanimEkle", sp);
             */

        /******** aşağısını transaction kullancaksan kullan ve MyOpen ve Close lar arasına yaz çünkü onlar yok aşağıda *************/

        /// <summary>
        /// Gelen Sql Sorgusuna Göre Geriye DataTable Döndürür. Tablo Boş veya Sorgu hatalıysa NULL döner
        /// </summary>
        /// <param name="pSqlText"></param>
        /// <returns></returns>
        public static DataTable MyGetDataTable_T(string pSqlText)
        { // datatable boş ise veya hata verirse null döner
            try
            {
                SqlCommand command = new SqlCommand(pSqlText, con);
                command.CommandTimeout = 0;
                command.Transaction = tran;
                SqlDataReader dataReader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;
                dataReader.Close();
                return dt;
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyGetDataTable", "Beklenmedik Hata!", ex);
                return null;
            }
        }

        /// <summary>
        /// insert,update,delete için Bu metodu kullan! HATALI VEYA YANLIŞ BİLGİ GİRİLİRSE -1 DÖNER
        /// </summary>
        /// <param name="pSqlText"></param>
        /// <returns></returns>
        public static int MySetQuery_T(string pSqlText)
        { // insert,update,delete de kullanılır. -1 dönerse hatalı veya yanlış giriştir. aksi durumda başarılı
            try
            {
                SqlCommand command = new SqlCommand(pSqlText, con);
                command.CommandTimeout = 0;
                command.Transaction = tran;
                int value = command.ExecuteNonQuery();
                return value;
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MySetQuery", "Beklenmedik Hata!", ex);
                return -1;
            }
        }
        /// <summary>
        /// 1 tane değer döndüren SQL sorgularında Kullanılır. Örn : ID'ye göre Kodunu almak istersek veya TOP 1 ile veya SUM,MAX gibi tek alan döndüreceksek kullanılır.
        /// </summary>
        /// <param name="pDonecekDeger"></param>
        /// <param name="pSqlText"></param>
        /// <returns></returns>
        public static string MyGetItem_T(string pDonecekDeger, string pSqlText)
        { // hatalı veya veri yoksa -1 döner . aksi durumda veri döner. Dikkat tek değer döner "Top 1","id" gibi alanlar için kullan!
            try
            {
                string DonecekDeger = "-1";
                SqlCommand command = new SqlCommand(pSqlText, con);
                command.CommandTimeout = 0;
                command.Transaction = tran;
                SqlDataReader dataReader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                if (dt.Rows.Count > 0)
                { // 
                    foreach (DataRow item in dt.Rows)
                    {
                        DonecekDeger = item[pDonecekDeger].ToString();
                    }
                }
                dataReader.Close();
                return DonecekDeger;
            }
            catch (Exception ex)
            {
                RHMesaj.MyMessageError(MyClass, "MyGetItem", "Beklenmedik Hata!", ex);
                return "-1";
            }
        }
    }
}
