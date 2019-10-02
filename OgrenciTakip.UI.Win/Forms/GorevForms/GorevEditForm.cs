using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.GorevForms
{
    public partial class GorevEditForm : BaseEditForm
    {
        public GorevEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new GorevBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.Gorev;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Gorev() : ((GorevBll)Bll).Single(FilterFunctions.Filter<Gorev>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((GorevBll)Bll).YeniKodVer();
            txtGorevAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Gorev)OldEntity;

            txtKod.Text = entity.Kod;
            txtGorevAdi.Text = entity.GorevAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Gorev
            {
                Id = Id,
                Kod = txtKod.Text,
                GorevAdi = txtGorevAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}