using DevExpress.XtraSplashScreen;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.UI.Yonetim.Forms.GenelForms;

namespace YavuzSav.OgrenciTakip.UI.Yonetim.Functions
{
    internal class GeneralFunctions
    {
        protected internal static bool CreateDatabase<TContext>(string splashCaption, string splashDescription, string onayMesaj, string bilgiMesaj)
        where TContext : DbContext, new()
        {
            using (var con = new TContext())
            {
                con.Database.Connection.ConnectionString = Business.Functions.GeneralFunctions.GetConnectionString();
                if (con.Database.Exists()) return true;  //db oluşmuşsa return yap

                if (Messages.EvetSeciliEvetHayir(onayMesaj, "Onay") != DialogResult.Yes) return false;

                var splashForm = new SplashScreenManager(Form.ActiveForm, typeof(BekleForm), true, true);
                SplashBaslat(splashForm);

                splashForm.SetWaitFormCaption(splashCaption);
                splashForm.SetWaitFormDescription(splashDescription);

                try
                {
                    if (con.Database.CreateIfNotExists())
                    {
                        SplashDurdur(splashForm);
                        Messages.BilgiMesaji(bilgiMesaj);
                        return true;
                    }
                }
                catch (SqlException exception)
                {
                    SplashDurdur(splashForm);

                    switch (exception.Number)
                    {
                        case 5170:
                            Messages.HataMesaji("Veritabanı Dosyalarının Yükleneceği Klasörde Aynı İsimde Bir Dosya Var. Lütfen Kontrol Ediniz \n\n" + exception.Message);
                            break;

                        default:
                            Messages.HataMesaji(exception.Message);
                            break;
                    }
                }

                return false;
            }
        }

        protected internal static bool DeleteDataBase<TContext>() where TContext : DbContext, new()
        {
            using (var con = new TContext())
            {
                con.Database.Connection.ConnectionString = Business.Functions.GeneralFunctions.GetConnectionString();

                if (Messages.HayirSeciliEvetHayir(
                        "Seçtiğiniz Kurum ve Kurum İşlemlerinin Tamamını İçeren Kurum Veritabanı ( Veritabanı Dosyaları Dahil ) Silinecektir. Onaylıyor musunuz?",
                        "Sil Onay") != DialogResult.Yes) return false;
                if (Messages.HayirSeciliEvetHayir(
                        "Seçtiğiniz Kurum ve Kurum İşlemlerinin Tamamını İçeren Kurum Veritabanı ( Veritabanı Dosyaları Dahil ) Silinecektir.Tekrar Onaylıyor musunuz?",
                        "Sil Onay") != DialogResult.Yes) return false;

                try
                {
                    if (con.Database.Delete())
                    {
                        Messages.BilgiMesaji("Kurum Silme İşlemi Başarılı Bir Şekilde Tamamlanmıştır.");
                        return true;
                    }
                }
                catch (SqlException exception)
                {
                    switch (exception.Number)
                    {
                        case 3702:
                            Messages.HataMesaji("Veritabanı Kullanımda Olduğu İçin Silinemedi. Lütfen Veritabanına Yapılan Tüm Bağlantıları Sonlandırdıktan Sonra Tekrar Deneyiniz.");
                            break;

                        default:
                            Messages.HataMesaji(exception.Message);
                            break;
                    }
                }

                return false;
            }
        }

        private static void SplashBaslat(SplashScreenManager manager)
        {
            if (manager.IsSplashFormVisible)
            {
                manager.CloseWaitForm();
                manager.ShowWaitForm();
            }
            else
                manager.ShowWaitForm();
        }

        private static void SplashDurdur(SplashScreenManager manager)
        {
            if (manager.IsSplashFormVisible)
                manager.CloseWaitForm();
        }
    }
}