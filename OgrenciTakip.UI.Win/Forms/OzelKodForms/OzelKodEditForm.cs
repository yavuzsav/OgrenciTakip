using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.OzelKodForms
{
    public partial class OzelKodEditForm : BaseEditForm
    {
        private readonly OzelKodTuru _ozelKodTuru;
        private readonly KartTuru _ozelKodKartTuru;

        public OzelKodEditForm(params object[] prm)
        {
            InitializeComponent();

            _ozelKodTuru = (OzelKodTuru)prm[0];
            _ozelKodKartTuru = (KartTuru)prm[1];

            DataLayoutControl = myDataLayoutControl1;
            Bll = new OzelKodBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.OzelKod;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new OzelKod() : ((OzelKodBll)Bll).Single(FilterFunctions.Filter<OzelKod>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((OzelKodBll)Bll).YeniKodVer(x => x.KodTuru == _ozelKodTuru && x.KartTuru == _ozelKodKartTuru);
            txtOzelKodAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (OzelKod)OldEntity;

            txtKod.Text = entity.Kod;
            txtOzelKodAdi.Text = entity.OzelKodAdi;
            txtAciklama.Text = entity.Aciklama;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new OzelKod
            {
                Id = Id,
                Kod = txtKod.Text,
                OzelKodAdi = txtOzelKodAdi.Text,
                KodTuru = _ozelKodTuru,
                KartTuru = _ozelKodKartTuru,
                Aciklama = txtAciklama.Text
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((OzelKodBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KodTuru == _ozelKodTuru && x.KartTuru == _ozelKodKartTuru);
        }

        protected override bool EntityUpdate()
        {
            return ((OzelKodBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KodTuru == _ozelKodTuru && x.KartTuru == _ozelKodKartTuru);
        }
    }
}