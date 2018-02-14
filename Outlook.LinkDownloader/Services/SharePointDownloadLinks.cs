using Outlook.Download.Outlook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outlook.Download.Outlook.Services
{
    public class DownloadLinks:IDownloadLinks
    {
        public List<string> GetDownloadLinks(string HTML)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(HTML);

            var linkTags = htmlDocument.DocumentNode.Descendants("link");
            return htmlDocument.DocumentNode.Descendants("a")
                                              .Select(a => a.GetAttributeValue("href", null))
                                              .Where(u => !String.IsNullOrEmpty(u)).ToList();
        }
    }
}
