﻿using DevExpress.DataAccess.ObjectBinding;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace YavuzSav.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class IndirimBilgileriL : IndirimBilgileri, IBaseHareketEntity
    {
        public string IndirimAdi { get; set; }
        public string HizmetAdi { get; set; }
        public string IptalNedeniAdi { get; set; }

        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }

    [HighlightedClass]
    public class IndirimBilgileriR
    {
        public string IndirimAdi { get; set; }
        public string HizmetAdi { get; set; }
        public decimal BrutIndirim { get; set; }
        public decimal KistDonemDusulenIndirim { get; set; }
        public decimal NetIndirim { get; set; }
        public DateTime IslemTarihi { get; set; }
        public DateTime? IptalTarihi { get; set; }
        public string IptalNedeniAdi { get; set; }
        public string IptalAciklama { get; set; }
    }
}