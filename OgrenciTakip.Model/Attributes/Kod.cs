using System;

namespace YavuzSav.OgrenciTakip.Model.Attributes
{
    public class Kod : Attribute
    {
        public string Descriptoin { get; set; }
        public string ControlName { get; set; }

        /// <summary>
        /// Validation işlemleri sırasında zorunlu olan alanları işaretlemek için kullanılacak.
        /// </summary>
        /// <param name="description"> uyarı mesajında gösterilecek olan açıklama </param>
        /// <param name="controlName"> Uyarı mesajı sonrası focuslanılacak control adı </param>
        public Kod(string descriptoin, string controlName)
        {
            Descriptoin = descriptoin;
            ControlName = controlName;
        }
    }
}