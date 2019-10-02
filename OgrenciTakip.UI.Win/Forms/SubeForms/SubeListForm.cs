using System;
using System.Linq;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.SubeForms
{
    public partial class SubeListForm : BaseListForm
    {
        private readonly Expression<Func<Sube, bool>> _filter;

        public SubeListForm()
        {
            InitializeComponent();
            Bll = new SubeBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }

        public SubeListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sube;
            FormShow = new ShowEditForms<SubeEditForm>();
            Navigator = longNavigator1.Navigator;
        }

        protected override void Listele()
        {
            var list = ((SubeBll)Bll).List(_filter);
            tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}