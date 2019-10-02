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
    public class SinifBll : BaseGenelBll<Sinif>, IBaseCommonBll
    {
        public SinifBll() : base(KartTuru.Sinif)
        {
        }

        public SinifBll(Control control) : base(control, KartTuru.Sinif)
        {
        }

        public override BaseEntity Single(Expression<Func<Sinif, bool>> filter)
        {
            return BaseSingle(filter, x => new SinifS
            {
                Id = x.Id,
                Kod = x.Kod,
                SinifAdi = x.SinifAdi,
                GrupId = x.GrupId,
                GrupAdi = x.Grup.GrupAdi,
                HedefOgrenciSayisi = x.HedefOgrenciSayisi,
                HedefCiro = x.HedefCiro,
                SubeId = x.SubeId,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Sinif, bool>> filter)
        {
            return BaseList(filter, x => new SinifL
            {
                Id = x.Id,
                Kod = x.Kod,
                SinifAdi = x.SinifAdi,
                GrupAdi = x.Grup.GrupAdi,
                HedefOgrenciSayisi = x.HedefOgrenciSayisi,
                HedefCiro = x.HedefCiro,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}