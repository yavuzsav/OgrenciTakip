using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class KurumBilgileriS:KurumBilgileri
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }
}