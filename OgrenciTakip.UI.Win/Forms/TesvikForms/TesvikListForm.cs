using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.TesvikForms
{
    public partial class TesvikListForm : BaseListForm
    {
        public TesvikListForm()
        {
            InitializeComponent();

            Bll = new TesvikBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Tesvik;
            FormShow = new ShowEditForms<TesvikEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((TesvikBll)Bll).List(FilterFunctions.Filter<Tesvik>(AktifKartlariGoster));
        }
    }
}