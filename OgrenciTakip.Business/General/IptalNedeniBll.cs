using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class IptalNedeniBll : BaseGenelBll<IptalNedeni>, IBaseGenelBll, IBaseCommonBll
    {
        public IptalNedeniBll() : base(KartTuru.IptalNedeni)
        {
        }

        public IptalNedeniBll(Control control) : base(control, KartTuru.IptalNedeni)
        {
        }
    }
}