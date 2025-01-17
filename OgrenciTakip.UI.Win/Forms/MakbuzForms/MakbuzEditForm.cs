﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using YavuzSav.OgrenciTakip.Business.General;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Functions;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.BaseForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.Forms.MakbuzForms
{
    public partial class MakbuzEditForm : BaseEditForm
    {
        protected internal readonly MakbuzTuru MakbuzTuru;
        private readonly MakbuzHesapTuru _makbuzHesapTuru;

        public MakbuzEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl1;
            Bll = new MakbuzBll(myDataLayoutControl1);
            BaseKartTuru = KartTuru.Makbuz;
            EventsLoad();

            HideItems = new BarItem[] { btnYeni };
            ShowItems = new BarItem[] { btnYazdir };

            KayitSonrasiFormuKapat = false;

            MakbuzTuru = (MakbuzTuru)prm[0];
            _makbuzHesapTuru = (MakbuzHesapTuru)prm[1];
            FarkliSubeIslemi = prm.Length > 2 && (bool)prm[2];
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new MakbuzS() : ((MakbuzBll)Bll).Single(FilterFunctions.Filter<Makbuz>(Id));
            AlanIslemleri();
            NesneyiKontrollereBagla();
            TabloYukle();
            MakbuzTuruEnabled();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtMakbuzNo.Text = ((MakbuzBll)Bll).YeniKodVer(x => x.DonemId == AnaForm.DonemId && x.SubeId == AnaForm.SubeId);
            txtTarih.DateTime = DateTime.Now.Date;
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (MakbuzS)OldEntity;

            txtMakbuzNo.Text = entity.Kod;
            txtTarih.DateTime = entity.Tarih;
            txtHesapTuru.SelectedItem = _makbuzHesapTuru.ToName();

            if (BaseIslemTuru == IslemTuru.EntityInsert)
            {
                switch (_makbuzHesapTuru)
                {
                    case MakbuzHesapTuru.Kasa when AnaForm.KullaniciParametreleri.DefaultKasaHesapId != null:
                        txtHesap.Id = AnaForm.KullaniciParametreleri.DefaultKasaHesapId;
                        txtHesap.Text = AnaForm.KullaniciParametreleri.DefaultKasaHesapAdi;
                        break;

                    case MakbuzHesapTuru.Banka when AnaForm.KullaniciParametreleri.DefaultBankaHesapId != null:
                        txtHesap.Id = AnaForm.KullaniciParametreleri.DefaultBankaHesapId;
                        txtHesap.Text = AnaForm.KullaniciParametreleri.DefaultBankaHesapAdi;
                        break;

                    case MakbuzHesapTuru.Avukat when AnaForm.KullaniciParametreleri.DefaultAvukatHesapId != null:
                        txtHesap.Id = AnaForm.KullaniciParametreleri.DefaultAvukatHesapId;
                        txtHesap.Text = AnaForm.KullaniciParametreleri.DefaultAvukatHesapAdi;
                        break;

                    case MakbuzHesapTuru.Transfer when MakbuzTuru == MakbuzTuru.GelenBelgeyiOnaylama:
                        txtHesap.Id = AnaForm.SubeId;
                        txtHesap.Text = AnaForm.SubeAdi;
                        break;
                }
            }
            else
            {
                txtHesap.Id = entity.AvukatHesapId ?? entity.BankaHesapId ?? entity.CariHesapId ?? entity.KasaHesapId ?? entity.SubeHesapId; //null değil ise ata null ise yandakini kontrol et
                txtHesap.Text = entity.HesapAdi;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var hesapTuru = txtHesapTuru.Text.GetEnum<MakbuzHesapTuru>();

            CurrentEntity = new Makbuz
            {
                Id = Id,
                Kod = txtMakbuzNo.Text,
                Tarih = txtTarih.DateTime.Date,
                MakbuzTuru = MakbuzTuru,
                MakbuzHesapTuru = hesapTuru,
                AvukatHesapId = hesapTuru == MakbuzHesapTuru.Avukat ? txtHesap.Id : null,
                BankaHesapId = hesapTuru == MakbuzHesapTuru.Banka || hesapTuru == MakbuzHesapTuru.Epos || hesapTuru == MakbuzHesapTuru.Ots || hesapTuru == MakbuzHesapTuru.Pos ? txtHesap.Id : null,
                CariHesapId = hesapTuru == MakbuzHesapTuru.Cari || hesapTuru == MakbuzHesapTuru.Mahsup ? txtHesap.Id : null,
                KasaHesapId = hesapTuru == MakbuzHesapTuru.Kasa ? txtHesap.Id : null,
                SubeHesapId = hesapTuru == MakbuzHesapTuru.Transfer ? txtHesap.Id : null,
                HareketSayisi = makbuzHareketleriTable.Tablo.DataRowCount,
                MakbuzToplami = decimal.Parse(makbuzHareketleriTable.colIslemTutari.SummaryText),
                DonemId = AnaForm.DonemId,
                SubeId = AnaForm.SubeId,
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            if (HataliGiris()) return false; //hata olursa 1 alta al
            GuncelNesneOlustur();
            if (makbuzHareketleriTable.HataliGiris()) return false;
            var result = ((MakbuzBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId) && makbuzHareketleriTable.Kaydet();

            if (result && !KayitSonrasiFormuKapat)
                makbuzHareketleriTable.Yukle();

            return result;
        }

        protected override bool EntityUpdate()
        {
            if (HataliGiris()) return false; //hata olursa 1 alta al
            GuncelNesneOlustur();
            if (makbuzHareketleriTable.HataliGiris()) return false;
            var result = ((MakbuzBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId) && makbuzHareketleriTable.Kaydet();

            if (result && !KayitSonrasiFormuKapat)
                makbuzHareketleriTable.Yukle();

            return result;
        }

        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;

            if (FarkliSubeIslemi)
                GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil);
            else
                GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity, makbuzHareketleriTable.TableValueChanged);
        }

        protected override void EntityDelete()
        {
            if (!makbuzHareketleriTable.TopluHareketSil()) return;
            if (!((MakbuzBll)Bll).Delete(OldEntity)) return;
            RefreshYapilacakMi = true;
            Close();
        }

        protected internal bool HataliGiris()
        {
            if (!txtHesap.Visible || txtHesap.Id != null) return false;
            Messages.SecimHataMesaji("Hesap");

            txtHesap.Focus();
            return true;
        }

        private void AlanIslemleri()
        {
            Text = $"{Text} - {MakbuzTuru.ToName()}";
            txtTarih.Properties.MinValue = AnaForm.DonemParametreleri.GunTarihininOncesineMakbuzTarihiGirilebilir ? AnaForm.DonemParametreleri.DonemBaslamaTarihi : DateTime.Now.Date;
            txtTarih.Properties.MaxValue = AnaForm.DonemParametreleri.GunTarihininSonrasinaMakbuzTarihiGirilebilir ? AnaForm.DonemParametreleri.DonemBitisTarihi : DateTime.Now.Date;

            switch (MakbuzTuru)
            {
                case MakbuzTuru.BlokeyeAlma:
                case MakbuzTuru.BlokeCozumu:
                    txtHesapTuru.Properties.Items.AddRange(Enum.GetValues(typeof(MakbuzHesapTuru)).Cast<MakbuzHesapTuru>()
                        .Where(x => x == MakbuzHesapTuru.Epos || x == MakbuzHesapTuru.Ots || x == MakbuzHesapTuru.Pos).Select(x => x.ToName()).ToList());
                    break;

                case MakbuzTuru.PortfoyeGeriIade:
                case MakbuzTuru.PortfoyeKarsiliksizIade:
                    txtHesapTuru.Properties.Items.AddRange(Enum.GetValues(typeof(MakbuzHesapTuru)).Cast<MakbuzHesapTuru>()
                        .Where(x => x == MakbuzHesapTuru.Avukat || x == MakbuzHesapTuru.Banka || x == MakbuzHesapTuru.Cari).Select(x => x.ToName()).ToList());
                    break;

                case MakbuzTuru.OdenmisOlarakIsaretleme:
                case MakbuzTuru.KarsiliksizOlarakIsaretleme:
                case MakbuzTuru.MusteriyeGeriIade:
                case MakbuzTuru.TahsiliImkansizHaleGelme:
                    txtHesapTuru.Properties.Items.Add(_makbuzHesapTuru.ToName());
                    layoutHesapAdi.Visibility = LayoutVisibility.Never;
                    break;

                default:
                    txtHesapTuru.Properties.Items.Add(_makbuzHesapTuru.ToName());
                    break;
            }
        }

        protected internal void MakbuzTuruEnabled()
        {
            switch (MakbuzTuru)
            {
                case MakbuzTuru.BlokeyeAlma:
                case MakbuzTuru.BlokeCozumu:
                case MakbuzTuru.PortfoyeGeriIade:
                case MakbuzTuru.PortfoyeKarsiliksizIade:
                case MakbuzTuru.AvukataGonderme:
                case MakbuzTuru.AvukatYoluylaTahsilEtme:
                case MakbuzTuru.BankayaTahsileGonderme:
                case MakbuzTuru.BankaYoluylaTahsilEtme:
                case MakbuzTuru.CiroEtme:
                case MakbuzTuru.BaskaSubeyeGonderme:
                    txtHesap.Enabled = makbuzHareketleriTable.Tablo.DataRowCount == 0;
                    txtHesapTuru.Enabled = makbuzHareketleriTable.Tablo.DataRowCount == 0;
                    break;

                case MakbuzTuru.GelenBelgeyiOnaylama:
                    txtHesapTuru.Enabled = false;
                    txtHesap.Enabled = false;
                    break;
            }
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
            {
                switch (txtHesapTuru.Text.GetEnum<MakbuzHesapTuru>())
                {
                    case MakbuzHesapTuru.Avukat:
                        sec.Sec(txtHesap, KartTuru.Avukat);
                        break;

                    case MakbuzHesapTuru.Banka:
                        sec.Sec(txtHesap, KartTuru.BankaHesap, BankaHesapTuru.VadesizMevduatHesabi);
                        break;

                    case MakbuzHesapTuru.Cari:
                    case MakbuzHesapTuru.Mahsup:
                        sec.Sec(txtHesap, KartTuru.Cari);
                        break;

                    case MakbuzHesapTuru.Epos:
                        sec.Sec(txtHesap, KartTuru.BankaHesap, BankaHesapTuru.EposBlokeHesabi);
                        break;

                    case MakbuzHesapTuru.Ots:
                        sec.Sec(txtHesap, KartTuru.BankaHesap, BankaHesapTuru.OtsBlokeHesabi);
                        break;

                    case MakbuzHesapTuru.Pos:
                        sec.Sec(txtHesap, KartTuru.BankaHesap, BankaHesapTuru.PosBlokeHesabi);
                        break;

                    case MakbuzHesapTuru.Kasa:
                        sec.Sec(txtHesap, KartTuru.Kasa);
                        break;

                        //case MakbuzHesapTuru.Transfer:
                        //    sec.Sec(txtHesap, KartTuru.Sube);
                        //    break;
                }
            }
        }

        protected override void TabloYukle()
        {
            makbuzHareketleriTable.OwnerForm = this;
            makbuzHareketleriTable.Yukle();
        }

        protected override void Yazdir()
        {
            var source = new List<MakbuzHareketleriR>();
            for (int i = 0; i < makbuzHareketleriTable.Tablo.DataRowCount; i++)
            {
                var entity = makbuzHareketleriTable.Tablo.GetRow<MakbuzHareketleriL>(i);
                if (entity == null) return;

                var row = new MakbuzHareketleriR
                {
                    OgrenciNo = entity.OgrenciNo,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    SinifAdi = entity.SinifAdi,
                    SubeAdi = entity.OgrenciSubeAdi,
                    PortfotNo = entity.OdemeBilgileriId,
                    OdemeTuruAdi = entity.OdemeTuruAdi,
                    Vade = entity.Vade,
                    AsilBorclu = entity.AsilBorclu,
                    Ciranta = entity.Ciranta,
                    BankaVeSubeAdi = entity.BankaAdi + " / " + entity.BankaSubeAdi,
                    BelgeNo = entity.BelgeNo,
                    HesapNo = entity.HesapNo,
                    Tutar = entity.Tutar,
                    IslemOncesiTutar = entity.IslemOncesiTutar,
                    IslemTutari = entity.IslemTutari,
                    Tarih = txtTarih.DateTime.Date,
                    MakbuzNo = txtMakbuzNo.Text,
                    MakbuzTuru = MakbuzTuru.ToName(),
                    HesapTuru = _makbuzHesapTuru.ToName(),
                    HesapAdi = txtHesap.Text,
                    BelgeDurumu = entity.BelgeDurumu.ToName()
                };

                source.Add(row);
            }

            ShowListForms<RaporSecim>.ShowDialogListForm(KartTuru.Rapor, false, RaporBolumTuru.MakbuzRaporlari, source);
        }

        protected override void Control_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender != txtHesapTuru) return;
            txtHesap.Id = null;
            txtHesap.Text = null;
            txtHesap.Focus();
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            //yüklendikten sonra tetiklenir default hesap türü seçilmişte tabloya focuslansın seçilmemişse hesap türüne focuslansın
            if (layoutHesapAdi.Visible && txtHesap.Id == null)
                txtHesap.Focus();
            else
                makbuzHareketleriTable.Tablo.GridControl.Focus();
        }
    }
}