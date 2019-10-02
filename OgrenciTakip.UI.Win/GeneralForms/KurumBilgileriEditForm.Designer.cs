﻿namespace YavuzSav.OgrenciTakip.UI.Win.GeneralForms
{
    partial class KurumBilgileriEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition5 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition6 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition7 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition8 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl1 = new YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls.MyDataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtKod = new YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls.MyKodTextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtKurumAdi = new YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls.MyTextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVergiDairesi = new YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls.MyTextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVergiNo = new YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls.MyTextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtIl = new YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls.MyButtonEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtIlce = new YavuzSav.OgrenciTakip.UI.Win.UserControls.Controls.MyButtonEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuResim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).BeginInit();
            this.myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKurumAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(465, 102);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            this.myDataLayoutControl1.Controls.Add(this.txtIlce);
            this.myDataLayoutControl1.Controls.Add(this.txtIl);
            this.myDataLayoutControl1.Controls.Add(this.txtVergiNo);
            this.myDataLayoutControl1.Controls.Add(this.txtVergiDairesi);
            this.myDataLayoutControl1.Controls.Add(this.txtKurumAdi);
            this.myDataLayoutControl1.Controls.Add(this.txtKod);
            this.myDataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl1.Location = new System.Drawing.Point(0, 102);
            this.myDataLayoutControl1.Name = "myDataLayoutControl1";
            this.myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl1.Root = this.Root;
            this.myDataLayoutControl1.Size = new System.Drawing.Size(465, 119);
            this.myDataLayoutControl1.TabIndex = 0;
            this.myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition4.Width = 212D;
            columnDefinition5.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition5.Width = 20D;
            columnDefinition6.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition6.Width = 212D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition4,
            columnDefinition5,
            columnDefinition6});
            rowDefinition5.Height = 24D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition6.Height = 24D;
            rowDefinition6.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition7.Height = 24D;
            rowDefinition7.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition8.Height = 24D;
            rowDefinition8.SizeType = System.Windows.Forms.SizeType.Absolute;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition5,
            rowDefinition6,
            rowDefinition7,
            rowDefinition8});
            this.Root.Size = new System.Drawing.Size(465, 119);
            this.Root.TextVisible = false;
            // 
            // txtKod
            // 
            this.txtKod.EnterMoveNextControl = true;
            this.txtKod.Location = new System.Drawing.Point(74, 12);
            this.txtKod.MenuManager = this.ribbonControl;
            this.txtKod.Name = "txtKod";
            this.txtKod.Properties.Appearance.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtKod.Properties.Appearance.Options.UseBackColor = true;
            this.txtKod.Properties.Appearance.Options.UseTextOptions = true;
            this.txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtKod.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKod.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKod.Properties.MaxLength = 20;
            this.txtKod.Size = new System.Drawing.Size(146, 20);
            this.txtKod.StatusBarAciklama = "Kod Giriniz.";
            this.txtKod.StyleController = this.myDataLayoutControl1;
            this.txtKod.TabIndex = 0;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txtKod;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem1.Text = "Kod";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtKurumAdi
            // 
            this.txtKurumAdi.EnterMoveNextControl = true;
            this.txtKurumAdi.Location = new System.Drawing.Point(74, 36);
            this.txtKurumAdi.MenuManager = this.ribbonControl;
            this.txtKurumAdi.Name = "txtKurumAdi";
            this.txtKurumAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKurumAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKurumAdi.Properties.MaxLength = 50;
            this.txtKurumAdi.Size = new System.Drawing.Size(379, 20);
            this.txtKurumAdi.StatusBarAciklama = "Kurum Adı Giriniz";
            this.txtKurumAdi.StyleController = this.myDataLayoutControl1;
            this.txtKurumAdi.TabIndex = 1;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtKurumAdi;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 3;
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(445, 24);
            this.layoutControlItem2.Text = "Kurum Adı";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.EnterMoveNextControl = true;
            this.txtVergiDairesi.Location = new System.Drawing.Point(74, 60);
            this.txtVergiDairesi.MenuManager = this.ribbonControl;
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtVergiDairesi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtVergiDairesi.Properties.MaxLength = 50;
            this.txtVergiDairesi.Size = new System.Drawing.Size(146, 20);
            this.txtVergiDairesi.StatusBarAciklama = "Vergi Dairesi Adı Giriniz";
            this.txtVergiDairesi.StyleController = this.myDataLayoutControl1;
            this.txtVergiDairesi.TabIndex = 2;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.txtVergiDairesi;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem3.Text = "Vergi Dairesi";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.EnterMoveNextControl = true;
            this.txtVergiNo.Location = new System.Drawing.Point(306, 60);
            this.txtVergiNo.MenuManager = this.ribbonControl;
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtVergiNo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtVergiNo.Properties.MaxLength = 50;
            this.txtVergiNo.Size = new System.Drawing.Size(147, 20);
            this.txtVergiNo.StatusBarAciklama = "Vergi No Giriniz";
            this.txtVergiNo.StyleController = this.myDataLayoutControl1;
            this.txtVergiNo.TabIndex = 3;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.txtVergiNo;
            this.layoutControlItem4.Location = new System.Drawing.Point(232, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem4.Size = new System.Drawing.Size(213, 24);
            this.layoutControlItem4.Text = "Vergi No";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtIl
            // 
            this.txtIl.EnterMoveNextControl = true;
            this.txtIl.Id = null;
            this.txtIl.Location = new System.Drawing.Point(74, 84);
            this.txtIl.MenuManager = this.ribbonControl;
            this.txtIl.Name = "txtIl";
            this.txtIl.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtIl.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtIl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtIl.Size = new System.Drawing.Size(146, 20);
            this.txtIl.StatusBarAciklama = "İl Seçiniz";
            this.txtIl.StatusBarKisayol = "F4 :";
            this.txtIl.StatusBarKisayolAciklama = "Seçim Yap";
            this.txtIl.StyleController = this.myDataLayoutControl1;
            this.txtIl.TabIndex = 4;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem5.Control = this.txtIl;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem5.Size = new System.Drawing.Size(212, 27);
            this.layoutControlItem5.Text = "İl";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtIlce
            // 
            this.txtIlce.EnterMoveNextControl = true;
            this.txtIlce.Id = null;
            this.txtIlce.Location = new System.Drawing.Point(306, 84);
            this.txtIlce.MenuManager = this.ribbonControl;
            this.txtIlce.Name = "txtIlce";
            this.txtIlce.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtIlce.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtIlce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIlce.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtIlce.Size = new System.Drawing.Size(147, 20);
            this.txtIlce.StatusBarAciklama = "İlçe Seçiniz";
            this.txtIlce.StatusBarKisayol = "F4 :";
            this.txtIlce.StatusBarKisayolAciklama = "Seçim Yap";
            this.txtIlce.StyleController = this.myDataLayoutControl1;
            this.txtIlce.TabIndex = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.txtIlce;
            this.layoutControlItem6.Location = new System.Drawing.Point(232, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem6.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem6.Size = new System.Drawing.Size(213, 27);
            this.layoutControlItem6.Text = "İlçe";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(59, 13);
            // 
            // KurumBilgileriEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 252);
            this.Controls.Add(this.myDataLayoutControl1);
            this.Name = "KurumBilgileriEditForm";
            this.Text = "Kurum Kartı";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuResim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).EndInit();
            this.myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKurumAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Controls.MyButtonEdit txtIlce;
        private UserControls.Controls.MyButtonEdit txtIl;
        private UserControls.Controls.MyTextEdit txtVergiNo;
        private UserControls.Controls.MyTextEdit txtVergiDairesi;
        private UserControls.Controls.MyTextEdit txtKurumAdi;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}