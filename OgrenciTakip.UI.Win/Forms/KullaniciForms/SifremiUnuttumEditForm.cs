using DevExpress.XtraBars;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Functions;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class SifremiUnuttumEditForm : BaseEditForm
    {
        private readonly string _kullaniciAdi;

        public SifremiUnuttumEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new KullaniciBll(myDataLayoutControl1);
            HideItems = new BarItem[] { btnYeni, btnKaydet, btnGerial, btnSil };
            ShowItems = new BarItem[] { btnSifreSifirla };
            EventsLoad();

            _kullaniciAdi = prm[0].ToString();
        }

        public override void Yukle()
        {
            txtKullaniciAdi.Text = _kullaniciAdi;
        }

        protected override void SifreSifirla()
        {
            if (Messages.EmailGonderimOnayi() != DialogResult.Yes) return;

            var entity = ((KullaniciBll)Bll).SingleDetail(x => x.Kod == txtKullaniciAdi.Text)
                .EntityConvert<KullaniciS>();
            if (entity == null)
            {
                Messages.HataMesaji("Bu Kullanıcı Adı İle Kayıtlı Bir Kullanıcı Bulunmamaktadır");
                return;
            }

            if (txtAdi.Text == entity.Adi && txtSoyadi.Text == entity.Soyadi && txtEmail.Text == entity.Email && txtGizliKelime.Text.Md5Sifrele() == entity.GizliKelime)
            {
                var result = Functions.GeneralFunctions.SifreUret();

                var currentEntity = new Kullanici
                {
                    Id = entity.Id,
                    Kod = entity.Kod,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    Email = entity.Email,
                    RolId = entity.RolId,
                    Aciklama = entity.Aciklama,
                    Durum = entity.Durum,
                    Sifre = result.sifre,
                    GizliKelime = result.gizliKelime
                };

                if (!((KullaniciBll)Bll).Update(entity, currentEntity)) return;
                var sonuc = txtKullaniciAdi.Text.SifreMailiGonder(entity.RolAdi, entity.Email,
                    result.secureSifre, result.secureGizliKelime);

                if (sonuc)
                {
                    Messages.BilgiMesaji("Şifre Sıfırlama İşlemi Başarılı Bir Şekilde Gerçekleşti");
                    Close();
                }
                else
                    Messages.HataMesaji("Şifre Sıfırlama İşlemi Başarılı Bir Şekilde Gerçekleşti. Ancak E-Mail Gönderilemedi Lütfen Tekrar Deneyiniz.");
            }
            else
            {
                Messages.HataMesaji("Girmiş Olduğunuz Kullanıcı Bilgileri Hatalıdır. Lütfen Kontrol Edip Tekrar Deneyiniz.");
            }
        }
    }
}