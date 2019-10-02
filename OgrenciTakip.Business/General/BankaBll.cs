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
    public class BankaBll : BaseGenelBll<Banka>, IBaseGenelBll, IBaseCommonBll
    {
        public BankaBll() : base(KartTuru.Banka)
        {
        }

        public BankaBll(Control control) : base(control, KartTuru.Banka)
        {
        }

        public override BaseEntity Single(Expression<Func<Banka, bool>> filter)
        {
            return BaseSingle(filter, x => new BankaS
            {
                Id = x.Id,
                Kod = x.Kod,
                BankaAdi = x.BankaAdi,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Banka, bool>> filter)
        {
            return BaseList(filter, x => new BankaL
            {
                Id = x.Id,
                Kod = x.Kod,
                BankaAdi = x.BankaAdi,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}