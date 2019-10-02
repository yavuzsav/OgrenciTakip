using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class KullaniciParametreS : KullaniciParametre
    {
        public string DefaultAvukatHesapAdi { get; set; }
        public string DefaultBankaHesapAdi { get; set; }
        public string DefaultKasaHesapAdi { get; set; }
    }
}