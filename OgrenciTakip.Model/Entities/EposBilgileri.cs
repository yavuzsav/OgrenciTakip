﻿using System.ComponentModel.DataAnnotations;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class EposBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }

        [Required, StringLength(30)]
        public string Adi { get; set; }

        [Required, StringLength(30)]
        public string Soyadi { get; set; }

        public long BankaId { get; set; }

        public EposKartTuru KartTuru { get; set; } = EposKartTuru.Visa;

        [Required, StringLength(50)]
        public string KartNo { get; set; }

        [Required, StringLength(50)]
        public string SonKullanmaTarihi { get; set; }

        [Required, StringLength(50)]
        public string GuvenlikKodu { get; set; }

        //vt ilişki
        public Banka Banka { get; set; }
    }
}