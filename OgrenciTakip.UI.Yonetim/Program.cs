using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.UI.Yonetim.Forms.GenelForms;

namespace YavuzSav.OgrenciTakip.UI.Yonetim
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Win.Functions.GeneralFunctions.EncryptConfigFile(AppDomain.CurrentDomain.SetupInformation.ApplicationName, "connectionStrings", "appSettings");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");

            Application.Run(new GirisForm());
        }
    }
}