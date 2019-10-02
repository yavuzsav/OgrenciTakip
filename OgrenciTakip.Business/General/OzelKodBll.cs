using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class OzelKodBll : BaseGenelBll<OzelKod>, IBaseCommonBll
    {
        public OzelKodBll() : base(KartTuru.OzelKod)
        {
        }

        public OzelKodBll(Control control) : base(control, KartTuru.OzelKod)
        {
        }
    }
}