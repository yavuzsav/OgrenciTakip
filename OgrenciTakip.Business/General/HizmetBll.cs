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
    public class HizmetBll : BaseGenelBll<Hizmet>, IBaseCommonBll
    {
        public HizmetBll() : base(KartTuru.Hizmet)
        {
        }

        public HizmetBll(Control control) : base(control, KartTuru.Hizmet)
        {
        }

        public override BaseEntity Single(Expression<Func<Hizmet, bool>> filter)
        {
            return BaseSingle(filter, x => new HizmetS
            {
                Id = x.Id,
                Kod = x.Kod,
                HizmetAdi = x.HizmetAdi,
                HizmetTuruId = x.HizmetTuruId,
                HizmetTuruAdi = x.HizmetTuru.HizmetTuruAdi,
                BaslamaTarihi = x.BaslamaTarihi,
                BitisTarihi = x.BitisTarihi,
                Ucret = x.Ucret,
                SubeId = x.SubeId,
                DonemId = x.DonemId,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Hizmet, bool>> filter)
        {
            return BaseList(filter, x => new HizmetL
            {
                Id = x.Id,
                Kod = x.Kod,
                HizmetAdi = x.HizmetAdi,
                HizmetTuruId = x.HizmetTuruId,
                HizmetTuruAdi = x.HizmetTuru.HizmetTuruAdi,
                HizmetTipi = x.HizmetTuru.HizmetTipi,
                BaslamaTarihi = x.BaslamaTarihi,
                BitisTarihi = x.BitisTarihi,
                Ucret = x.Ucret,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}