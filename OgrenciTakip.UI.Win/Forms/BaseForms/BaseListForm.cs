using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base;
using YavuzSav.OgrenciTakip.UI.Win.Forms.FiltreForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;
using YavuzSav.OgrenciTakip.UI.Win.Show.Interfaces;
using YavuzSav.OgrenciTakip.UI.Win.UserControls.Grid;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Variables

        private long _filtreId;
        private bool _formSablonKayıtEdilecek;
        private bool _tabloSablonKayıtEdilecek;
        protected IBaseFormShow FormShow;
        protected KartTuru BaseKartTuru;
        protected bool AktifKartlariGoster = true;
        protected IBaseBll Bll;
        protected ControlNavigator Navigator;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        protected internal GridView Tablo;
        protected internal bool AktifPasifButonGoster = false;
        protected internal bool MultiSelect;
        protected internal BaseEntity SelectedEntity;
        protected internal long? SeciliGelecekId;
        protected internal IList<long> ListeDisiTutulacakKayitlar;
        protected internal SelectRowFunctions RowSelect;
        protected internal bool EklenebilecekEntityVar = false;
        protected internal IList<BaseEntity> SelectedEntities;

        #endregion Variables

        public BaseListForm()
        {
            InitializeComponent();
        }

        //Events Functions (event kayıt function)
        private void EventsLoad()
        {
            //button events
            foreach (var item in ribbonControl1.Items)
            {
                switch (item)
                {
                    case BarItem button:
                        button.ItemClick += Button_ItemClick;
                        break;
                }
            }

            //table events
            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.KeyDown += Tablo_KeyDown;
            Tablo.MouseUp += Tablo_MouseUp;
            Tablo.ColumnWidthChanged += Tablo_ColumnWidthChanged;
            Tablo.ColumnPositionChanged += Tablo_ColumnPositionChanged;
            Tablo.EndSorting += Tablo_EndSorting;
            Tablo.FilterEditorCreated += Tablo_FilterEditorCreated;
            Tablo.ColumnFilterChanged += Tablo_ColumnFilterChanged;
            Tablo.CustomDrawFooterCell += Tablo_CustomDrawFooterCell;
            Tablo.FocusedRowObjectChanged += Tablo_FocusedRowObjectChanged;
            Tablo.RowDeleted += Tablo_RowDeleted;

            //form events
            Shown += BaseListForm_Shown;
            Load += BaseListForm_Load;
            FormClosing += BaseListForm_FormClosing;
            LocationChanged += BaseListForm_LocationChanged;
            SizeChanged += BaseListForm_SizeChanged;
        }

        #region Functions

        protected virtual void SutunGizleGoster()
        {
        }

        private void ButonGizleGoster()
        {
            btnSec.Visibility = AktifPasifButonGoster ? BarItemVisibility.Never : IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnter.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnterAciklama.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            btnAktifPasifKartlar.Visibility = AktifPasifButonGoster ? BarItemVisibility.Always : !IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;

            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }

        private void SablonKaydet()
        {
            if (_formSablonKayıtEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);

            if (_tabloSablonKayıtEdilecek)
                Tablo.TabloSablonKaydet(IsMdiChild ? Name + " Tablosu" : Name + " TablosuMDI");
        }

        private void SablonYukle()
        {
            if (IsMdiChild)
                Tablo.TabloSablonYukle(Name + " Tablosu");
            else
            {
                Name.FormSablonYukle(this);
                Tablo.TabloSablonYukle(Name + " TablosuMDI");
            }
        }

        protected virtual void SelectEntity()
        {
            if (MultiSelect)
            {
                SelectedEntities = new List<BaseEntity>();
                if (RowSelect.SelectedRowCount == 0)
                {
                    Messages.KartSecmemeUyariMesaji();
                    return;
                }

                SelectedEntities = RowSelect.GetSelectedRows();
            }
            else
                SelectedEntity = Tablo.GetRow<BaseEntity>();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void FiltreSec()
        {
            if (!KartTuru.Filtre.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            var entity = (Filtre)ShowListForms<FiltreListForm>.ShowDialogListForm(KartTuru.Filtre, _filtreId, BaseKartTuru, Tablo.GridControl);
            if (entity == null) return;

            _filtreId = entity.Id;
            Tablo.ActiveFilterString = entity.FiltreMetni;
        }

        private void FormCaptionAyarla()
        {
            if (btnAktifPasifKartlar == null)
            {
                Listele();
                return;
            }

            if (AktifKartlariGoster)
            {
                btnAktifPasifKartlar.Caption = "Pasif Kartlar";
                Tablo.ViewCaption = Text;
            }
            else
            {
                btnAktifPasifKartlar.Caption = "Aktif Kartlar";
                Tablo.ViewCaption = Text + " - Pasif Kartlar";
            }

            Listele();
        }

        private void IslemTuruSec()
        {
            //mdi child değilse ve sec butonu gözükmüyorsa btndüzelt'e basılmış gibi işlem yap
            if (!IsMdiChild)
                if (btnSec.Visibility == BarItemVisibility.Never)
                    btnDuzelt.PerformClick();
                else
                    SelectEntity();
            else
                btnDuzelt.PerformClick();
        }

        protected void ShowEditFormDefault(long id)
        {
            if (id <= 0) return;
            AktifKartlariGoster = true;
            FormCaptionAyarla();
            Tablo.RowFocus("Id", id);
        }

        protected virtual void DegiskenleriDoldur()
        {
        }

        protected virtual void ShowEditForm(long id)
        {
            var result = FormShow.ShowDialogEditForm(BaseKartTuru, id);
            ShowEditFormDefault(result);
        }

        protected virtual void BagliKartAc()
        {
        }

        protected virtual void EntityDelete()
        {
            var entity = Tablo.GetRow<BaseEntity>();
            if (entity == null) return;
            if (!((IBaseCommonBll)Bll).Delete(entity)) return;

            Tablo.DeleteSelectedRows();
            Tablo.RowFocus(Tablo.FocusedRowHandle);
        }

        protected virtual void Listele()
        {
        }

        protected virtual void Yazdir()
        {
            TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, AnaForm.SubeAdi);
        }

        protected virtual void BaskiOnizleme()
        {
        }

        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            Tablo.OptionsSelection.MultiSelect = MultiSelect;
            Navigator.NavigatableControl = Tablo.GridControl;

            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = DefaultCursor;

            Tablo.Appearance.ViewCaption.ForeColor =
                Color.FromArgb(AnaForm.KullaniciParametreleri.TableViewCaptionForeColor);
            Tablo.Appearance.HeaderPanel.ForeColor =
                Color.FromArgb(AnaForm.KullaniciParametreleri.TableColumnHeaderForeColor);
            if (Tablo is MyBandedGridView bandedGrid)
                bandedGrid.Appearance.BandPanel.ForeColor = Color.FromArgb(AnaForm.KullaniciParametreleri.TableBandPanelForeColor);
            else if (Tablo is BandedGridView bandedGrid2)
                bandedGrid2.Appearance.BandPanel.ForeColor = Color.FromArgb(AnaForm.KullaniciParametreleri.TableBandPanelForeColor);
        }

        protected virtual void TahakkukYap()
        {
        }

        protected virtual void BelgeHareketleri()
        {
        }

        protected virtual void Duzelt()
        {
        }

        #endregion Functions

        #region Events

        //Button events
        protected virtual void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnGonder)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnStandartExcelDosyasi)
                Tablo.TabloDisariAktar(DosyaTuru.ExcelStandart, e.Item.Caption, Text);
            else if (e.Item == btnFormatliExcelDosyasi)
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormatli, e.Item.Caption, Text);
            else if (e.Item == btnFormatsizExcelDosyasi)
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormatsiz, e.Item.Caption);
            else if (e.Item == btnWordDosyasi)
                Tablo.TabloDisariAktar(DosyaTuru.WordDosyasi, e.Item.Caption);
            else if (e.Item == btnPdfDosyasi)
                Tablo.TabloDisariAktar(DosyaTuru.PdfDosyasi, e.Item.Caption);
            else if (e.Item == btnTxtDosyasi)
                Tablo.TabloDisariAktar(DosyaTuru.TxtDosyasi, e.Item.Caption);
            else if (e.Item == btnYeni)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir)) return;

                ShowEditForm(-1);
            }
            else if (e.Item == btnDuzelt)
            {
                ShowEditForm(Tablo.GetRowId());
            }
            else if (e.Item == btnSil)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Silebilir)) return;

                EntityDelete();
            }
            else if (e.Item == btnSec)
            {
                SelectEntity();
            }
            else if (e.Item == btnYenile)
            {
                Listele();
            }
            else if (e.Item == btnFiltrele)
            {
                FiltreSec();
            }
            else if (e.Item == btnKolonlar)
            {
                if (Tablo.CustomizationForm == null)
                {
                    Tablo.ShowCustomization();
                }
                else
                {
                    Tablo.HideCustomization();
                }
            }
            else if (e.Item == btnTahakkukYap)
            {
                TahakkukYap();
            }
            else if (e.Item == btnBagliKartlar)
                BagliKartAc();
            else if (e.Item == btnParametreler)
                BagliKartAc();
            else if (e.Item == btnYazdir)
                Yazdir();
            else if (e.Item == btnBaskiOnizleme)
                BaskiOnizleme();
            else if (e.Item == btnTabloYazdir)
                TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, AnaForm.SubeAdi);
            else if (e.Item == btnTasarimDegistir)
                Duzelt();
            else if (e.Item == btnCikis)
                Close();
            else if (e.Item == btnAktifPasifKartlar)
            {
                AktifKartlariGoster = !AktifKartlariGoster;
                FormCaptionAyarla();
            }
            else if (e.Item == btnBelgeHareketleri)
                BelgeHareketleri();

            Cursor.Current = DefaultCursor;
        }

        //Table events
        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            if (Tablo.FocusedRowHandle < 0) return; //hata verebilir sonradan eklendi

            Cursor.Current = Cursors.WaitCursor;
            IslemTuruSec();
            Cursor.Current = DefaultCursor;
        }

        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    IslemTuruSec();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.SagMenuGoster(sagMenu);
        }

        private void Tablo_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            _tabloSablonKayıtEdilecek = true;
        }

        private void Tablo_ColumnPositionChanged(object sender, EventArgs e)
        {
            _tabloSablonKayıtEdilecek = true;
        }

        private void Tablo_EndSorting(object sender, EventArgs e)
        {
            _tabloSablonKayıtEdilecek = true;
        }

        private void Tablo_FilterEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.FilterControlEventArgs e)
        {
            if (!KartTuru.Filtre.YetkiKontrolu(YetkiTuru.Degistirebilir)) return;

            e.ShowFilterEditor = false;
            ShowEditForms<FiltreEditForm>.ShowDialogEditForm(KartTuru.Filtre, _filtreId, BaseKartTuru, Tablo.GridControl);
        }

        private void Tablo_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tablo.ActiveFilterString))
                _filtreId = 0;
        }

        private void Tablo_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (!Tablo.OptionsView.ShowFooter) return;
            if (e.Column.Summary.Count > 0 && e.Column.ColumnEdit != null)
                e.Appearance.TextOptions.HAlignment = e.Column.ColumnEdit.Appearance.HAlignment;//kolonun HAlignment değişmişse gird altındaki toplama aynı ayarı yansıt (ortala gibi)
            //sınıf formları (1:17:00) da anlatım(2bölüm)
        }

        private void Tablo_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            SutunGizleGoster();
        }

        private void Tablo_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SutunGizleGoster();
        }

        //Form events
        private void BaseListForm_Shown(object sender, EventArgs e)
        {
            Tablo.Focus();
            ButonGizleGoster();
            SutunGizleGoster();

            if (IsMdiChild || SeciliGelecekId == null) return;
            Tablo.RowFocus("Id", SeciliGelecekId);
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {
            SablonYukle();
        }

        private void BaseListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
        }

        private void BaseListForm_LocationChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayıtEdilecek = true;
        }

        private void BaseListForm_SizeChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayıtEdilecek = true;
        }

        #endregion Events
    }
}