﻿using System.ComponentModel;

namespace YavuzSav.OgrenciTakip.Common.Enums
{
    public enum YazdirmaYonu : byte
    {
        [Description("Dikey")]
        Dikey = 1,

        [Description("Yatay")]
        Yatay = 2,

        [Description("Otomatik")]
        Otomatik = 3
    }
}