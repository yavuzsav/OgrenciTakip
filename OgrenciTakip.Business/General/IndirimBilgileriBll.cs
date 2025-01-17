﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Data.Contexts;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class IndirimBilgileriBll : BaseHareketBll<IndirimBilgileri, OgrenciTakipContext>, IBaseHareketSelectBll<IndirimBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<IndirimBilgileri, bool>> filter)
        {
            return List(filter, x => new IndirimBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                IndirimId = x.IndirimId,
                IndirimAdi = x.IptalEdildi ? x.Indirim.IndirimAdi + " - ( *** İptal Edildi )" : x.Indirim.IndirimAdi,
                HizmetId = x.HizmetId,
                HizmetAdi = x.Hizmet.HizmetAdi,
                IslemTarihi = x.IslemTarihi,
                BrutIndirim = x.BrutIndirim,
                KistDonemDusulenIndirim = x.KistDonemDusulenIndirim,
                NetIndirim = x.NetIndirim,
                IptalEdildi = x.IptalEdildi,
                IptalTarihi = x.IptalTarihi,
                OranliIndirim = x.OranliIndirim,
                ManuelGirilenTutar = x.ManuelGirilenTutar,
                HizmetHareketId = x.HizmetHareketId,
                IptalNedeniId = x.IptalNedeniId,
                IptalNedeniAdi = x.IptalNedeni.IptalNedeniAdi,
                IptalAciklama = x.IptalAciklama
            }).OrderByDescending(x => x.IptalEdildi).ThenBy(x => x.IptalTarihi).ThenBy(x => x.Id).ToList();
        }
    }
}