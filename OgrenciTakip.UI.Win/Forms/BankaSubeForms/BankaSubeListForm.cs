using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.BankaSubeForms
{
    public partial class BankaSubeListForm : BaseListForm
    {
        private readonly long _bankaId;
        private readonly string _bankaAdi;

        public BankaSubeListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new BankaSubeBll();

            _bankaId = (long)prm[0];
            _bankaAdi = prm[1].ToString();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.BankaSube;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_bankaAdi} )";
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaSubeBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.BankaId == _bankaId);
        }

        protected override void ShowEditForm(long id)// Id alması gerektiği için değişkenleri doldurda yok
        {
            var result = ShowEditForms<BankaSubeEditForm>.ShowDialogEditForm(KartTuru.BankaSube, id, _bankaId, _bankaAdi);
            ShowEditFormDefault(result);
        }
    }
}