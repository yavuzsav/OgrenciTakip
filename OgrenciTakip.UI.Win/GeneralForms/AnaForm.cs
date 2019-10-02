using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraTabbedMdi;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Functions;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.AileBilgiForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.AvukatForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BankaForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BankaHesapForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.CariForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.EvrakForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.FaturaForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.GorevForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.HizmetForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.HizmetTuruForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.IletisimForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.IlForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.IndirimForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.IndirimTuruForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.IptalNedeniForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.IsyeriForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.KasaForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.KontenjanForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.MakbuzForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.MeslekForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.OdemeTuruForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.OgrenciForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.OkulForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.PromosyonForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.RehberForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.ServisForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.SinifForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.SinifGrupForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.TahakkukForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.TesvikForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.YabanciDilForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.YakinlikForms;
using YavuzSav.OgrenciTakip.UI.Win.Reports.FormReports;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string KurumAdi;
        public static long KullaniciId;
        public static string KullaniciAdi;
        public static long KullaniciRolId;
        public static string KullaniciRolAdi;

        public static long DonemId;
        public static string DonemAdi = "Dönem Bilgisi Bekleniyor...";
        public static long SubeId;
        public static string SubeAdi = "Şube Bilgisi Bekleniyor...";
        public static List<long> YetkiliOlunanSubeler;
        public static DonemParametre DonemParametreleri;
        public static KullaniciParametreS KullaniciParametreleri = new KullaniciParametreS();
        public static IEnumerable<RolYetkileriL> RolYetkileri;

        public AnaForm()
        {
            InitializeComponent();
            EventsLoad();

            imgArkaPlanResim.EditValue = KullaniciParametreleri.ArkaPlanResim;
        }

        private void EventsLoad()
        {
            Load += AnaForm_Load;
            Closing += AnaForm_Closing;
            KeyDown += Control_KeyDown;

            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case SkinRibbonGalleryBarItem btn:
                        btn.GalleryItemClick += GalleryItem_GalleryItemClick;
                        break;

                    case SkinPaletteRibbonGalleryBarItem btn:
                        btn.GalleryItemClick += GalleryItem_GalleryItemClick;
                        break;

                    case BarButtonItem btn:
                        btn.ItemClick += Butonlar_ItemClick;
                        break;
                }
            }

            foreach (Control control in Controls)
                control.KeyDown += Control_KeyDown;

            xtraTabbedMdiManager.PageAdded += XtraTabbedMdiManager_PageAdded;
            xtraTabbedMdiManager.PageRemoved += XtraTabbedMdiManager_PageRemoved;
        }

        private void SubeDonemSecimi(bool subeSecimButonunaBasildi)
        {
            ShowEditForms<SubeDonemSecimiEditForm>.ShowDialogEditForm(null, KullaniciId, subeSecimButonunaBasildi,
                SubeId, DonemId);
            barDonem.Caption = DonemAdi;
            btnSube.Caption = SubeAdi;
        }

        private void AnaForm_Load(object sender, System.EventArgs e)
        {
            barKullanici.Caption = $@"{KullaniciAdi} ( {KullaniciRolAdi} )";
            barKurum.Caption = KurumAdi;
            SubeDonemSecimi(false); //daha ilk yüklenme aşamasında olduğu için

            if (DonemParametreleri == null)
            {
                Messages.HataMesaji("Dönem Parametreleri Girilmemiş. Lütfen Sistem Yöneticinize Başvurunuz.");
                Application.ExitThread();
                return;
            }

            if (!DonemParametreleri.YetkiKontroluAnlikYapilacak)
            {
                using (var bll = new RolYetkileriBll())
                {
                    //Başka bir Kullanım
                    //Converts.EntityListConvert<RolYetkileriL>(bll.List(x => x.RolId == KullaniciRolId));

                    RolYetkileri = bll.List(x => x.RolId == KullaniciRolId).EntityListConvert<RolYetkileriL>();
                }
            }
        }

        private void AnaForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Messages.HayirSeciliEvetHayir("Programdan Çıkmak İstiyor musunuz?", "Çıkış Onayı") == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }

        private void GalleryItem_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            var gallery = sender as InRibbonGallery;
            if (gallery.OwnerItem.GetType() == typeof(SkinRibbonGalleryBarItem))
                Functions.GeneralFunctions.AppSettingsWrite("Skin", e.Item.Caption);
            else if (gallery.OwnerItem.GetType() == typeof(SkinPaletteRibbonGalleryBarItem))
                Functions.GeneralFunctions.AppSettingsWrite("Palette", e.Item.Caption);
        }

        private void Butonlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnOkulKartlari)
                ShowListForms<OkulListForm>.ShowListForm(KartTuru.Okul);
            else if (e.Item == btnIlKartlari)
                ShowListForms<IlListForm>.ShowListForm(KartTuru.Il);
            else if (e.Item == btnAileBilgiKartlari)
                ShowListForms<AileBilgiListForm>.ShowListForm(KartTuru.AileBilgi);
            else if (e.Item == btnIptalNedeniKartlari)
                ShowListForms<IptalNedeniListForm>.ShowListForm(KartTuru.IptalNedeni);
            else if (e.Item == btnYabanciDilKartlari)
                ShowListForms<YabanciDilListForm>.ShowListForm(KartTuru.YabanciDil);
            else if (e.Item == btnTesvikKartlari)
                ShowListForms<TesvikListForm>.ShowListForm(KartTuru.Tesvik);
            else if (e.Item == btnKontenjanKartlari)
                ShowListForms<KontenjanListForm>.ShowListForm(KartTuru.Kontenjan);
            else if (e.Item == btnRehberKartlari)
                ShowListForms<RehberListForm>.ShowListForm(KartTuru.Kontenjan);
            else if (e.Item == btnSinifGrupKartlari)
                ShowListForms<SinifGrupListForm>.ShowListForm(KartTuru.SinifGrup);
            else if (e.Item == btnMeslekKartlari)
                ShowListForms<MeslekListForm>.ShowListForm(KartTuru.Meslek);
            else if (e.Item == btnYakinlikKartlari)
                ShowListForms<YakinlikListForm>.ShowListForm(KartTuru.Yakinlik);
            else if (e.Item == btnIsyeriKartlari)
                ShowListForms<IsyeriListForm>.ShowListForm(KartTuru.Isyeri);
            else if (e.Item == btnGorevKartlari)
                ShowListForms<GorevListForm>.ShowListForm(KartTuru.Gorev);
            else if (e.Item == btnIndirimTuruKartlari)
                ShowListForms<IndirimTuruListForm>.ShowListForm(KartTuru.IndirimTuru);
            else if (e.Item == btnEvrakKartlari)
                ShowListForms<EvrakListForm>.ShowListForm(KartTuru.Evrak);
            else if (e.Item == btnPromosyonKartlari)
                ShowListForms<PromosyonListForm>.ShowListForm(KartTuru.Promosyon);
            else if (e.Item == btnServisYeriKartlari)
                ShowListForms<ServisListForm>.ShowListForm(KartTuru.Servis);
            else if (e.Item == btnSinifKartlari)
                ShowListForms<SinifListForm>.ShowListForm(KartTuru.Sinif);
            else if (e.Item == btnHizmetTuruKartlari)
                ShowListForms<HizmetTuruListForm>.ShowListForm(KartTuru.HizmetTuru);
            else if (e.Item == btnHizmetKartlari)
                ShowListForms<HizmetListForm>.ShowListForm(KartTuru.Hizmet);
            else if (e.Item == btnKasaKartlari)
                ShowListForms<KasaListForm>.ShowListForm(KartTuru.Kasa);
            else if (e.Item == btnBankaKartlari)
                ShowListForms<BankaListForm>.ShowListForm(KartTuru.Banka);
            else if (e.Item == btnAvukatKartlari)
                ShowListForms<AvukatListForm>.ShowListForm(KartTuru.Avukat);
            else if (e.Item == btnCariKartlari)
                ShowListForms<CariListForm>.ShowListForm(KartTuru.Cari);
            else if (e.Item == btnOdemeTuruKartlari)
                ShowListForms<OdemeTuruListForm>.ShowListForm(KartTuru.OdemeTuru);
            else if (e.Item == btnBankaHesapKartlari)
                ShowListForms<BankaHesapListForm>.ShowListForm(KartTuru.BankaHesap);
            else if (e.Item == btnIletisimKartlari)
                ShowListForms<IletisimListForm>.ShowListForm(KartTuru.Iletisim);
            else if (e.Item == btnOgrenciKartlari)
                ShowListForms<OgrenciListForm>.ShowListForm(KartTuru.Ogrenci);
            else if (e.Item == btnIndirimKartlari)
                ShowListForms<IndirimListForm>.ShowListForm(KartTuru.Indirim);
            else if (e.Item == btnTahakkukKartlari)
                ShowListForms<TahakkukListForm>.ShowListForm(KartTuru.Tahakkuk);
            else if (e.Item == btnMakbuzKartlari)
                ShowListForms<MakbuzListForm>.ShowListForm(KartTuru.Makbuz);
            else if (e.Item == btnFaturaKartlari)
                ShowListForms<FaturaPlaniListForm>.ShowListForm(KartTuru.Fatura);
            else if (e.Item == btnFaturaTahakkukKarti)
                ShowEditForms<FaturaTahakkukEditForm>.ShowDialogEditForm(KartTuru.Fatura);
            else if (e.Item == btnGenelAmacliRapor)
                ShowEditReports<GenelAmacliRapor>.ShowEditReport(KartTuru.GenelAmacliRapor);
            else if (e.Item == btnSinifRaporlari)
                ShowEditReports<SinifRaporlari>.ShowEditReport(KartTuru.SinifRaporu);
            else if (e.Item == btnHizmetAlimRaporu)
                ShowEditReports<HizmetAlimRaporu>.ShowEditReport(KartTuru.HizmetAlimRaporu);
            else if (e.Item == btnNetUcretRaporu)
                ShowEditReports<NetUcretRaporu>.ShowEditReport(KartTuru.NetUcretRaporu);
            else if (e.Item == btnUcretVeOdemeRaporu)
                ShowEditReports<UcretVeOdemeRaporu>.ShowEditReport(KartTuru.UcretVeOdemeRaporu);
            else if (e.Item == btnIndirimDagilimRaporu)
                ShowEditReports<IndirimDagilimRaporu>.ShowEditReport(KartTuru.IndirimDagilimRaporu);
            else if (e.Item == btnMesleklereGoreKayitRaporu)
                ShowEditReports<MesleklereGoreKayitRaporu>.ShowEditReport(KartTuru.MesleklereGoreKayitRaporu);
            else if (e.Item == btnAylikKayitRaporu)
                ShowEditReports<AylikKayitRaporu>.ShowEditReport(KartTuru.AylikKayitRaporu);
            else if (e.Item == btnGelirDagilimRaporu)
                ShowEditReports<GelirDagilimRaporu>.ShowEditReport(KartTuru.GelirDagilimRaporu);
            else if (e.Item == btnUcretOrtalamalariRaporu)
                ShowEditReports<UcretOrtalamalariRaporu>.ShowEditReport(KartTuru.UcretOrtalamalariRaporu);
            else if (e.Item == btnOdemeBelgeleriRaporu)
                ShowEditReports<OdemeBelgeleriRaporu>.ShowEditReport(KartTuru.OdemeBelgeleriRaporu);
            else if (e.Item == btnTahsilatRaporu)
                ShowEditReports<TahsilatRaporu>.ShowEditReport(KartTuru.TahsilatRaporu);
            else if (e.Item == btnOdemesiGecikenAlacaklarRaporu)
                ShowEditReports<OdemesiGecikenAlacaklarRaporu>.ShowEditReport(KartTuru.OdemesiGecikenAlacaklarRaporu);
            else if (e.Item == btnKullaniciParametreleri)
            {
                var entity = ShowEditForms<KullaniciParametreEditForm>.ShowDialogEditForm<KullaniciParametreS>(KullaniciId);
                if (entity == null) return;
                KullaniciParametreleri = entity;
                imgArkaPlanResim.EditValue = entity.ArkaPlanResim;
            }
            else if (e.Item == btnHesapMakinesi)
                try
                {
                    Process.Start("calc.exe");
                }
                catch
                {
                    Messages.HataMesaji("Hesap Makinesi Bulunamadı");
                }
            else if (e.Item == btnSube)
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i] is GirisForm || Application.OpenForms[i] is AnaForm) continue;

                    Application.OpenForms[i].Close();
                    i--;
                    //her seferinde 1 açık formu kapattığımız için countda azalacak i-- yapmazsak program donar
                }

                SubeDonemSecimi(true);
            }
            else if (e.Item == btnSifreDegistir)
                ShowEditForms<SifreDegistirEditForm>.ShowDialogEditForm(IslemTuru.EntityUpdate);

            Cursor.Current = Cursors.Default;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void XtraTabbedMdiManager_PageAdded(object sender, MdiTabPageEventArgs e)
        {
            imgArkaPlanResim.SendToBack();
        }

        private void XtraTabbedMdiManager_PageRemoved(object sender, MdiTabPageEventArgs e)
        {
            if (((XtraTabbedMdiManager)sender).Pages.Count == 0)
                imgArkaPlanResim.BringToFront();
        }
    }
}