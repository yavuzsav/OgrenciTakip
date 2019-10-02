using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.TesvikForms
{
    public partial class TesvikEditForm : BaseEditForm
    {
        public TesvikEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new TesvikBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.Tesvik;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Tesvik() : ((TesvikBll)Bll).Single(FilterFunctions.Filter<Tesvik>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((TesvikBll)Bll).YeniKodVer();
            txtTesvikOrani.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Tesvik)OldEntity;

            txtKod.Text = entity.Kod;
            txtTesvikOrani.Text = entity.TesvikOrani;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Tesvik
            {
                Id = Id,
                Kod = txtKod.Text,
                TesvikOrani = txtTesvikOrani.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}