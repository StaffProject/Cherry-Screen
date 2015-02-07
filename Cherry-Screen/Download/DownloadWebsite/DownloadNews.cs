using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;

namespace Cherry_Screen.Download.DownloadWebsite
{
    class DownloadNews : DownloadWebsite
    {
        private string newsWebsiteSourcesPath = "websiteSources/newsSources/";
        private string newsWebsiteFilesPath = "websiteFiles/NewsWebsiteFiles/";

        public DownloadNews(string path) 
            : base(path) 
        {
        }

        protected override void createDirectories()
        {
            base.createDirectories();

            if (!Directory.Exists(newsWebsiteSourcesPath))
                Directory.CreateDirectory(newsWebsiteSourcesPath);

            if (!Directory.Exists(newsWebsiteFilesPath))
                Directory.CreateDirectory(newsWebsiteFilesPath);
        }

        protected override void downloadWebsiteSource(string path, string fileName)
        {
            WebClient downloader = new WebClient();
            string source = downloader.DownloadString(path);
            
            StreamWriter newsFileWriter = new StreamWriter(newsWebsiteSourcesPath + fileName + ".txt");

            newsFileWriter.Write(source);
            newsFileWriter.Close();
        }

        private List<string> getNewsPaths()
        {
            downloadWebsiteSource(this.path, "mainNewsSource");

            StreamReader newsFileReader = new StreamReader(newsWebsiteSourcesPath + "mainNewsSource.txt");
            Regex patternMainSource = new Regex("<div class=\"content-header\"><h3><a href=\".+?\"");

            List<string> newsPaths = new List<string>();

            while (!newsFileReader.EndOfStream)
            {
                string line = newsFileReader.ReadLine();

                string scrap = patternMainSource.Match(line).ToString();
                string scrap_ = Regex.Replace(scrap, "<div class=\"content-header\"><h3><a href=\"","");
                string newsPath = Regex.Replace(scrap_, "\"", "");

                if (scrap != "")
                    newsPaths.Add(newsPath);
            }

            newsFileReader.Close();

            return newsPaths;
        }

        protected override void rebuildWebsite(List<string> newsPaths)
        {
            int newsSourceCounter = 1;
            foreach (string newsPath in newsPaths)
            {
                downloadWebsiteSource(newsPath, "newsSource" + newsSourceCounter.ToString());
                newsSourceCounter++;
            }

            StreamWriter htmlFileWriter;
            string[] sources = Directory.GetFiles(newsWebsiteSourcesPath);
            HtmlDocument htmlDoc = new HtmlDocument();

            foreach (string source in sources)
            {
                if (source == "websiteSources/newsSources/mainNewsSource.txt")
                {
                    htmlDoc.Load(source);
                    string htmlBody = htmlDoc.GetElementbyId("main").WriteTo().Replace("<div id=\"main\">", "<div id=\"main\" style=\"background-color:white; margin-left: 140px\">");
                    string cssStyle = "<link rel=\"stylesheet\" type=\"text/css\" media=\"all\" href=\"http://staff.edu.pl/wp-content/themes/Wisniowa56/style.css\" />";

                    string htmlContent = cssStyle + htmlBody;

                    htmlFileWriter = new StreamWriter(newsWebsiteFilesPath + "mainNews.html", false, Encoding.UTF8);
                    htmlFileWriter.Write(htmlContent);
                    htmlFileWriter.Close();
                }
            }
        }

        public override void download()
        {
            createDirectories();
            List<string> paths = getNewsPaths();
            rebuildWebsite(paths);
        }
    }
}
