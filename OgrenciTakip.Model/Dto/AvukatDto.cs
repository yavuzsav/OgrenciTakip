﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class AvukatS : Avukat
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }

    public class AvukatL : BaseEntity
    {
        public string AdiSoyadi { get; set; }
        public string SozlesmeNo { get; set; }
        public DateTime? SozlesmeBaslamaTarihi { get; set; }
        public DateTime? SozlesmeBitisTarihi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
    }
}