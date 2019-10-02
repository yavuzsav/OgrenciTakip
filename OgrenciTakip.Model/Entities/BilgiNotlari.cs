using System;
using System.ComponentModel.DataAnnotations;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class BilgiNotlari : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public DateTime Tarih { get; set; }

        [Required, StringLength(1000)]
        public string BilgiNotu { get; set; }
    }
}