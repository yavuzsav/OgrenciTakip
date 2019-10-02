using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Data.Contexts;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class KullaniciBirimYetkileriBll : BaseHareketBll<KullaniciBirimYetkileri, OgrenciTakipContext>, IBaseHareketSelectBll<KullaniciBirimYetkileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<KullaniciBirimYetkileri, bool>> filter)
        {
            return List(filter, x => new KullaniciBirimYetkileriL
            {
                Id = x.Id,
                Kod = x.KartTuru == KartTuru.Sube ? x.Sube.Kod : x.Donem.Kod,
                KartTuru = x.KartTuru,
                SubeId = x.SubeId,
                SubeAdi = x.Sube.SubeAdi,
                DonemId = x.DonemId,
                DonemAdi = x.Donem.DonemAdi,
            }).ToList();
        }
    }
}