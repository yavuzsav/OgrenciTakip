﻿using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Business.Base;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Entities;

namespace YavuzSav.OgrenciTakip.Business.General
{
    public class IndirimTuruBll : BaseGenelBll<IndirimTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public IndirimTuruBll() : base(KartTuru.IndirimTuru)
        {
        }

        public IndirimTuruBll(Control control) : base(control, KartTuru.IndirimTuru)
        {
        }
    }
}