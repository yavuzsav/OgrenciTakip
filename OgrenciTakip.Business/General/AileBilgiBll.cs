using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class AileBilgiBll : BaseGenelBll<AileBilgi>, IBaseGenelBll, IBaseCommonBll
    {
        public AileBilgiBll() : base(KartTuru.AileBilgi)
        {
        }

        public AileBilgiBll(Control control) : base(control, KartTuru.AileBilgi)
        {
        }
    }
}