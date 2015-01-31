using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cherry_Screen.Download.DownloadWebsite
{
    abstract class DownloadWebsite
    {
        protected Regex pattern
        {
            get { return pattern; }
            private set { pattern = value; }
        }

        protected string path
        {
            get { return path; }
            private set { path = value; }
        }

        protected DownloadWebsite(string path, string pattern)
        {
            this.path = path;
            this.pattern = new Regex(pattern);
        }

        protected virtual string getWebsiteSource(string path)
        {
            return "";
        }

        protected virtual void rebuildWebsite(string source, Regex pattern)
        { 
            //tworzenie nowego pliku html
        }

        protected virtual void download()
        {
            //getWebsiteSource()
            //rebuildWebsite()
        }
    }
}
