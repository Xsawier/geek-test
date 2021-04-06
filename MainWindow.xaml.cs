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

namespace Geek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void UpedateTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            lblTimeNow.Content = "TimeNow: " + Math.Round(dateTime.Subtract(score.time).TotalSeconds)+"s";
        }

        Score score = new Score();

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if(tbResult.Text == "10")
            {
                DateTime dateTime = DateTime.Now;
                TimeSpan resultTime = dateTime.Subtract(score.time);
                double seconds = resultTime.TotalSeconds;
                lblTime.Content = "Time: " + (int)seconds + "s";
                score.points += 10;
                lblScore.Content = "Score: " + score.points;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            score.time = dateTime;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpedateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            
        }
    }
}
