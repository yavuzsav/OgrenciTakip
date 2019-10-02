using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class RolYetkileri : BaseHareketEntity
    {
        public long RolId { get; set; }
        public KartTuru KartTuru { get; set; }
        public byte Gorebilir { get; set; }
        public byte Ekleyebilir { get; set; }
        public byte Degistirebilir { get; set; }
        public byte Silebilir { get; set; }

        //vt ilişki
        public Rol Rol { get; set; }
    }
}