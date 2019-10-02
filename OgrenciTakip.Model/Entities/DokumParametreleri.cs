using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class DokumParametreleri : IBaseEntity
    {
        public string RaporBaslik { get; set; }
        public EvetHayir BaslikEkle { get; set; }
        public RaporuKagidaSigdirmaTuru raporuKagidaSigdir { get; set; }
        public YazdirmaYonu yazdirmaYonu { get; set; }
        public EvetHayir YatayCizgileriGoster { get; set; }
        public EvetHayir DikeyCizgileriGoster { get; set; }
        public EvetHayir SutunBaslikleriniGoster { get; set; }
        public string YaziciAdi { get; set; }
        public int YazdirilacakAdet { get; set; }
        public DokumSekli dokumSekli { get; set; }
    }
}