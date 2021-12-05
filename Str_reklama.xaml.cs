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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Str_reklama.xaml
    /// </summary>
    public partial class Str_reklama : Page
    {
        public Str_reklama()
        {
            InitializeComponent();
        }
        private void Smotret_Click(object sender, RoutedEventArgs e)
        {
            ColorAnimation BA = new ColorAnimation();

            Color Cstart = Color.FromRgb(255, 0, 0); 
            Smotret.Background = new SolidColorBrush(Cstart);
            BA.From = Cstart;
            BA.To = Color.FromRgb(0, 255, 0);
            BA.Duration = TimeSpan.FromSeconds(0.5);
            BA.RepeatBehavior = RepeatBehavior.Forever;
            BA.AutoReverse = true;
            Smotret.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);

            Cat.Visibility = Visibility.Collapsed;
            Skr.Visibility = Visibility.Visible;

            DoubleAnimation WA = new DoubleAnimation(); 
            WA.From = 200; 
            WA.To = 250; 
            WA.Duration = TimeSpan.FromSeconds(2); 
            WA.RepeatBehavior = RepeatBehavior.Forever; 
            WA.AutoReverse = true; 
            Smotret.BeginAnimation(WidthProperty, WA); 
           

            DoubleAnimation St = new DoubleAnimation(); 
            St.From = 600; 
            St.To = 0; 
            St.Duration = TimeSpan.FromSeconds(4); 
            St.RepeatBehavior = RepeatBehavior.Forever; 
            St.AutoReverse = true; 
            Str1.BeginAnimation(WidthProperty, St); 

            DoubleAnimation FSA = new DoubleAnimation();
            FSA.From = 25;
            FSA.To = 35;
            FSA.Duration = TimeSpan.FromSeconds(1);
            FSA.RepeatBehavior = RepeatBehavior.Forever;
            FSA.AutoReverse = true;
            Str1.BeginAnimation(FontSizeProperty, FSA);

            DoubleAnimation Sk = new DoubleAnimation();
            Sk.From = 200;
            Sk.To = 250;
            Sk.Duration = TimeSpan.FromSeconds(2); 
            Sk.RepeatBehavior = RepeatBehavior.Forever; 
            Sk.AutoReverse = true; 
            Skr.BeginAnimation(WidthProperty, Sk); 
            Skr.BeginAnimation(HeightProperty, Sk);
        }
    }
}
