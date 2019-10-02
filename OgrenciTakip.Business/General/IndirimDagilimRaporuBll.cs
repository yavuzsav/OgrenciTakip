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
    public class IndirimDagilimRaporuBll : BaseBll<Tahakkuk, OgrenciTakipContext>
    {
        public IEnumerable<IndirimDagilimRaporL> List(Expression<Func<Tahakkuk, bool>> filter, IEnumerable<long> indirimTurleri)
        {
            return BaseList(filter, x => new
            {
                Tahakkuk = x,

                VeliBilgileri = x.IletisimBilgileri.Where(p => p.Veli).Select(p => new
                {
                    p.Iletisim,
                    p.Yakinlik
                }).FirstOrDefault(),

                IndirimBilgileri = x.IndirimBilgileri.Where(y => indirimTurleri.Contains(y.IndirimId)).GroupBy(y => y.TahakkukId).DefaultIfEmpty().Select(y => new
                {
                    BrutIndirim = y.Select(p => p.BrutIndirim).DefaultIfEmpty(0).Sum(),
                    KistDonemDusulenIndirim = y.Select(p => p.KistDonemDusulenIndirim).DefaultIfEmpty(0).Sum(),
                    NetIndirim = y.Select(p => p.NetIndirim).DefaultIfEmpty(0).Sum()
                }).FirstOrDefault(),

            }).Where(x => x.IndirimBilgileri.BrutIndirim > 0).Select(x => new IndirimDagilimRaporL
            {
                OgrenciId = x.Tahakkuk.OgrenciId,
                TahakkukId = x.Tahakkuk.Id,
                OgrenciNo = x.Tahakkuk.Kod,
                OkulNo = x.Tahakkuk.OkulNo,
                TcKimlikNo = x.Tahakkuk.Ogrenci.TcKimlikNo,
                Adi = x.Tahakkuk.Ogrenci.Adi,
                Soyadi = x.Tahakkuk.Ogrenci.Soyadi,
                Cinsiyet = x.Tahakkuk.Ogrenci.Cinsiyet,
                Telefon = x.Tahakkuk.Ogrenci.Telefon,
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
                BrutIndirim = x.IndirimBilgileri.BrutIndirim,
                KistDonemDusulenIndirim = x.IndirimBilgileri.KistDonemDusulenIndirim,
                NetIndirim = x.IndirimBilgileri.NetIndirim,
            }).OrderBy(x => x.OgrenciNo).ToList();
        }
    }
}