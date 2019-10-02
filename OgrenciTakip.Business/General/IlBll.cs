using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class IlBll : BaseGenelBll<Il>, IBaseGenelBll, IBaseCommonBll
    {
        public IlBll() : base(KartTuru.Il)
        {
        }

        public IlBll(Control ctrl) : base(ctrl, KartTuru.Il)
        {
        }
    }
}