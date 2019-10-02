using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.YabanciDilForms
{
    public partial class YabanciDilEditForm : BaseEditForm
    {
        public YabanciDilEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new YabanciDilBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.YabanciDil;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new YabanciDil() : ((YabanciDilBll)Bll).Single(FilterFunctions.Filter<YabanciDil>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((YabanciDilBll)Bll).YeniKodVer();
            txtDilAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (YabanciDil)OldEntity;

            txtKod.Text = entity.Kod;
            txtDilAdi.Text = entity.DilAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new YabanciDil
            {
                Id = Id,
                Kod = txtKod.Text,
                DilAdi = txtDilAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}