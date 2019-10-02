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
    public class IndiriminUygulanacagiHizmetBilgileriBll : BaseHareketBll<IndiriminUygulanacagiHizmetBilgileri, OgrenciTakipContext>, IBaseHareketSelectBll<IndiriminUygulanacagiHizmetBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<IndiriminUygulanacagiHizmetBilgileri, bool>> filter)
        {
            return List(filter, x => new IndiriminUygulanacagiHizmetBilgileriL
            {
                Id = x.Id,
                IndirimId = x.IndirimId,
                HizmetId = x.HizmetId,
                HizmetAdi = x.Hizmet.HizmetAdi,
                IndirimTutari = x.IndirimTutari,
                IndirimOrani = x.IndirimOrani,
                SubeId = x.SubeId,
                DonemId = x.DonemId
            }).ToList();
        }
    }
}