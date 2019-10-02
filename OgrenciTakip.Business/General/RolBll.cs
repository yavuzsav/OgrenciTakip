using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class RolBll : BaseGenelBll<Rol>, IBaseGenelBll, IBaseCommonBll
    {
        public RolBll() : base(KartTuru.Rol)
        {
        }

        public RolBll(Control control) : base(control, KartTuru.Rol)
        {
        }
    }
}