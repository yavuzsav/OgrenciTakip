using System.ComponentModel.DataAnnotations.Schema;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Dto
{
    [NotMapped]  //Bu olanları veritabanında oluşturmaz
    public class SinifS : Sinif
    {
        public string GrupAdi { get; set; }
    }

    public class SinifL : BaseEntity
    {
        public string SinifAdi { get; set; }
        public string GrupAdi { get; set; }
        public int HedefOgrenciSayisi { get; set; }
        public decimal HedefCiro { get; set; }
        public string Aciklama { get; set; }
    }
}