using CommonServiceLocator;
using Outlook.Download.Outlook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using outlook = Microsoft.Office.Interop.Outlook;
using Outlook.Download;

namespace Outlook.Download.Outlook.Services
{
    public class Downloader : IDownloader
    {
        private string _tempDownloadPath;
        private Uri _URL;
        private string _contentType;
        private float _fileSize;
        private List<string> _downloadURLS;
        private outlook.MailItem _mailItem;

        public async Task StartDownload(outlook.MailItem MailItem, string TempDownloadPath)
        {
            _tempDownloadPath = TempDownloadPath;
            _mailItem = MailItem;
            var links = ServiceLocator.Current.GetInstance<IDownloadLinks>();
            _downloadURLS = links.GetDownloadLinks(MailItem.HTMLBody);

            foreach (var i in _downloadURLS)
            {
                GetDownloadDetails(new Uri(i));
                if (_fileSize < 10)
                {
                    var item = await DoDownload();
                    _mailItem.Attachments.Add(item);
                }
                else
                {
                   System.Windows.MessageBox.Show(string.Format(Resource1.DownloadError , i));
                }

            }
        }
        private void GetDownloadDetails(Uri URL)
        {
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(URL);
            req.Method = "HEAD";
            req.UseDefaultCredentials = true;
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                int ContentLength;
                if (int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                {
                    _fileSize = ConvertBytesToMegabytes(ContentLength);
                    _contentType = resp.ContentType;
                    _URL = resp.ResponseUri;
                }
            }
        }
        private async Task<string> DoDownload()
        {
            var localFilePath = string.Empty;
            using (WebClient webClient = new WebClient())
            {
                webClient.UseDefaultCredentials = true;
                var localFileName = System.IO.Path.GetFileName(_URL.LocalPath);
                localFilePath = string.Format("{0}/{1}", _tempDownloadPath, localFileName);
                await webClient.DownloadFileTaskAsync(_URL, localFilePath);
            }
            return localFilePath;
        }
        private static float ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
