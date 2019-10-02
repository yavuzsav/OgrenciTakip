using DevExpress.XtraReports.UI;
using System.ComponentModel;

namespace YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public partial class MyXtraReport : XtraReport
    {
        public MyXtraReport()
        {
        }

        public string Baslik { get; set; }
    }
}