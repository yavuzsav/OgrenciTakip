using DevExpress.XtraEditors;
using System;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.IndirimForms
{
    public partial class IndirimEditForm : BaseEditForm
    {
        public IndirimEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new IndirimBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Indirim;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new IndirimS() : ((IndirimBll)Bll).Single(FilterFunctions.Filter<Indirim>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IndirimBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
            txtIndirimAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IndirimS)OldEntity;

            txtKod.Text = entity.Kod;
            txtIndirimAdi.Text = entity.IndirimAdi;
            txtIndirimTuru.Id = entity.IndirimTuruId;
            txtIndirimTuru.Text = entity.IndirimTuruAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Indirim
            {
                Id = Id,
                Kod = txtKod.Text,
                IndirimAdi = txtIndirimAdi.Text,
                IndirimTuruId = Convert.ToInt64(txtIndirimTuru.Id),       //ÖNEMLİ
                Aciklama = txtAciklama.Text,
                SubeId = AnaForm.SubeId,
                DonemId = AnaForm.DonemId,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }

        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity, HizmetTable.TableValueChanged);
        }

        protected override bool EntityInsert()
        {
            if (HizmetTable.HataliGiris()) return false;
            return ((IndirimBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId) && HizmetTable.Kaydet();
        }

        protected override bool EntityUpdate()
        {
            if (HizmetTable.HataliGiris()) return false;
            return ((IndirimBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId) && HizmetTable.Kaydet();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
            {
                if (sender == txtIndirimTuru)
                    sec.Sec(txtIndirimTuru);
            }
        }

        protected override void TabloYukle()
        {
            HizmetTable.OwnerForm = this;
            HizmetTable.Yukle();
        }
    }
}