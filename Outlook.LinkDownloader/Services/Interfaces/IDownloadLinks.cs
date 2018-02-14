using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outlook.Download.Outlook.Services.Interfaces
{
    public interface  IDownloadLinks
    {
        List<string>  GetDownloadLinks(string HTML);
    }
}
