using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.SinifForms
{
    public partial class SinifListForm : BaseListForm
    {
        public SinifListForm()
        {
            InitializeComponent();
            Bll = new SinifBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sinif;
            FormShow = new ShowEditForms<SinifEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SinifBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId);
        }
    }
}