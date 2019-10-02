using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class Evrak : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Evrak Adı", "txtEvrakAdi")]
        public string EvrakAdi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public long SubeId { get; set; }
        public long DonemId { get; set; }

        //relationships(İlişkilendirme)(Sonuna Id ekleyim arar)
        public Sube Sube { get; set; }

        public Donem Donem { get; set; }
    }
}