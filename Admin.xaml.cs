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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            dg.ItemsSource = ObchClass.base1.Пользователи.ToList();
        }

        private void spisok_Click(object sender, RoutedEventArgs e)
        {
            st1.Visibility = Visibility.Visible;
            st2.Visibility = Visibility.Collapsed;
        }

        private void glaviek_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame.Navigate(new nachalo());
        }
    }
}
