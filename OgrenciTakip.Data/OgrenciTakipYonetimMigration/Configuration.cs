using System.Data.Entity.Migrations;
using YavuzSav.OgrenciTakip.Data.Contexts;

namespace YavuzSav.OgrenciTakip.Data.OgrenciTakipYonetimMigration
{
    public class Configuration : DbMigrationsConfiguration<OgrenciTakipYonetimContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}