﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;
using YavuzSav.OgrenciTakip.UI.Win.Interfaces;

namespace YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyComboBoxEdit : ComboBoxEdit, IStatusBarKisayol
    {
        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisayol { get; set; } = "F4 :";
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}