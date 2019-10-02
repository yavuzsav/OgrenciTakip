using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls;

namespace YavuzSav.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class DonemParametreEditForm : BaseEditForm
    {
        private readonly long _donemId;

        public DonemParametreEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new DonemParametreBll();
            HideItems = new BarItem[] { btnYeni, btnSil };
            KayitSonrasiFormuKapat = false;
            EventsLoad();
            _donemId = (long)prm[0];
        }

        protected override void NesneyiKontrollereBagla()
        {
            var parametre = (DonemParametre)OldEntity;
            var entity = new DonemParametre
            {
                Id = parametre.Id,
                Kod = parametre.Kod,
                SubeId = parametre.SubeId,
                DonemId = parametre.DonemId,
                DonemBaslamaTarihi = parametre.DonemBaslamaTarihi,
                DonemBitisTarihi = parametre.DonemBitisTarihi,
                EgitimBaslamaTarihi = parametre.EgitimBaslamaTarihi,
                EgitimBitisTarihi = parametre.EgitimBitisTarihi,
                GunTarihininOncesineHizmetBaslamaTarihiGirilebilir = parametre.GunTarihininOncesineHizmetBaslamaTarihiGirilebilir,
                GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir = parametre.GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir,
                GunTarihininOncesineIptalTarihiGirilebilir = parametre.GunTarihininOncesineIptalTarihiGirilebilir,
                GunTarihininSonrasinaIptalTarihiGirilebilir = parametre.GunTarihininSonrasinaIptalTarihiGirilebilir,
                GunTarihininOncesineMakbuzTarihiGirilebilir = parametre.GunTarihininOncesineMakbuzTarihiGirilebilir,
                GunTarihininSonrasinaMakbuzTarihiGirilebilir = parametre.GunTarihininSonrasinaMakbuzTarihiGirilebilir,
                HizmetTahakkukKurusKullan = parametre.HizmetTahakkukKurusKullan,
                IndirimTahakkukKurusKullan = parametre.IndirimTahakkukKurusKullan,
                OdemePlaniKurusKullan = parametre.OdemePlaniKurusKullan,
                FaturaTahakkukKurusKullan = parametre.FaturaTahakkukKurusKullan,
                MaksimumTaksitSayisi = parametre.MaksimumTaksitSayisi,
                MaksimumTaksitTarihi = parametre.MaksimumTaksitTarihi,
                GittigiOkulZorunlu = parametre.GittigiOkulZorunlu,
                YetkiKontroluAnlikYapilacak = parametre.YetkiKontroluAnlikYapilacak
            };

            Id = entity.Id;
            propertyGridControl.SelectedObject = entity;
        }

        protected override void GuncelNesneOlustur()
        {
            if (txtSube.Id == null)
            {
                //(6/6) 20.video 50:00
                //yüklenme anında oldentity ve current entity null olduğu için hata vermemesi için yapılıyor
                OldEntity = new DonemParametre();
                CurrentEntity = new DonemParametre();
                ButonEnabledDurumu();
                return;
            }

            CurrentEntity = new DonemParametre
            {
                Id = Id,
                Kod = Id.ToString(), //id her dönem için farklı geleceği için yekikod oluşturmak verine onu atadık
                SubeId = (long)txtSube.Id,
                DonemId = _donemId,
                DonemBaslamaTarihi = (DateTime)DonemBaslamaTarihi.Value, //gridin dönem başlama tarihi
                DonemBitisTarihi = (DateTime)DonemBitisTarihi.Value,
                EgitimBaslamaTarihi = (DateTime)EgitimBaslamaTarihi.Value,
                EgitimBitisTarihi = (DateTime)EgitimBitisTarihi.Value,
                GunTarihininOncesineHizmetBaslamaTarihiGirilebilir = (bool)GunTarihininOncesineHizmetBaslamaTarihiGirilebilir.Properties.Value,
                GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir = (bool)GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir.Properties.Value,
                GunTarihininOncesineIptalTarihiGirilebilir = (bool)GunTarihininOncesineIptalTarihiGirilebilir.Properties.Value,
                GunTarihininSonrasinaIptalTarihiGirilebilir = (bool)GunTarihininSonrasinaIptalTarihiGirilebilir.Properties.Value,
                GunTarihininOncesineMakbuzTarihiGirilebilir = (bool)GunTarihininOncesineMakbuzTarihiGirilebilir.Properties.Value,
                GunTarihininSonrasinaMakbuzTarihiGirilebilir = (bool)GunTarihininSonrasinaMakbuzTarihiGirilebilir.Properties.Value,
                HizmetTahakkukKurusKullan = (bool)HizmetTahakkukKurusKullan.Properties.Value,
                IndirimTahakkukKurusKullan = (bool)IndirimTahakkukKurusKullan.Properties.Value,
                OdemePlaniKurusKullan = (bool)OdemePlaniKurusKullan.Properties.Value,
                FaturaTahakkukKurusKullan = (bool)FaturaTahakkukKurusKullan.Properties.Value,
                MaksimumTaksitTarihi = (DateTime)MaksimumTaksitTarihi.Properties.Value,
                MaksimumTaksitSayisi = (byte)MaksimumTaksitSayisi.Properties.Value,
                GittigiOkulZorunlu = (bool)GittigiOkulZorunlu.Properties.Value,
                YetkiKontroluAnlikYapilacak = (bool)YetkiKontroluAnlikYapilacak.Properties.Value
            };

            ButonEnabledDurumu();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtSube)
                    sec.Sec(txtSube);
        }

        protected override void PropertyGridControl_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GuncelNesneOlustur();
        }

        protected override void PropertyGridControl_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            statusBarAciklama.Caption = e.Row.Properties.Caption;
        }

        protected override void Control_IdChanced(object sender, IdChangedEventArgs e)
        {
            //mybutton editdeki değişikliği yakalar ona göre property gridi dolduracağız
            if (!(sender is ButtonEdit)) return;
            if (txtSube.Id == null) return;

            OldEntity = ((DonemParametreBll)Bll).Single(x => x.SubeId == txtSube.Id && x.DonemId == _donemId) ??
                        new DonemParametre();

            BaseIslemTuru = OldEntity.Id == 0 ? IslemTuru.EntityInsert : IslemTuru.EntityUpdate;
            NesneyiKontrollereBagla();

            if(BaseIslemTuru!=IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
        }

        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            //subede seçim yapılmamışsa propertyGridControl'ün enabled durumunu false yap
            if(sender!=txtSube) return;
            txtSube.ControlEnabledChange(propertyGridControl);
            GuncelNesneOlustur();
        }
    }
}