using DevExpress.XtraGrid.Views.Base;
using System;
using System.Linq;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.UI.Win.Forms.FaturaForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;
using YavuzSav.OgrenciTakip.UI.Win.UserControls.UserControl.Base;

namespace YavuzSav.OgrenciTakip.UI.Win.UserControls.UserControl.FaturaEditFormTable
{
    public partial class FaturaPlaniTable : BaseTablo
    {
        public FaturaPlaniTable()
        {
            InitializeComponent();

            Bll = new FaturaBll();
            Tablo = tablo;
            EventsLoad();
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((FaturaBll)Bll).List(x => x.TahakkukId == OwnerForm.Id).ToBindingList<FaturaPlaniL>();
        }

        protected override void HareketEkle()
        {
            var alinanHizmetlerSource = ((FaturaPlaniEditForm)OwnerForm).tablo.DataController.ListSource.Cast<FaturaAlinanHizmetlerL>().ToList();
            var faturaPlaniSource = tablo.DataController.ListSource;

            if (!ShowEditForms<TopluFaturaPlaniEditForm>.ShowDialogEditForm(KartTuru.Fatura, alinanHizmetlerSource, faturaPlaniSource)) return;

            tablo.Focus();
            tablo.RefreshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colAciklama;
            ButonEnabledDurumu(true);
        }

        protected override void HareketSil()
        {
            var entity = tablo.GetRow<FaturaPlaniL>();
            if (entity == null) return;

            if (!colPlanTarih.OptionsColumn.AllowEdit)
            {
                Messages.HataMesaji("Hareket Görmüş Fatura Planları Silinemez");
                return;
            }

            base.HareketSil();
        }

        protected override void RowCellAllowEdit()
        {
            if (tablo.DataRowCount == 0) return;

            var entity = tablo.GetRow<FaturaPlaniL>();
            if (entity == null) return;

            colAciklama.OptionsColumn.AllowEdit = entity.TahakkukTarih == null;
            colPlanTarih.OptionsColumn.AllowEdit = entity.TahakkukTarih == null;
            colPlanTutar.OptionsColumn.AllowEdit = entity.TahakkukTarih == null;
            colPlanIndirim.OptionsColumn.AllowEdit = entity.TahakkukTarih == null;
        }

        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var entity = tablo.GetRow<FaturaPlaniL>();
            if (entity == null) return;

            if (e.Column == colPlanTutar || e.Column == colPlanIndirim)
                entity.PlanNetTutar = entity.PlanTutar - entity.PlanIndirimTutar;

            entity.Update = true;
            ButonEnabledDurumu(true);
        }

        protected override void Tablo_RowCountChanged(object sender, EventArgs e)
        {
            OwnerForm.btnSil.Enabled = tablo.DataController.ListSource.Cast<FaturaPlaniL>().Where(x => !x.Delete).ToList().Any();
            //gelen listede değer varsa btnSil'in durumunu aktif yap yoksa pasif
        }
    }
}