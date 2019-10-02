using DevExpress.XtraEditors;
using System;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.HizmetForms
{
    public partial class HizmetEditForm : BaseEditForm
    {
        public HizmetEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new HizmetBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Hizmet;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new HizmetS() : ((HizmetBll)Bll).Single(FilterFunctions.Filter<Hizmet>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((HizmetBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);

            txtBaslamaTarihi.DateTime = txtBaslamaTarihi.Properties.MinValue;//başlama tarihine default tarih atama
            txtBitisTarihi.DateTime = txtBitisTarihi.Properties.MaxValue;//bitiş tarihine default tahir atama

            txtHizmetAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (HizmetS)OldEntity;

            txtKod.Text = entity.Kod;
            txtHizmetAdi.Text = entity.HizmetAdi;
            txtHizmetTuru.Id = entity.HizmetTuruId;
            txtHizmetTuru.Text = entity.HizmetTuruAdi;
            txtBaslamaTarihi.DateTime = entity.BaslamaTarihi;
            txtBitisTarihi.DateTime = entity.BitisTarihi;
            txtUcret.Value = entity.Ucret;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Hizmet
            {
                Id = Id,
                Kod = txtKod.Text,
                HizmetAdi = txtHizmetAdi.Text,
                HizmetTuruId = Convert.ToInt64(txtHizmetTuru.Id),
                BaslamaTarihi = txtBaslamaTarihi.DateTime.Date,
                BitisTarihi = txtBitisTarihi.DateTime.Date,
                Ucret = txtUcret.Value,
                Aciklama = txtAciklama.Text,
                SubeId = AnaForm.SubeId,
                DonemId = AnaForm.DonemId,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((HizmetBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }

        protected override bool EntityUpdate()
        {
            return ((HizmetBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
            {
                if (sender == txtHizmetTuru)
                    sec.Sec(txtHizmetTuru);
            }
        }

        protected override void Control_EditValueChanged(object sender, EventArgs e)
        {
            base.Control_EditValueChanged(sender, e);

            //başlangiç tarihi ve bitiş tarihi min max değer atama
            txtBaslamaTarihi.Properties.MinValue = AnaForm.DonemParametreleri.EgitimBaslamaTarihi;
            txtBaslamaTarihi.Properties.MaxValue = AnaForm.DonemParametreleri.DonemBitisTarihi;

            txtBitisTarihi.Properties.MinValue = txtBaslamaTarihi.DateTime.Date;
            txtBitisTarihi.Properties.MaxValue = AnaForm.DonemParametreleri.DonemBitisTarihi;
        }
    }
}