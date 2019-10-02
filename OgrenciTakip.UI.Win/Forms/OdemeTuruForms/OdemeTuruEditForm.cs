using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Functions;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.OdemeTuruForms
{
    public partial class OdemeTuruEditForm : BaseEditForm
    {
        public OdemeTuruEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new OdemeTuruBll(myDataLayoutControl);
            txtOdemeTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<OdemeTipi>());//ödeme tipi combobaxını doldurur (enum'ın description alır)
            BaseKartTuru = KartTuru.OdemeTuru;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new OdemeTuru() : ((OdemeTuruBll)Bll).Single(FilterFunctions.Filter<OdemeTuru>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((OdemeTuruBll)Bll).YeniKodVer();
            txtOdemeTuruAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (OdemeTuru)OldEntity;

            txtKod.Text = entity.Kod;
            txtOdemeTuruAdi.Text = entity.OdemeTuruAdi;
            txtOdemeTipi.SelectedItem = entity.OdemeTipi.ToName();//önemli(combobox)
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new OdemeTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                OdemeTuruAdi = txtOdemeTuruAdi.Text,
                OdemeTipi = txtOdemeTipi.Text.GetEnum<OdemeTipi>(),//önemli(combobox)
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}