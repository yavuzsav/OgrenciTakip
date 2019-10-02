using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.FiltreForms
{
    public partial class FiltreEditForm : BaseEditForm
    {
        private readonly KartTuru _filtreKartTuru;
        private readonly GridControl _filtreGrid;

        public FiltreEditForm(params object[] prm)
        {
            InitializeComponent();

            _filtreKartTuru = (KartTuru)prm[0];
            _filtreGrid = (GridControl)prm[1];

            HideItems = new BarItem[] { btnYeni, btnGerial };
            ShowItems = new BarItem[] { btnFarkliKaydet, btnUygula };

            DataLayoutControl = myDataLayoutControl1;
            Bll = new FiltreBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.Filtre;
            EventsLoad();
        }

       public override void Yukle()
        {
            txtFiltreMetni.SourceControl = _filtreGrid;

            while (true)
            {
                if (BaseIslemTuru == IslemTuru.EntityInsert)
                {
                    OldEntity = new Filtre();
                    Id = BaseIslemTuru.IdOlustur(OldEntity);
                    txtKod.Text = ((FiltreBll)Bll).YeniKodVer(x => x.KartTuru == _filtreKartTuru);
                }
                else
                {
                    OldEntity = ((FiltreBll)Bll).Single(FilterFunctions.Filter<Filtre>(Id));
                    if (OldEntity == null)
                    {
                        BaseIslemTuru = IslemTuru.EntityInsert;
                        continue;
                    }

                    NesneyiKontrollereBagla();
                }

                break;
            }
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Filtre)OldEntity;

            txtKod.Text = entity.Kod;
            txtFiltreAdi.Text = entity.FiltreAdi;
            txtFiltreMetni.FilterString = entity.FiltreMetni;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Filtre
            {
                Id = Id,
                Kod = txtKod.Text,
                FiltreAdi = txtFiltreAdi.Text,
                FiltreMetni = txtFiltreMetni.FilterString,
                KartTuru = _filtreKartTuru
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((FiltreBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KartTuru == _filtreKartTuru);
        }

        protected override bool EntityUpdate()
        {
            return ((FiltreBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KartTuru == _filtreKartTuru);
        }

        protected override void FiltreUygula()
        {
            txtFiltreMetni.Select();
            txtFiltreMetni.ApplyFilter();
        }

        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledDurumu(btnKaydet, btnFarkliKaydet, btnSil, BaseIslemTuru, OldEntity, CurrentEntity);
        }
    }
}