using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.AileBilgiForms
{
    public partial class AileBilgiEditForm : BaseEditForm
    {
        public AileBilgiEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new AileBilgiBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.AileBilgi;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new AileBilgi() : ((AileBilgiBll)Bll).Single(FilterFunctions.Filter<AileBilgi>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((AileBilgiBll)Bll).YeniKodVer();
            txtBilgiAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (AileBilgi)OldEntity;

            txtKod.Text = entity.Kod;
            txtBilgiAdi.Text = entity.BilgiAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new AileBilgi
            {
                Id = Id,
                Kod = txtKod.Text,
                BilgiAdi = txtBilgiAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}