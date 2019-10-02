using System;
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
    public class SinavBilgileriBll : BaseHareketBll<SinavBilgileri, OgrenciTakipContext>, IBaseHareketSelectBll<SinavBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<SinavBilgileri, bool>> filter)
        {
            return List(filter, x => new SinavBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                Tarih = x.Tarih,
                SinavAdi = x.SinavAdi,
                PuanTuru = x.PuanTuru,
                Puan = x.Puan,
                Sira = x.Sira,
                Yuzde = x.Yuzde
            }).ToList();
        }
    }
}