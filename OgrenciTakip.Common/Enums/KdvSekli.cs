﻿using System.ComponentModel;

namespace YavuzSav.OgrenciTakip.Common.Enums
{
    public enum KdvSekli : byte
    {
        [Description("Dahil")]
        Dahil = 1,

        [Description("Hariç")]
        Haric = 2
    }
}