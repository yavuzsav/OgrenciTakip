using DevExpress.XtraBars;
using System;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms
{
    public partial class KullaniciBirimYetkileriEditForm : BaseEditForm
    {
        public KullaniciBirimYetkileriEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            HideItems = new BarItem[] { btnYeni, btnSil, btnKaydet, btnGerial };
            EventsLoad();
            TabloYukle();
        }

        public override void Yukle()
        {
            subeTable.Yukle();
            donemTable.Yukle();
        }

        protected internal override void ButonEnabledDurumu()
        {
            //devre dışı bırakmak için override ettik
        }

        protected override void TabloYukle()
        {
            kullaniciTable.OwnerForm = this;
            subeTable.OwnerForm = this;
            donemTable.OwnerForm = this;

            kullaniciTable.Yukle();
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            kullaniciTable.Tablo.Focus();
        }
    }
}