using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class RolYetki : BaseEntity
    {
        public KartTuru KartTuru { get; set; }
    }
}