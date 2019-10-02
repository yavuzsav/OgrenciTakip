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
    public class PromosyonBilgileriBll : BaseHareketBll<PromosyonBilgileri, OgrenciTakipContext>, IBaseHareketSelectBll<PromosyonBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<PromosyonBilgileri, bool>> filter)
        {
            return List(filter, x => new PromosyonBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                Kod = x.Promosyon.Kod,
                PromosyonId = x.PromosyonId,
                PromosyonAdi = x.Promosyon.PromosyonAdi
            }).ToList();
        }
    }
}