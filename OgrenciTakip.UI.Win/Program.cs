using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System;
using System.Configuration;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.UI.Win.GeneralForms;

namespace YavuzSav.OgrenciTakip.UI.Win
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Functions.GeneralFunctions.EncryptConfigFile(AppDomain.CurrentDomain.SetupInformation.ApplicationName, "connectionStrings", "appSettings");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle(ConfigurationManager.AppSettings["Skin"], ConfigurationManager.AppSettings["Palette"]);

            Application.Run(new GirisForm());
        }
    }
}