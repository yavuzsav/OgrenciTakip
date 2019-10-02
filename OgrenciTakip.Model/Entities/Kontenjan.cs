using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class Kontenjan : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Kontenjan Adı", "txtKontenjanAdi")]
        public string KontenjanAdi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}