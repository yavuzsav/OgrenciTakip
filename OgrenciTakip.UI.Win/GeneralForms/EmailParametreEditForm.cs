using DevExpress.XtraBars;
using YavuzSav.OgrenciTakip.Business.Functions;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Functions;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class EmailParametreEditForm : BaseEditForm
    {
        public EmailParametreEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new MailParametreBll(myDataLayoutControl1);
            HideItems = new BarItem[] { btnYeni, btnSil };
            txtSslKullan.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = ((MailParametreBll)Bll).Single(null) ?? new MailParametre();
            ((MailParametre)OldEntity).Sifre = "Bu Email Şifresidir".Encrypt(OldEntity.Id + OldEntity.Kod);

            BaseIslemTuru = OldEntity.Id == 0 ? IslemTuru.EntityInsert : IslemTuru.EntityUpdate;
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = "Email";
            txtEmail.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (MailParametre)OldEntity;

            Id = entity.Id;
            txtKod.Text = entity.Kod;
            txtEmail.Text = entity.Email;
            txtSifre.Text = BaseIslemTuru == IslemTuru.EntityInsert
                ? null
                : entity.Sifre.Decrypt(entity.Id + entity.Kod);
            txtPortNo.Value = entity.PortNo;
            txtHost.Text = entity.Host;
            txtSslKullan.SelectedItem = entity.SslKullan.ToName();
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new MailParametre
            {
                Id = Id,
                Kod = txtKod.Text,
                Email = txtEmail.Text,
                Sifre = string.IsNullOrWhiteSpace(txtSifre.Text) ? null : txtSifre.Text.Encrypt(Id + txtKod.Text),
                PortNo = (int)txtPortNo.Value,
                Host = txtHost.Text,
                SslKullan = txtSslKullan.Text.GetEnum<EvetHayir>()
            };

            ButonEnabledDurumu();
        }
    }
}