using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Functions;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.FaturaForms
{
    public partial class FaturaTahakkukEditForm : BaseEditForm
    {
        public FaturaTahakkukEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            BaseKartTuru = KartTuru.Fatura;
            EventsLoad();

            HideItems = new BarItem[] { btnYeni, btnSil };
            ShowItems = new BarItem[] { btnYazdir };
            txtKdvSekli.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KdvSekli>());
            txtFaturaAdresi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AdresTuru>());
            KayitSonrasiFormuKapat = false;
        }

       public override void Yukle()
        {
            txtKdvSekli.SelectedItem = KdvSekli.Dahil.ToName();   //seçili gelmesi için
            txtFaturaAdresi.SelectedItem = AdresTuru.EvAdresi.ToName();  //ev adresi seçili gelmesi için
            FaturaDonemiYukle();
            FaturaNoYukle();
            TabloYukle();
        }

        private void FaturaDonemiYukle()
        {
            using (var bll = new FaturaBll())
            {
                var list = bll.FaturaDonemList(x => x.Tahakkuk.SubeId == AnaForm.SubeId && x.Tahakkuk.DonemId == AnaForm.DonemId);
                list.ForEach(x => txtFaturaDonemi.Properties.Items.Add(x.Date.ToString("d")));
            }
        }

        private void FaturaNoYukle()
        {
            using (var bll = new FaturaBll())
            {
                txtSonFaturaNo.Value = bll.MaxFaturaNo(x => x.Tahakkuk.SubeId == AnaForm.SubeId && x.Tahakkuk.DonemId == AnaForm.DonemId);
                txtFaturaNo.Value = txtSonFaturaNo.Value + 1;
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            GeneralFunctions.ButtonEnabledDurumu(btnKaydet, btnGerial, faturaTahakkukTable.TableValueChanged);
        }

        protected override void TabloYukle()
        {
            faturaTahakkukTable.OwnerForm = this;
            faturaTahakkukTable.Yukle();
        }

        protected override bool EntityUpdate()
        {
            if (!faturaTahakkukTable.Kaydet()) return false;

            faturaTahakkukTable.Yukle();
            FaturaNoYukle();
            return true;
        }

        protected override void Yazdir()
        {
            var source = new List<FaturaR>();

            for (int i = 0; i < faturaTahakkukTable.Tablo.DataRowCount; i++)
            {
                var entity = faturaTahakkukTable.Tablo.GetRow<FaturaPlaniL>(i);
                if (entity == null) return;

                var row = new FaturaR
                {
                    OkulNo = entity.OkulNo,
                    TcKimlikNo = entity.TcKimlikNo,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    SinifAdi = entity.SinifAdi,
                    VeliTcKimlikNo = entity.VeliTcKimlikNo,
                    VeliAdi = entity.VeliAdi,
                    VeliSoyadi = entity.VeliSoyadi,
                    VeliYakinlikAdi = entity.VeliYakinlikAdi,
                    VeliMeslekAdi = entity.VeliMeslekAdi,
                    FaturaAdres = entity.FaturaAdres,
                    FaturaAdresIlAdi = entity.FaturaAdresIlAdi,
                    FaturaAdresIlceAdi = entity.FaturaAdresIlceAdi,
                    Aciklama = entity.Aciklama,
                    Tarih = entity.TahakkukTarih,
                    FaturaNo = entity.FaturaNo,
                    Tutar = entity.TahakkukTutar,
                    Indirim = entity.TahakkukIndirimTutar,
                    NetTutar = entity.TahakkukNetTutar,
                    KdvSekli = entity.KdvSekli,
                    KdvOrani = entity.KdvOrani,
                    KdvHaricTutar = entity.KdvHaricTutar,
                    KdvTutari = entity.KdvTutari,
                    ToplamTutar = entity.ToplamTutar,
                    TutarYazi = entity.TutarYazi,
                    Sube = entity.Sube,
                    Donem = entity.Donem,
                };

                source.Add(row);
            }

            ShowListForms<RaporSecim>.ShowDialogListForm(KartTuru.Rapor, false, RaporBolumTuru.FaturaDonemRaporlari, source);
        }

        protected override void Control_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender != txtFaturaDonemi) return;

            faturaTahakkukTable.Listele();
            faturaTahakkukTable.Tablo.Focus();
        }
    }
}