using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.IsyeriForms
{
    public partial class IsyeriListForm : BaseListForm
    {
        public IsyeriListForm()
        {
            InitializeComponent();

            Bll = new IsyeriBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Isyeri;
            FormShow = new ShowEditForms<IsyeriEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele() => Tablo.GridControl.DataSource = ((IsyeriBll)Bll).List(FilterFunctions.Filter<Isyeri>(AktifKartlariGoster));
    }
}