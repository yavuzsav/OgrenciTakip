using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.UI.Win.Forms.KullaniciForms;
using YavuzSav.OgrenciTakip.UI.Win.UserControls.UserControl.Base;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.UserControls.UserControl.KullaniciBirimYetkileriEditFormTable
{
    public partial class KullaniciTable : BaseTablo
    {
        public KullaniciTable()
        {
            InitializeComponent();

            Bll = new KullaniciBll();
            Tablo = tablo;
            EventsLoad();

            HideItems = new BarItem[] { btnHaraketEkle, btnHareketSil };
            insUptNavigator.Navigator.Buttons.Append.Visible = false;
            insUptNavigator.Navigator.Buttons.Remove.Visible = false;
            insUptNavigator.Navigator.Buttons.PrevPage.Visible = true;
            insUptNavigator.Navigator.Buttons.NextPage.Visible = true;
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KullaniciBll)Bll).List(null);
        }

        protected override void HareketSil()
        {
            //override etmemizin sebebi shift+delete'ye bastığımız zaman kartı silmeye çalışmaması için
        }

        protected override void Tablo_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            //(6/6) 29.video 12:00
            //bu tablodaki griddeki hangi satır seçilirse o satırın yetkilerini getirmesi için değişikliği yakalamak için 
            var entity = tablo.GetRow<KullaniciL>();
            if(entity==null) return;

            OwnerForm.Id = entity.Id;  //owner forma kullanıcının id'si atanır sube ve donem table'da ona göre filtrelenir
            ((KullaniciBirimYetkileriEditForm)OwnerForm).Yukle();
        }
    }
}