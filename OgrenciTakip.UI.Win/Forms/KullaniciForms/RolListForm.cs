using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class RolListForm : BaseListForm
    {
        public RolListForm()
        {
            InitializeComponent();

            Bll=new RolBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Rol;
            FormShow=new ShowEditForms<RolEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((RolBll) Bll).List(FilterFunctions.Filter<Rol>(AktifKartlariGoster));
        }

    }
}