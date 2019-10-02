using System;

namespace YavuzSav.OgrenciTakip.Model.Attributes
{
    public class ZorunluAlan : Attribute
    {
        public string Descriptoin { get; }
        public string ControlName { get; }

        /// <summary>
        /// Validation işlemleri sırasında zorunlu olan alanları işaretlemek için kullanılacak.
        /// </summary>
        /// <param name="description"> uyarı mesajında gösterilecek olan açıklama </param>
        /// <param name="controlName"> Uyarı mesajı sonrası focuslanılacak control adı </param>
        public ZorunluAlan(string description, string controlName)
        {
            Descriptoin = description;
            ControlName = controlName;
        }
    }
}