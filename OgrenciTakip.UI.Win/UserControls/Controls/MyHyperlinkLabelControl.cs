using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.UI.Win.Interfaces;

namespace YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls
{
    public class MyHyperlinkLabelControl : HyperlinkLabelControl, IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public MyHyperlinkLabelControl()
        {
            Cursor = Cursors.Hand;
            LinkBehavior = LinkBehavior.NeverUnderline;
        }

        public string StatusBarAciklama { get; set; }
    }
}