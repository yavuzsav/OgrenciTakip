using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UserDesigner;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Entities;
using YavuzSav.OgrenciTakip.UI.Win.Forms.RaporForms;
using YavuzSav.OgrenciTakip.UI.Win.Functions;
using YavuzSav.OgrenciTakip.UI.Win.Show;

namespace YavuzSav.OgrenciTakip.UI.Win.GeneralForms
{
    public partial class RaporTasarim : RibbonForm, ICommandHandler     //ICommandHandler AddCommandHandler() kullanabilmemiz için implemente olması gerekiyor
    {
        private readonly Rapor _rapor;

        public RaporTasarim(params object[] prm)
        {
            InitializeComponent();
            _rapor = (Rapor)prm[0];
            Yukle();
        }

        protected internal void Yukle()
        {
            var stream = new MemoryStream(_rapor.Dosya);
            var rapor = stream.StreamToReport();
            reportDesigner1.AddCommandHandler(this);
            reportDesigner1.OpenReport(rapor);
            reportDesigner1.XtraTabbedMdiManager.View.DocumentProperties.AllowClose = false;
            reportDesigner1.XtraTabbedMdiManager.View.DocumentProperties.AllowDock = false;
            reportDesigner1.XtraTabbedMdiManager.View.DocumentProperties.AllowFloat = false;
            reportDesigner1.ActiveDesignPanel.Report.DisplayName = _rapor.RaporAdi;
        }

        private void Kaydet()
        {
            _rapor.Dosya = reportDesigner1.ActiveDesignPanel.Report.ReportToStream().GetBuffer();
            var result = ShowEditForms<RaporEditForm>.ShowDialogEditForm(KartTuru.Rapor, _rapor.Id, _rapor.RaporTuru, _rapor.RaporBolumTuru, _rapor.Dosya);
            if (result <= 0) return;

            reportDesigner1.ActiveDesignPanel.ReportState = ReportState.Saved;
            DialogResult = DialogResult.OK;
            Tag = result;
            Close();
        }

        private void FarkliKaydet()
        {
            _rapor.Id = 0; // yeni bir rapor olduğunu söylüyoruz
            _rapor.Dosya = reportDesigner1.ActiveDesignPanel.Report.ReportToStream().ToArray(); //buffer yapınca ciddi bir değişiklik olmazsa yakalayamıyor
            var result = ShowEditForms<RaporEditForm>.ShowDialogEditForm(KartTuru.Rapor, _rapor.Id, _rapor.RaporTuru, _rapor.RaporBolumTuru, _rapor.Dosya);
            if (result <= 0) return;

            reportDesigner1.ActiveDesignPanel.ReportState = ReportState.Saved;
            DialogResult = DialogResult.OK;
            Tag = result;
            Close();
        }

        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            //bazı butonların işlemlerini devre dışı bırakacağız

            useNextHandler = !(command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs || command == ReportCommand.Closing);
            return !useNextHandler;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {
            //devre dışı bıraktığımız butonlara basılınca yapılacak işlemleri atayacağız
            if (command == ReportCommand.SaveFile)
                Kaydet();
            else if (command == ReportCommand.SaveFileAs)
                FarkliKaydet();
            else if (command == ReportCommand.Closing)
                if (reportDesigner1.ActiveDesignPanel.ReportState == ReportState.Changed)
                {
                    var result = Messages.KapanisMesaj();

                    switch (result)
                    {
                        case DialogResult.Yes:
                            Kaydet();
                            break;

                        case DialogResult.No:
                            reportDesigner1.ActiveDesignPanel.ReportState = ReportState.Closing;
                            Close();
                            break;

                        case DialogResult.Cancel:
                            var eventsArgs = args.Cast<CancelEventArgs>().FirstOrDefault();
                            if (eventsArgs != null)
                                eventsArgs.Cancel = true;
                            break;
                    }
                }
        }
    }
}