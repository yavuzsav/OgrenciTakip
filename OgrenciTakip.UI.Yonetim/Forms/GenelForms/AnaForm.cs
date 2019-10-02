using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Security;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Data.Contexts;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base;
using YavuzSav.OgrenciTakip.UI.Win.Forms.DonemForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms;
using YavuzSav.OgrenciTakip.UI.Win.Forms.SubeForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Yonetim.Forms.GenelForms
{
    public partial class AnaForm : RibbonForm
    {
        private readonly string _server;
        private readonly SecureString _kullaniciAdi;
        private readonly SecureString _sifre;
        private readonly YetkilendirmeTuru _yetkilendirmeTuru;
        private readonly KurumBll _bll;

        public AnaForm(params object[] prm)
        {
            InitializeComponent();

            _server = prm[0].ToString();
            _kullaniciAdi = (SecureString)prm[1];
            _sifre = (SecureString)prm[2];
            _yetkilendirmeTuru = (YetkilendirmeTuru)prm[3];
            _bll = new KurumBll();

            longNavigator1.Navigator.NavigatableControl = tablo.GridControl;  //navigator girde balğadık
            EventsLoad();
            ButonEnabledDurum();
        }

        private void EventsLoad()
        {
            //button events
            foreach (BarItem button in ribbonControl1.Items)
                button.ItemClick += Button_ItemClick;

            //table events
            tablo.DoubleClick += Tablo_DoubleClick;
            tablo.KeyDown += Tablo_KeyDown;
            tablo.MouseUp += Tablo_MouseUp;
            tablo.RowCountChanged += Tablo_RowCountChanged;

            //form events
            FormClosing += AnaForm_FormClosing;
            Load += AnaForm_Load;
        }

        protected internal void Listele()
        {
            tablo.GridControl.DataSource = _bll.List(null);
        }

        protected virtual void ShowEditForm(long id)
        {
            GeneralFunctions.CreateConnectionString("OgrenciTakip_Yonetim", _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);

            var result = ShowEditForms<KurumEditForm>.ShowDialogEditForm(id, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            if (result <= 0) return;

            Listele();
            tablo.RowFocus("Id", result);
        }

        private void ButonEnabledDurum()
        {
            foreach (BarItem button in ribbonControl1.Items)
            {
                if (!(button is BarButtonItem item)) continue;
                if (item != btnYeni)
                    item.Enabled = tablo.DataRowCount > 0;
            }
        }

        private void EntityDelete(BaseEntity entity)
        {
            GeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            if (!Functions.GeneralFunctions.DeleteDataBase<OgrenciTakipYonetimContext>()) return;

            GeneralFunctions.CreateConnectionString("OgrenciTakip_Yonetim", _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            _bll.Delete(entity);
            tablo.DeleteSelectedRows();
            tablo.RowFocus(tablo.FocusedRowHandle);
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnYeni || e.Item == btnDuzelt)
            {
                if (e.Item == btnYeni)
                    ShowEditForm(-1);
                else if (e.Item == btnDuzelt)
                    ShowEditForm(tablo.GetRowId());
            }
            else
            {
                var entity = tablo.GetRow<Kurum>();
                if (entity == null) return;
                GeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);

                if (e.Item == btnSil)
                    EntityDelete(entity);
                else if (e.Item == btnEmailParametreleri)
                    ShowEditForms<EmailParametreEditForm>.ShowDialogEditForm();
                else if (e.Item == btnSubeKartlari)
                    ShowListForms<SubeListForm>.ShowDialogListForm();
                else if (e.Item == btnDonemKartlari)
                    ShowListForms<DonemListForm>.ShowDialogListForm();
                else if (e.Item == btnKurumBilgileri)
                    ShowEditForms<KurumBilgileriEditForm>.ShowDialogEditForm(null, entity.Kod, entity.KurumAdi);
                else if (e.Item == btnRolKartlari)
                    ShowListForms<RolListForm>.ShowDialogListForm();
                else if (e.Item == btnKullaniciKartlari)
                    ShowListForms<KullaniciListForm>.ShowDialogListForm();
                else if (e.Item == btnKullaniciBirimYetkileri)
                    ShowEditForms<KullaniciBirimYetkileriEditForm>.ShowDialogEditForm();
            }

            Cursor.Current = DefaultCursor;
        }

        private void Tablo_DoubleClick(object sender, System.EventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;
            ShowEditForm(tablo.GetRowId());
        }

        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ShowEditForm(tablo.GetRowId());
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.SagMenuGoster(popupMenuSag);
        }

        private void Tablo_RowCountChanged(object sender, System.EventArgs e)
        {
            ButonEnabledDurum();
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Messages.HayirSeciliEvetHayir("Programdan Çıkmak İstiyor musunuz?", "Çıkış Onay") == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }

        private void AnaForm_Load(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Listele();
            tablo.Focus();
            Cursor.Current = Cursors.Default;
        }
    }
}