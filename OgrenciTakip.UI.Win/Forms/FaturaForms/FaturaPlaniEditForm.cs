﻿using DevExpress.XtraBars;
using System;
using System.Linq;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.FaturaForms
{
    public partial class FaturaPlaniEditForm : BaseEditForm
    {
        //private readonly long _tahakkukId;

        public FaturaPlaniEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            BaseKartTuru = KartTuru.Fatura;
            EventsLoad();

            HideItems = new BarItem[] { btnYeni };
            btnSil.Caption = "İptal Et";
        }

        //public FaturaPlaniEditForm(params object[] prm) : this()
        //{
        //    _tahakkukId = (long)prm[0];
        //}

       public override void Yukle()
        {
            TabloYukle();

            using (var bll = new HizmetBilgileriBll())
            {
                var list = bll.FaturaPlaniList(x => x.TahakkukId == Id).ToList();  //.ToList() ile index almasını sağlıyoruz

                txtOgrenciNo.Text = list[0].OkulNo;
                txtAdi.Text = list[0].Adi;
                txtSoyadi.Text = list[0].Soyadi;
                txtSinif.Text = list[0].SinifAdi;
                txtVeliAdi.Text = list[0].VeliAdi;
                txtVeliSoyadi.Text = list[0].VeliSoyadi;
                txtYakinlik.Text = list[0].VeliYakinlikAdi;
                txtMeslek.Text = list[0].VeliMeslekAdi;

                tablo.GridControl.DataSource = list;
                Id = list[0].TahakkukId;
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            GeneralFunctions.ButtonEnabledDurumu(btnKaydet, btnGerial, faturaPlaniTable.TableValueChanged);
        }

        protected override void TabloYukle()
        {
            faturaPlaniTable.OwnerForm = this;
            faturaPlaniTable.Yukle();
        }

        protected override bool EntityInsert()
        {
            return faturaPlaniTable.Kaydet();
        }

        protected override bool EntityUpdate()
        {
            return faturaPlaniTable.Kaydet();
        }

        protected override void EntityDelete()
        {
            if (Messages.HayirSeciliEvetHayir("Fatura Planı İptal Edilecek. Onaylıyor musunuz?", "İptal Onay") != DialogResult.Yes) return;

            var source = faturaPlaniTable.Tablo.DataController.ListSource.Cast<FaturaPlaniL>().Where(x => x.TahakkukTarih == null).ToList();
            //faturası kesilmiş tahakkuku yapılmış faturaya iptal etmesin ama tahakkuk tarihi girilmemiş yani tahakkuku yapılmamış faturayı iptal etsin yukarısı (5/6) 7.video 39:00
            if (source.Count == 0) return;

            source.ForEach(x => x.Delete = true); //source içinde dolaş ve delete property lerini true yap
            faturaPlaniTable.Tablo.RefreshDataSource();  //RefreshDataSource() içinde kod ile delete olarak işaretlenen satırlar gizlenir
            faturaPlaniTable.TableValueChanged = true;  //table valuede bir değişiklik olduğunu bildiriyoruz
            ButonEnabledDurumu();       //TableValueChanged true olduğu için butonenabledurumu devreye girecek ve butonlarda ayarlama yapacak
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            faturaPlaniTable.Tablo.Focus(); //sayfa açıldığında faturaPlanitable'a focuslansın
        }
    }
}