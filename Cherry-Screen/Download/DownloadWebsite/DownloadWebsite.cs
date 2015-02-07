using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Cherry_Screen.Download.DownloadWebsite
{
    abstract class DownloadWebsite
    {
        public string path;

        protected DownloadWebsite(string path)
        {
            this.path = path;
        }

        protected virtual void createDirectories()
        {
            if (!Directory.Exists("websiteSources"))
                Directory.CreateDirectory("websiteSources");

            if (!Directory.Exists("websiteFiles"))
                Directory.CreateDirectory("websiteFiles");
        }

        protected virtual void downloadWebsiteSource(string path, string fileName)
        {
        }

        protected virtual void rebuildWebsite(List<string> newsPaths)
        { 
            //tworzenie nowego pliku html
        }

        public virtual void download()
        {
            //getWebsiteSource()
            //rebuildWebsite()
        }
    }
}
