using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class FiltreBll : BaseGenelBll<Filtre>, IBaseCommonBll
    {
        public FiltreBll() : base(KartTuru.Filtre)
        {
        }

        public FiltreBll(Control control) : base(control, KartTuru.Filtre)
        {
        }
    }
}