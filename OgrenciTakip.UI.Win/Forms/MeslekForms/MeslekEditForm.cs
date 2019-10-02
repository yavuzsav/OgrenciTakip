using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.MeslekForms
{
    public partial class MeslekEditForm : BaseEditForm
    {
        public MeslekEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new MeslekBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.Meslek;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Meslek() : ((MeslekBll)Bll).Single(FilterFunctions.Filter<Meslek>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((MeslekBll)Bll).YeniKodVer();
            txtMeslekAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Meslek)OldEntity;

            txtKod.Text = entity.Kod;
            txtMeslekAdi.Text = entity.MeslekAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Meslek
            {
                Id = Id,
                Kod = txtKod.Text,
                MeslekAdi = txtMeslekAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}