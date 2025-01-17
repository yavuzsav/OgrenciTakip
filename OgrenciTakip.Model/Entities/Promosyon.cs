﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class Promosyon : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Promosyon Adı", "txtPromosyonAdi")]
        public string PromosyonAdi { get; set; }

        [StringLength(500)]
        public string Acıklama { get; set; }

        public long SubeId { get; set; }
        public long DonemId { get; set; }

        //veritabanı ilişkisi
        public Sube Sube { get; set; }

        public Donem Donem { get; set; }
    }
}