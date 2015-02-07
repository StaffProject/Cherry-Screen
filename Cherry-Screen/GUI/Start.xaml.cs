using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Cherry_Screen.Download.DownloadWebsite;

namespace Cherry_Screen.GUI
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();

            DownloadNews test = new DownloadNews("http://staff.edu.pl/category/news/");
            test.download();

            news.Navigate(new Uri("C:/Users/Piotr Bielski/Documents/Programowanie/Projekty/Cherry-Screen/Cherry-Screen/bin/Debug/websiteFiles/NewsWebsiteFiles/mainNews.html"));
            plan.Navigate("http://www.staff.edu.pl/plan_lekcji/index.html");
            
        }
    }
}
