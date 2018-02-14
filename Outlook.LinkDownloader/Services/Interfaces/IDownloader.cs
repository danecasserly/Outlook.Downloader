using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using outlook = Microsoft.Office.Interop.Outlook;

namespace Outlook.Download.Outlook.Services.Interfaces
{
    public interface IDownloader
    {
         Task StartDownload(outlook.MailItem MailItem, string TempDownloadPath);
    }
}
