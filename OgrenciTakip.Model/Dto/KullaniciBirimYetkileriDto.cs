﻿using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace YavuzSav.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class KullaniciBirimYetkileriL : KullaniciBirimYetkileri, IBaseHareketEntity
    {
        public string Kod { get; set; }
        public string SubeAdi { get; set; }
        public string DonemAdi { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}