using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using outlook = Microsoft.Office.Interop.Outlook;
using office = Microsoft.Office.Core;
using System.Windows;
using CommonServiceLocator;
using Outlook.Download.Outlook.Services.Interfaces;
using System.IO;

namespace Outlook.Download.Addin
{
    public partial class NewEmail
    {
        private void NewEmail_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnConvertToAttach_Click(object sender, RibbonControlEventArgs e)
        {
            BtnConvertToAttach_ClickAsync();
        }

        public async void BtnConvertToAttach_ClickAsync()
        {
            outlook.Inspector explorer = Globals.ThisAddIn.Application.ActiveInspector();
            if (explorer.CurrentItem is outlook.MailItem)
            {
                try
                {
                    lblStatus.Label = "Status: Downloading";
                    var mailItem = explorer.CurrentItem as outlook.MailItem;
                    var downloader = ServiceLocator.Current.GetInstance<IDownloader>();
                    await downloader.StartDownload(mailItem, Path.GetTempPath());
                    lblStatus.Label = "Status: Ready";
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show(Resource1.DownloadError);
                }
            }
        }
    }
}
