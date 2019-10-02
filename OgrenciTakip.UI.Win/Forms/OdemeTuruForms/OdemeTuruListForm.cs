using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.OdemeTuruForms
{
    public partial class OdemeTuruListForm : BaseListForm
    {
        public OdemeTuruListForm()
        {
            InitializeComponent();

            Bll = new OdemeTuruBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.OdemeTuru;
            FormShow = new ShowEditForms<OdemeTuruEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((OdemeTuruBll)Bll).List(FilterFunctions.Filter<OdemeTuru>(AktifKartlariGoster));
        }
    }
}