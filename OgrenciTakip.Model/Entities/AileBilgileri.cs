using System.ComponentModel.DataAnnotations;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class AileBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long AileBilgiId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        //vt ilişki
        public AileBilgi AileBilgi { get; set; }
    }
}