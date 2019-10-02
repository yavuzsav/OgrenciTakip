using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class KardesBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long KardesTahakkukId { get; set; }

        //vt ilişki
        public Tahakkuk KardesTahakkuk { get; set; }
    }
}