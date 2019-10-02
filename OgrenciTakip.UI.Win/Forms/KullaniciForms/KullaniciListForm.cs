using DevExpress.XtraBars;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class KullaniciListForm : BaseListForm
    {
        public KullaniciListForm()
        {
            InitializeComponent();
            Bll = new KullaniciBll();
            HideItems = new BarItem[] { btnSec };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Kullanici;
            FormShow = new ShowEditForms<KullaniciEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource =
                ((KullaniciBll)Bll).List(FilterFunctions.Filter<Kullanici>(AktifKartlariGoster));
        }
    }
}