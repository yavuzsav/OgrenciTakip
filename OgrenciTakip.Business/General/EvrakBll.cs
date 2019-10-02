using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class EvrakBll : BaseGenelBll<Evrak>, IBaseCommonBll  //interface yapısına uymadığı için IBaseGenelBll'den implemente edilmedi
    {
        public EvrakBll() : base(KartTuru.Evrak)
        {
        }

        public EvrakBll(Control control) : base(control, KartTuru.Evrak)
        {
        }
    }
}