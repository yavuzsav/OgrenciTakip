using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class Il : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("İl Adı", "txtIlAdi")]
        public string IlAdi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [InverseProperty("Il")]
        public ICollection<Ilce> Ilce { get; set; }   //ilçeye ulaşmak için
    }
}