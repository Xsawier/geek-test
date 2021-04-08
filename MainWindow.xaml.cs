using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

       

        Score score = new Score();
        DispatcherTimer timer = new DispatcherTimer();
        bool ongoingTask = false;
        bool loosed = false;
        int maxTime = 60;
        private void Accept_Click(object sender, RoutedEventArgs e)
        {   

            if(ongoingTask)
            {
                timer.Stop();
                ongoingTask = false;
                
                DateTime dateTime = DateTime.Now;
                TimeSpan resultTime = dateTime.Subtract(score.time);
                double currentTime = resultTime.TotalSeconds;
                lblTime.Content = "Time: " + (int)currentTime + "s";
                if(tbResult.Text == score.result.ToString() && currentTime <= maxTime)
                {
                    score.mulip = 2 - (currentTime / maxTime * 2);
                    score.points += (int)(10 * score.mulip);
                    lblScore.Content = "Score: " + score.points;
                    lblTxt.Content = "Good!";
                }
                else
                {
                    score.mulip = 2 - (currentTime / maxTime * 2);
                    score.points -= (int)(10 * score.mulip);
                    lblScore.Content = "Score: " + score.points;
                    lblTxt.Content = "Ups!";
                    HeartControl();
                    if(!heart3.IsVisible)
                    {
                        lblTxt.Content = "Looser!";
                    }
                }

            }
        }
        

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if(loosed)
            {
                RestartGame();
            }    
            if(!ongoingTask && !loosed)
            {
                Random rnd = new Random();
                int number1 = rnd.Next(-100,101);
                int number2 = rnd.Next(-100, 101);
                int operation = rnd.Next(0, 4);
                double result = 0;
                switch (operation)
                {
                    case 0:
                        result = number1 + number2;
                        lblTxt.Content = number1 + " + " + number2 + " = " + result;
                        break;
                    case 1:
                        result = number1 - number2;
                        lblTxt.Content = number1 + " - " + number2 + " = " + result;
                        break;
                    case 2:
                        result = number1 * number2;
                        lblTxt.Content = number1 + " * " + number2 + " = " + result;
                        break;
                    case 3:
                        result = number1 / number2;
                        lblTxt.Content = number1 + " / " + number2 + " = " + result;
                        break;

                }
                score.result = result;
                ongoingTask = true;
                DateTime dateTime = DateTime.Now;
                score.time = dateTime;
                timer.Tick += new EventHandler(UpedateTimer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
            }
            
            
                       
        }
        private void RestartGame()
        {
            loosed = false;
            heart1.Visibility = Visibility.Visible;
            heart2.Visibility = Visibility.Visible;
            heart3.Visibility = Visibility.Visible;
            score.points = 0;
            lblScore.Content = "Score: 0";
        }
        private void HeartControl()
        {
            if (heart1.IsVisible)
            {
                heart1.Visibility = Visibility.Hidden;
                timer.Stop();
            }
            else if (heart2.IsVisible)
            {
                heart2.Visibility = Visibility.Hidden;
                timer.Stop();
            }
            else if (heart3.IsVisible)
            {
                heart3.Visibility = Visibility.Hidden;
                timer.Stop();
                loosed = true;
            }
        }
        private void UpedateTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            double currentTime = dateTime.Subtract(score.time).TotalSeconds;
            lblTimeNow.Content = "TimeNow: " + Math.Round(currentTime) + "s";
            if (currentTime >= maxTime)
            {
                
                ongoingTask = false;
                HeartControl();

            }
        }
    }
}
