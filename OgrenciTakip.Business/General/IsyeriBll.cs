using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class IsyeriBll : BaseGenelBll<Isyeri>, IBaseGenelBll, IBaseCommonBll
    {
        public IsyeriBll() : base(KartTuru.Isyeri)
        {
        }

        public IsyeriBll(Control control) : base(control, KartTuru.Isyeri)
        {
        }
    }
}