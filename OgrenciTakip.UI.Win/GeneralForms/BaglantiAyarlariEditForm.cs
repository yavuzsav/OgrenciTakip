using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Linq;
using YavuzSav.OgrenciTakip.Business.Functions;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Functions;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using GeneralFunctions = YavuzSav.OgrenciTakip.UI.Win.Functions.GeneralFunctions;

namespace YavuzSav.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class BaglantiAyarlariEditForm : BaseEditForm
    {
        public BaglantiAyarlariEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl1;
            HideItems = new BarItem[] { btnYeni, btnSil };
            txtYetkilendirmeTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<YetkilendirmeTuru>());
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = new BaglantiAyarlari
            {
                Server = ConfigurationManager.AppSettings["Server"],
                YetkilendirmeTuru = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>(),
                KullaniciAdi = ConfigurationManager.AppSettings["KullaniciAdi"].ConvertToSecureString(),
                Sifre = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>() == YetkilendirmeTuru.SqlServerYetkilendirmesi ? "Burası Şifre Alanıdır".ConvertToSecureString() : "".ConvertToSecureString()
            };

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            txtServer.Text = ConfigurationManager.AppSettings["Server"];
            txtYetkilendirmeTuru.SelectedItem = ConfigurationManager.AppSettings["YetkilendirmeTuru"];
            txtKullaniciAdi.Text = ConfigurationManager.AppSettings["KullaniciAdi"];
            txtSifre.Text =
                ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>() ==
                YetkilendirmeTuru.SqlServerYetkilendirmesi
                    ? "Burası Şifre Alanıdır"
                    : "";
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new BaglantiAyarlari
            {
                Server = txtServer.Text,
                YetkilendirmeTuru = txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>(),
                KullaniciAdi = txtKullaniciAdi.Text.ConvertToSecureString(),
                Sifre = txtSifre.Text.ConvertToSecureString(),
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityUpdate()
        {
            var list = Business.Functions.GeneralFunctions.DegisenAlanlariGetir(OldEntity, CurrentEntity).ToList();

            list.ForEach(x =>
            {
                switch (x)
                {
                    case "Server":
                        GeneralFunctions.AppSettingsWrite(x, txtServer.Text); //gelen x bir stringdir
                        break;

                    case "YetkilendirmeTuru":
                        GeneralFunctions.AppSettingsWrite(x, txtYetkilendirmeTuru.Text);
                        break;

                    case "KullaniciAdi":
                        GeneralFunctions.AppSettingsWrite(x, txtKullaniciAdi.Text);
                        break;

                    case "Sifre":
                        GeneralFunctions.AppSettingsWrite(x, txtSifre.Text);
                        break;
                }
            });

            return true;
        }

        protected override void Control_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(sender is ComboBoxEdit edit)) return;

            var yetkilendirmeTuru = edit.Text.GetEnum<YetkilendirmeTuru>();
            txtKullaniciAdi.Enabled = yetkilendirmeTuru == YetkilendirmeTuru.SqlServerYetkilendirmesi;
            txtSifre.Enabled = yetkilendirmeTuru == YetkilendirmeTuru.SqlServerYetkilendirmesi;
            txtKullaniciAdi.Focus();

            if (yetkilendirmeTuru != YetkilendirmeTuru.WindowsYetkilendirmesi) return;
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }
    }
}