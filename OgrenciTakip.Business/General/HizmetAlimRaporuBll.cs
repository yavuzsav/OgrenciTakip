using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Data.Contexts;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class HizmetAlimRaporuBll : BaseBll<Tahakkuk, OgrenciTakipContext>
    {
        public IEnumerable<HizmetAlimRaporL> List(Expression<Func<Tahakkuk, bool>> filter, IEnumerable<long> hizmetTurleri, HizmetAlimDurumu hizmetAlimDurumu)
        {
            return BaseList(filter, x => new
            {
                Tahakkuk = x,

                VeliBilgileri = x.IletisimBilgileri.Where(y => y.Veli).Select(y => new
                {
                    y.Iletisim,
                    y.Yakinlik,
                }).FirstOrDefault(),

                HizmetAlimDurumu = x.HizmetBilgileri.Where(y => hizmetTurleri.Contains(y.HizmetId) && !y.IptalEdildi).GroupBy(y => y.TahakkukId).Any(),

            }).Where(x => hizmetAlimDurumu == HizmetAlimDurumu.HizmetiAlanlar ? x.HizmetAlimDurumu : !x.HizmetAlimDurumu).Select(x => new HizmetAlimRaporL
            {
                OgrenciId = x.Tahakkuk.OgrenciId,
                TahakkukId = x.Tahakkuk.Id,
                OgrenciNo = x.Tahakkuk.Kod,
                OkulNo = x.Tahakkuk.OkulNo,
                TcKimlikNo = x.Tahakkuk.Ogrenci.TcKimlikNo,
                Adi = x.Tahakkuk.Ogrenci.Adi,
                Soyadi = x.Tahakkuk.Ogrenci.Soyadi,
                Cinsiyet = x.Tahakkuk.Ogrenci.Cinsiyet,
                KayitTarihi = x.Tahakkuk.KayitTarihi,
                KayitSekli = x.Tahakkuk.KayitSekli,
                KayitDurumu = x.Tahakkuk.KayitDurumu,
                IptalDurumu = x.Tahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi,
                SinifAdi = x.Tahakkuk.Sinif.SinifAdi,
                GeldigiOkulAdi = x.Tahakkuk.GeldigiOkul.OkulAdi,
                KontenjanAdi = x.Tahakkuk.Kontentaj.KontenjanAdi,
                YabanciDilAdi = x.Tahakkuk.YabanciDil.DilAdi,
                RehberAdi = x.Tahakkuk.Rehber.AdiSoyadi,
                TesvikAdi = x.Tahakkuk.Tesvik.TesvikOrani,
                SubeId = x.Tahakkuk.SubeId,
                SubeAdi = x.Tahakkuk.Sube.SubeAdi,
                DonemId = x.Tahakkuk.DonemId,
                OzelKod1Adi = x.Tahakkuk.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.Tahakkuk.OzelKod2.OzelKodAdi,
                OzelKod3Adi = x.Tahakkuk.OzelKod3.OzelKodAdi,
                OzelKod4Adi = x.Tahakkuk.OzelKod4.OzelKodAdi,
                OzelKod5Adi = x.Tahakkuk.OzelKod5.OzelKodAdi,
                VeliAdi = x.VeliBilgileri.Iletisim.Adi,
                VeliSoyadi = x.VeliBilgileri.Iletisim.Soyadi,
                VeliYakinlikAdi = x.VeliBilgileri.Yakinlik.YakinlikAdi,
                VeliMeslekAdi = x.VeliBilgileri.Iletisim.Meslek.MeslekAdi,
                VeliIsyeriAdi = x.VeliBilgileri.Iletisim.Isyeri.IsyeriAdi,
                VeliGorevAdi = x.VeliBilgileri.Iletisim.Gorev.GorevAdi,
            }).OrderBy(x => x.OgrenciNo).ToList();
        }
    }
}