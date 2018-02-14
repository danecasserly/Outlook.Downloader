using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using outlook = Microsoft.Office.Interop.Outlook;
using office = Microsoft.Office.Core;
using System.Windows.Forms;
using Properties = Outlook.Download.Outlook.Properties;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Outlook.Download.Outlook.Services.Interfaces;
using Outlook.Download.Outlook.Services;

namespace Outlook.Download.Addin
{
    public partial class ThisAddIn
    {
        private static IContainer Container { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Downloader>().As<IDownloader>();
            builder.RegisterType<DownloadLinks>().As<IDownloadLinks>();

            var container = builder.Build();
            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
           
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
