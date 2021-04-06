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

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if(tbResult.Text == "10")
            {
                DateTime dateTime = DateTime.Now;
                TimeSpan resultTime = dateTime.Subtract(score.time);
                double seconds = resultTime.TotalSeconds;
                score.points += 10;
                lblScore.Content = "Score: " + score.points;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;


            score.time = dateTime;
        }
    }
}
