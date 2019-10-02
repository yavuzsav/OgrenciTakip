using DevExpress.XtraBars;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.GecikmeAciklamalariForms
{
    public partial class GecikmeAciklamalariListForm : BaseListForm
    {
        private readonly int _portfoyNo;

        public GecikmeAciklamalariListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GecikmeAciklamalariBll();
            HideItems = new BarItem[] { btnSec };

            _portfoyNo = (int)prm[0];
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GecikmeAciklamalari;
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((GecikmeAciklamalariBll)Bll).List(x => x.OdemeBilgileriId == _portfoyNo);
        }

        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GecikmeAciklamalariEditForm>.ShowDialogEditForm(KartTuru.GecikmeAciklamalari, id, _portfoyNo);
            ShowEditFormDefault(result);
        }
    }
}