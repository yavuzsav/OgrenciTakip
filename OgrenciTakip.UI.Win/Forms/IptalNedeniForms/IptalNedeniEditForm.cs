using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.IptalNedeniForms
{
    public partial class IptalNedeniEditForm : BaseEditForm
    {
        public IptalNedeniEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new IptalNedeniBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.IptalNedeni;
            EventsLoad();
        }

       public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new IptalNedeni() : ((IptalNedeniBll)Bll).Single(FilterFunctions.Filter<IptalNedeni>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IptalNedeniBll)Bll).YeniKodVer();
            txtIptalNedeniAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IptalNedeni)OldEntity;

            txtKod.Text = entity.Kod;
            txtIptalNedeniAdi.Text = entity.IptalNedeniAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new IptalNedeni
            {
                Id = Id,
                Kod = txtKod.Text,
                IptalNedeniAdi = txtIptalNedeniAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}