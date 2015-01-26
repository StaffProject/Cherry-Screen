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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Cherry_Screen.GUI
{
    /// <summary>
    /// Interaction logic for ClockBar.xaml
    /// </summary>
    public partial class ClockBar : UserControl
    {
        DispatcherTimer Timer = new DispatcherTimer();

        public ClockBar()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(timerTick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private static string translateDayOfWeek(string day)
        {
            switch (day)
            {
                case "Monday": return "Poniedziałek"; break;
                case "Tuesday": return "Wtorek"; break;
                case "Wednesday": return "Środa"; break;
                case "Thursday": return "Czwartek"; break;
                case "Friday": return "Piątek"; break;
                case "Saturday": return "Sobota"; break;
                case "Sunday": return "Niedziela"; break;
            }

            return "";
        }

        private static string intToStringMonth(int number)
        {
            switch (number)
            {
                case 1: return "Styczeń"; break;
                case 2: return "Luty"; break;
                case 3: return "Marzec"; break;
                case 4: return "Kwiecień"; break;
                case 5: return "Maj"; break;
                case 6: return "Czerwiec"; break;
                case 7: return "Lipiec"; break;
                case 8: return "Sierpień"; break;
                case 9: return "Wrzesień"; break;
                case 10: return "Październik"; break;
                case 11: return "Listopad"; break;
                case 12: return "Grudzień"; break;
            }

            return "";
        }

        private void timerTick(object sender, EventArgs e)
        {
            DateTime date;
            date = DateTime.Now;

            if (date.Hour < 10)
                clockControl.Content = "0" + date.Hour + " : " + date.Minute;
            else
                clockControl.Content = date.Hour + " : " + date.Minute;

            if (date.Minute < 10)
                clockControl.Content = date.Hour + " : " + "0" + date.Minute;
            else
                clockControl.Content = date.Hour + " : " + date.Minute;

            if (date.Day < 10)
                dateControl.Content = translateDayOfWeek(date.DayOfWeek.ToString()) + "\n" +
                                                      "0" + date.Day + " " + intToStringMonth(date.Month);
            else 
                dateControl.Content = translateDayOfWeek(date.DayOfWeek.ToString()) + "\n" +
                                      date.Day + " " + intToStringMonth(date.Month);
        }
    }
}
