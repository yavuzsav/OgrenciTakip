using System;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.GecikmeAciklamalariForms
{
    public partial class GecikmeAciklamalariEditForm : BaseEditForm
    {
        private readonly int _portfoyNo;  //OdemeBilgileriId  aynıdır

        public GecikmeAciklamalariEditForm(params object[] prm)
        {
            InitializeComponent();

            _portfoyNo = (int)prm[0];

            DataLayoutControl = myDataLayoutControl1;
            Bll = new GecikmeAciklamalariBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.GecikmeAciklamalari;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new GecikmeAciklamalariS() : ((GecikmeAciklamalariBll)Bll).Single(FilterFunctions.Filter<GecikmeAciklamalari>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((GecikmeAciklamalariBll)Bll).YeniKodVer(x => x.OdemeBilgileriId == _portfoyNo);
            txtAciklama.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (GecikmeAciklamalariS)OldEntity;

            txtKod.Text = entity.Kod;
            txtKullaniciAdi.Text = BaseIslemTuru == IslemTuru.EntityInsert ? AnaForm.KullaniciAdi : entity.KullaniciAdi;
            txtTarihSaat.DateTime = BaseIslemTuru == IslemTuru.EntityInsert ? DateTime.Now : entity.TarihSaat;
            txtAciklama.Text = entity.Aciklama;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new GecikmeAciklamalari
            {
                Id = Id,
                Kod = txtKod.Text,
                OdemeBilgileriId = _portfoyNo,
                KullaniciId = BaseIslemTuru == IslemTuru.EntityInsert ? AnaForm.KullaniciId : 0,
                TarihSaat = txtTarihSaat.DateTime,
                Aciklama = txtAciklama.Text
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((GecikmeAciklamalariBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.OdemeBilgileriId == _portfoyNo);
        }

        protected override bool EntityUpdate()
        {
            return ((GecikmeAciklamalariBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.OdemeBilgileriId == _portfoyNo);
        }
    }
}