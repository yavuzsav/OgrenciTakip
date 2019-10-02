using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class MeslekBll : BaseGenelBll<Meslek>, IBaseGenelBll, IBaseCommonBll
    {
        public MeslekBll() : base(KartTuru.Meslek)
        {
        }

        public MeslekBll(Control control) : base(control, KartTuru.Meslek)
        {
        }
    }
}