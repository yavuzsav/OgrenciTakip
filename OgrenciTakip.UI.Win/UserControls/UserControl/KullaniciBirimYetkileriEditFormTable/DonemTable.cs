using System.Linq;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Functions;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base.Interfaces;
using YavuzSav.OgrenciTakip.UI.Win.Forms.DonemForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;
using YavuzSav.OgrenciTakip.UI.Win.UserControls.UserControl.Base;

namespace YavuzSav.OgrenciTakip.UI.Win.UserControls.UserControl.KullaniciBirimYetkileriEditFormTable
{
    public partial class DonemTable : BaseTablo
    {
        public DonemTable()
        {
            InitializeComponent();

            Bll = new KullaniciBirimYetkileriBll();
            Tablo = tablo;
            EventsLoad();
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KullaniciBirimYetkileriBll)Bll)
                .List(x => x.KullaniciId == OwnerForm.Id && x.KartTuru == KartTuru.Donem)
                .ToBindingList<KullaniciBirimYetkileriL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<KullaniciBirimYetkileriL>().Select(x => x.DonemId.Value).ToList();

            var entities = ShowListForms<DonemListForm>.ShowDialogListForm(ListeDisiTutulacakKayitlar, true, false)
                .EntityListConvert<Donem>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new KullaniciBirimYetkileriL
                {
                    Kod = entity.Kod,
                    DonemAdi = entity.DonemAdi,
                    KartTuru = KartTuru.Donem,
                    KullaniciId = OwnerForm.Id,
                    DonemId = entity.Id,
                    Insert = true
                };

                source.Add(row);
            }

            if (!Kaydet()) return;
            Listele();
            tablo.Focus();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
        }

        protected override void HareketSil()
        {
            if (tablo.DataRowCount == 0) return;
            if (Messages.SilMesaj("Dönem Kartı") != DialogResult.Yes) return;

            tablo.GetRow<IBaseHareketEntity>().Delete = true;
            tablo.RefreshDataSource();

            var rowHandle = tablo.FocusedRowHandle;
            if (!Kaydet()) return;
            Listele();
            tablo.FocusedRowHandle = rowHandle;
        }

        protected override void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            btnHareketSil.Enabled = tablo.DataRowCount > 0;
            btnHaraketEkle.Enabled =
                ((KullaniciBirimYetkileriEditForm) OwnerForm).kullaniciTable.Tablo.DataRowCount > 0;

            e.SagMenuGoster(popupMenu);
        }
    }
}