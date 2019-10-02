using System.ComponentModel;

namespace YavuzSav.OgrenciTakip.Common.Enums
{
    public enum YetkilendirmeTuru : byte
    {
        [Description("SQL Server Yetkilendirmesi")]
        SqlServerYetkilendirmesi = 1,

        [Description("Windows Yetkilendirmesi")]
        WindowsYetkilendirmesi = 2
    }
}