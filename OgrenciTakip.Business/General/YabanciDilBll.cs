using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class YabanciDilBll : BaseGenelBll<YabanciDil>, IBaseGenelBll, IBaseCommonBll
    {
        public YabanciDilBll() : base(KartTuru.YabanciDil)
        {
        }

        public YabanciDilBll(Control control) : base(control, KartTuru.YabanciDil)
        {
        }
    }
}