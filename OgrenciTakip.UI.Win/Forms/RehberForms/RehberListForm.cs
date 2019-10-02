using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.RehberForms
{
    public partial class RehberListForm : BaseListForm
    {
        public RehberListForm()
        {
            InitializeComponent();

            Bll = new RehberBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Rehber;
            FormShow = new ShowEditForms<RehberEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((RehberBll)Bll).List(FilterFunctions.Filter<Rehber>(AktifKartlariGoster));
        }
    }
}