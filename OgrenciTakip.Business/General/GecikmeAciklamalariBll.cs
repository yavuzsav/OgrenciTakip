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
    public class GecikmeAciklamalariBll : BaseGenelBll<GecikmeAciklamalari>, IBaseCommonBll
    {
        public GecikmeAciklamalariBll() : base(KartTuru.GecikmeAciklamalari)
        {
        }

        public GecikmeAciklamalariBll(Control control) : base(control, KartTuru.GecikmeAciklamalari)
        {
        }

        public override BaseEntity Single(Expression<Func<GecikmeAciklamalari, bool>> filter)
        {
            return BaseSingle(filter, x => new GecikmeAciklamalariS
            {
                Id = x.Id,
                Kod = x.Kod,
                OdemeBilgileriId = x.OdemeBilgileriId,
                KullaniciAdi = x.Kullanici.Kod,
                TarihSaat = x.TarihSaat,
                Aciklama = x.Aciklama
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<GecikmeAciklamalari, bool>> filter)
        {
            return BaseList(filter, x => new GecikmeAciklamalariL
            {
                Id = x.Id,
                Kod = x.Kod,
                KullaniciAdi = x.Kullanici.Kod,
                TarihSaat = x.TarihSaat,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}