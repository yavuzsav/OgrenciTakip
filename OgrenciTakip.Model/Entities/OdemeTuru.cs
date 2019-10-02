using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class OdemeTuru : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Ödeme Türü Adı", "txtOdemeTuruAdi")]
        public string OdemeTuruAdi { get; set; }

        public OdemeTipi OdemeTipi { get; set; } = OdemeTipi.Elden;

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}