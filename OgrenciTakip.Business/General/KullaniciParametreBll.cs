using System;
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
    public class KullaniciParametreBll : BaseGenelBll<KullaniciParametre>, IBaseGenelBll
    {
        public KullaniciParametreBll() : base(KartTuru.KullaniciParametre)
        {
        }

        public KullaniciParametreBll(Control control) : base(control, KartTuru.KullaniciParametre)
        {
        }

        public override BaseEntity Single(Expression<Func<KullaniciParametre, bool>> filter)
        {
            return BaseSingle(filter, x => new KullaniciParametreS
            {
                Id = x.Id,
                Kod = x.Kod,
                KullaniciId = x.KullaniciId,
                DefaultAvukatHesapId = x.DefaultAvukatHesapId,
                DefaultAvukatHesapAdi = x.DefaultAvukatHesap.AdiSoyadi,
                DefaultBankaHesapId = x.DefaultBankaHesapId,
                DefaultBankaHesapAdi = x.DefaultBankaHesap.HesapAdi,
                DefaultKasaHesapId = x.DefaultKasaHesapId,
                DefaultKasaHesapAdi = x.DefaultKasaHesap.KasaAdi,
                RaporlariOnayAlmadanKapat = x.RaporlariOnayAlmadanKapat,
                TableViewCaptionForeColor = x.TableViewCaptionForeColor,
                TableColumnHeaderForeColor = x.TableColumnHeaderForeColor,
                TableBandPanelForeColor = x.TableBandPanelForeColor,
                ArkaPlanResim = x.ArkaPlanResim
            });
        }
    }
}