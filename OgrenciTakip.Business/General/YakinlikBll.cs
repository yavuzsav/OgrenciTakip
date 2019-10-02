using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class YakinlikBll : BaseGenelBll<Yakinlik>, IBaseGenelBll, IBaseCommonBll
    {
        public YakinlikBll() : base(KartTuru.Yakinlik)
        {
        }

        public YakinlikBll(Control control) : base(control, KartTuru.Yakinlik)
        {
        }
    }
}