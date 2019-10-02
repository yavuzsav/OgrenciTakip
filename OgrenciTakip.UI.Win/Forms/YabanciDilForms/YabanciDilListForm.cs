using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.YabanciDilForms
{
    public partial class YabanciDilListForm : BaseListForm
    {
        public YabanciDilListForm()
        {
            InitializeComponent();

            Bll = new YabanciDilBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.YabanciDil;
            FormShow = new ShowEditForms<YabanciDilEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((YabanciDilBll)Bll).List(FilterFunctions.Filter<YabanciDil>(AktifKartlariGoster));
        }
    }
}