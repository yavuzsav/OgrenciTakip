using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class ServisBll : BaseGenelBll<Servis>, IBaseCommonBll
    {
        public ServisBll() : base(KartTuru.Servis)
        {
        }

        public ServisBll(Control control) : base(control, KartTuru.Servis)
        {
        }
    }
}