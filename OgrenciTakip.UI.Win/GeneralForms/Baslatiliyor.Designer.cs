namespace YavuzSav.OgrenciTakip.UI.Win.GeneralForms
{
    partial class Baslatiliyor
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
            this.progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelCopyright = new DevExpress.XtraEditors.LabelControl();
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblVersiyon = new DevExpress.XtraEditors.LabelControl();
            this.peImage = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarControl
            // 
            this.progressBarControl.EditValue = 0;
            this.progressBarControl.Location = new System.Drawing.Point(12, 260);
            this.progressBarControl.Name = "progressBarControl";
            this.progressBarControl.Size = new System.Drawing.Size(426, 20);
            this.progressBarControl.TabIndex = 5;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelCopyright.Appearance.Options.UseForeColor = true;
            this.labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelCopyright.Location = new System.Drawing.Point(12, 286);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(87, 13);
            this.labelCopyright.TabIndex = 6;
            this.labelCopyright.Text = "Copyright © 2019";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(12, 241);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(146, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Başlatılıyor Lütfen Bekleyiniz...";
            // 
            // lblVersiyon
            // 
            this.lblVersiyon.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblVersiyon.Appearance.Options.UseForeColor = true;
            this.lblVersiyon.Appearance.Options.UseTextOptions = true;
            this.lblVersiyon.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblVersiyon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblVersiyon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblVersiyon.Location = new System.Drawing.Point(176, 286);
            this.lblVersiyon.Name = "lblVersiyon";
            this.lblVersiyon.Size = new System.Drawing.Size(262, 13);
            this.lblVersiyon.TabIndex = 10;
            this.lblVersiyon.Text = "Versiyon";
            // 
            // peImage
            // 
            this.peImage.EditValue = global::YavuzSav.OgrenciTakip.UI.Win.Properties.Resources._831__1_;
            this.peImage.Location = new System.Drawing.Point(12, 12);
            this.peImage.Name = "peImage";
            this.peImage.Properties.AllowFocused = false;
            this.peImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peImage.Properties.Appearance.Options.UseBackColor = true;
            this.peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peImage.Properties.ShowMenu = false;
            this.peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.peImage.Size = new System.Drawing.Size(426, 210);
            this.peImage.TabIndex = 9;
            // 
            // Baslatiliyor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 330);
            this.Controls.Add(this.lblVersiyon);
            this.Controls.Add(this.peImage);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.progressBarControl);
            this.Name = "Baslatiliyor";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.LabelControl lblVersiyon;
    }
}
