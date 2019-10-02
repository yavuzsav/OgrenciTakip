using System.Linq;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Functions;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.UI.Win.Forms.TahakkukForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Reports.FormReports.Base;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Reports.FormReports
{
    public partial class HizmetAlimRaporu : BaseRapor
    {
        public HizmetAlimRaporu()
        {
            InitializeComponent();
        }

        protected override void DegiskenleriDoldur()
        {
            DataLayoutControl = myDataLayoutControl1;
            Tablo = tablo;
            Navigator = longNavigator1.Navigator;
            Subeler = txtSubeler;
            Hizmetler = txtHizmetler;
            HizmetAlimTuru = txtHizmetAlimTuru;
            KayitSekilleri = txtKayitSekli;
            KayitDurumlari = txtKayitDurumu;

            SubeKartlariYukle();
            KayitSekliYukle();
            KayitDurumuYukle();
            HizmetKartlariYukle();
            txtHizmetAlimTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<HizmetAlimDurumu>());
            txtHizmetAlimTuru.SelectedItem = HizmetAlimDurumu.HizmetiAlanlar.ToName();
            RaporTuru = KartTuru.HizmetAlimRaporu;
        }

        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboBoxList<long>();
            var hizmetler = txtHizmetler.CheckedComboBoxList<long>();
            var kayitSekli = txtKayitSekli.CheckedComboBoxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboBoxList<KayitDurumu>();

            using (var bll = new HizmetAlimRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                  subeler.Contains(x.SubeId) &&
                  kayitSekli.Contains(x.KayitSekli) &&
                  kayitDurumu.Contains(x.KayitDurumu) &&
                  x.DonemId == AnaForm.DonemId, hizmetler, txtHizmetAlimTuru.Text.GetEnum<HizmetAlimDurumu>());

                base.Listele();
            }
        }

        protected override void ShowEditForm()
        {
            var entity = tablo.GetRow<HizmetAlimRaporL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, entity.TahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);
        }
    }
}