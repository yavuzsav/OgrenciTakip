﻿using System;
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
    public class CariBll : BaseGenelBll<Cari>, IBaseGenelBll, IBaseCommonBll
    {
        public CariBll() : base(KartTuru.Cari)
        {
        }

        public CariBll(Control control) : base(control, KartTuru.Cari)
        {
        }

        public override BaseEntity Single(Expression<Func<Cari, bool>> filter)
        {
            return BaseSingle(filter, x => new CariS
            {
                Id = x.Id,
                Kod = x.Kod,
                CariAdi = x.CariAdi,
                TcKimlikNo = x.TcKimlikNo,
                Telefon1 = x.Telefon1,
                Telefon2 = x.Telefon2,
                Telefon3 = x.Telefon3,
                Telefon4 = x.Telefon4,
                Faks = x.Faks,
                Web = x.Web,
                Email = x.Email,
                VergiDairesi = x.VergiDairesi,
                VergiNo = x.VergiNo,
                Adres = x.Adres,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Cari, bool>> filter)
        {
            return BaseList(filter, x => new CariL
            {
                Id = x.Id,
                Kod = x.Kod,
                CariAdi = x.CariAdi,
                TcKimlikNo = x.TcKimlikNo,
                Telefon1 = x.Telefon1,
                Telefon2 = x.Telefon2,
                Telefon3 = x.Telefon3,
                Telefon4 = x.Telefon4,
                Faks = x.Faks,
                Web = x.Web,
                Email = x.Email,
                VergiDairesi = x.VergiDairesi,
                VergiNo = x.VergiNo,
                Adres = x.Adres,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}