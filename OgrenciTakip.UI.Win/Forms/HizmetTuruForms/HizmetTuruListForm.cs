using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.HizmetTuruForms
{
    public partial class HizmetTuruListForm : BaseListForm
    {
        public HizmetTuruListForm()
        {
            InitializeComponent();

            Bll = new HizmetTuruBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.HizmetTuru;
            FormShow = new ShowEditForms<HizmetTuruEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((HizmetTuruBll)Bll).List(FilterFunctions.Filter<HizmetTuru>(AktifKartlariGoster));
        }
    }
}