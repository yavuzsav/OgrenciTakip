using DevExpress.XtraBars;
using System;
using System.Linq;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.TahakkukForms
{
    public partial class TahakkukListForm : BaseListForm
    {
        private readonly Expression<Func<Tahakkuk, bool>> _filter;

        public TahakkukListForm()
        {
            InitializeComponent();

            Bll = new TahakkukBll();
            HideItems = new BarItem[] { btnYeni };
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }

        public TahakkukListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId && x.Durum == AktifKartlariGoster;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Tahakkuk;
            FormShow = new ShowEditForms<TahakkukEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            var list = ((TahakkukBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}