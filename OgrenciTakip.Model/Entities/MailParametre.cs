using System.ComponentModel.DataAnnotations;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Model.Entities
{
    public class MailParametre : BaseEntity
    {
        [Required,StringLength(50),ZorunluAlan("E_mail","txtEmail")]
        public string Email { get; set; }

        [Required,StringLength(50),ZorunluAlan("Email şifre","txtSifre")]
        public string Sifre { get; set; }

        [ZorunluAlan("Port No", "txtPortNo")]
        public int PortNo { get; set; }

        [Required, StringLength(50), ZorunluAlan("Host", "txtHost")]
        public string Host { get; set; }

        public EvetHayir SslKullan { get; set; } = EvetHayir.Evet;
    }
}