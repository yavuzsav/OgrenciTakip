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
    public class RaporBll : BaseGenelBll<Rapor>, IBaseGenelBll, IBaseCommonBll
    {
        public RaporBll() : base(KartTuru.Rapor)
        {
        }

        public RaporBll(Control control) : base(control, KartTuru.Rapor)
        {
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Rapor, bool>> filter)
        {
            return BaseList(filter, x => new RaporL
            {
                Id = x.Id,
                Kod = x.Kod,
                RaporAdi = x.RaporAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}