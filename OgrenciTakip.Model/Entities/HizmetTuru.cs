using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class HizmetTuru : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Hizmet Türü Adı", "txtHizmetTuruAdi")]
        public string HizmetTuruAdi { get; set; }

        public HizmetTipi HizmetTipi { get; set; } = HizmetTipi.Egitim;

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}