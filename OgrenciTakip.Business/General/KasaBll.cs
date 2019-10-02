using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Dto;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class KasaBll : BaseGenelBll<Kasa>, IBaseCommonBll
    {
        public KasaBll() : base(KartTuru.Kasa)
        {
        }

        public KasaBll(Control control) : base(control, KartTuru.Kasa)
        {
        }

        public override BaseEntity Single(Expression<Func<Kasa, bool>> filter)
        {
            return BaseSingle(filter, x => new KasaS
            {
                Id = x.Id,
                Kod = x.Kod,
                KasaAdi = x.KasaAdi,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                SubeId = x.SubeId,
                DonemId = x.DonemId,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Kasa, bool>> filter)
        {
            return BaseList(filter, x => new KasaL
            {
                Id = x.Id,
                Kod = x.Kod,
                KasaAdi = x.KasaAdi,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}