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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObchClass.base1 = new BDpop();
            Frame2.Frame = Frame;
            Frame2.Frame.Navigate(new nachalo());
        }


        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame.Navigate(new vhod());
        }

        private void Regest_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame.Navigate(new reg());
        }
    }
}
