using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cherry_Screen.Download.DownloadWebsite
{
    class DownloadNews : DownloadWebsite
    {
        public DownloadNews(string path, string pattern) 
            : base(path, pattern) 
        {
        }

        private override string getWebsiteSource(string path)
        {
            string source = "";

            return source;
        }

        private override void rebuildWebsite(string source, Regex pattern)
        {

        }

        private override void download()
        {
            string source = getWebsiteSource(path);
            rebuildWebsite(source, pattern);
        }
    }
}
