using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        Пользователи Ад;
        public Admin(Пользователи p)
        {
            InitializeComponent();
            Frame2.Frame3 = fr_katalog;
            Ад = p;
        }

        private void spisok_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame3.Navigate(new Str());
        }

        private void glaviek_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame.Navigate(new nachalo());
        }

        private void kosmet_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame3.Navigate(new Str2());
        }

        private void klas_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame3.Navigate(new Klassif());
        }

        private void Soz_zap_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame3.Navigate(new Sozdanie());
        }

        private void b_kab_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame.Navigate(new kabinet(Ад));
        }
    }
}
