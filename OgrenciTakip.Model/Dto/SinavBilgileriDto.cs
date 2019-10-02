using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace YavuzSav.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class SinavBilgileriL : SinavBilgileri, IBaseHareketEntity
    {
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}