using DevExpress.Utils.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.HizmetForms
{
    public partial class HizmetListForm : BaseListForm
    {
        private readonly Expression<Func<Hizmet, bool>> _filter;

        public HizmetListForm()
        {
            InitializeComponent();
            Bll = new HizmetBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }

        public HizmetListForm(params object[] prm) : this() //yüklenme aşamasında parametresiz ctor çalışır
        {
            if (prm != null)
            {
                var panelGoster = (bool)prm[0];
                UstPanel.Visible = DateTime.Now.Date > AnaForm.DonemParametreleri.EgitimBaslamaTarihi && panelGoster;
            }

            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId && x.Durum == AktifKartlariGoster;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Hizmet;
            FormShow = new ShowEditForms<HizmetEditForm>();
            Navigator = longNavigator.Navigator;
            TarihAyarla();
        }

        protected override void Listele()
        {
            var list = ((HizmetBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any()) //değer varsa
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }

        private void TarihAyarla()
        {
            //(1:11:00)
            txtHizmetBaslamaTarihi.Properties.MinValue = AnaForm.DonemParametreleri.GunTarihininOncesineHizmetBaslamaTarihiGirilebilir ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date < AnaForm.DonemParametreleri.EgitimBaslamaTarihi ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date;

            txtHizmetBaslamaTarihi.Properties.MaxValue = AnaForm.DonemParametreleri.GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir ? AnaForm.DonemParametreleri.DonemBitisTarihi : DateTime.Now.Date < AnaForm.DonemParametreleri.EgitimBaslamaTarihi ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date > AnaForm.DonemParametreleri.DonemBitisTarihi ? AnaForm.DonemParametreleri.DonemBitisTarihi : DateTime.Now.Date;

            txtHizmetBaslamaTarihi.DateTime = DateTime.Now.Date <= AnaForm.DonemParametreleri.EgitimBaslamaTarihi ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date > AnaForm.DonemParametreleri.EgitimBaslamaTarihi && DateTime.Now.Date <= AnaForm.DonemParametreleri.DonemBitisTarihi ? DateTime.Now.Date : DateTime.Now.Date > AnaForm.DonemParametreleri.DonemBitisTarihi ? AnaForm.DonemParametreleri.DonemBitisTarihi : DateTime.Now.Date;
        }

        protected override void SelectEntity()
        {
            base.SelectEntity();

            if (MultiSelect)
                SelectedEntities.ForEach(x => ((HizmetL)x).BaslamaTarihi = txtHizmetBaslamaTarihi.DateTime.Date);
        }
    }
}