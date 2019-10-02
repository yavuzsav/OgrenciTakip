using System.ComponentModel;

namespace YavuzSav.OgrenciTakip.Common.Enums
{
    public enum GeriOdemeHesapTuru : byte
    {
        [Description("Banka")]
        BankaHesap = 1,

        [Description("Kasa")]
        Kasa = 2
    }
}