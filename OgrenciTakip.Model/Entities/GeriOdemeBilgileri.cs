﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class GeriOdemeBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tarih { get; set; }

        public GeriOdemeHesapTuru HesapTuru { get; set; }
        public long? BankaHesapId { get; set; }
        public long? KasaId { get; set; }

        [Column(TypeName = "money")]
        public decimal Tutar { get; set; }

        [StringLength(200)]
        public string Aciklama { get; set; }

        //vt ilişki
        public Tahakkuk Tahakkuk { get; set; }

        public BankaHesap BankaHesap { get; set; }
        public Kasa Kasa { get; set; }
    }
}