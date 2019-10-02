using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class IlceBll : BaseGenelBll<Ilce>, IBaseCommonBll
    {
        public IlceBll() : base(KartTuru.Ilce)
        {
        }

        public IlceBll(Control ctrl) : base(ctrl, KartTuru.Ilce)
        {
        }
    }
}