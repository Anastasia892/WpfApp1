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
    /// Логика взаимодействия для Str2.xaml
    /// </summary>
    public partial class Str2 : Page
    {
        public Str2()
        {
            InitializeComponent();
            List.ItemsSource = ObchClass.base1.Информация_о_косметике.ToList();
        }

        private void redaktura_Click(object sender, RoutedEventArgs e)
        {
            Button But1 = (Button)sender;
            int Ind = Convert.ToInt32(But1.Uid);
            Информация_о_косметике Red = ObchClass.base1.Информация_о_косметике.FirstOrDefault(x => x.ID_Косметики == Ind);
            Frame2.Frame3.Navigate(new Sozdanie(Red));
        }

        private void delite_Click(object sender, RoutedEventArgs e)
        {
            Button But2 = (Button)sender;
            int Ind = Convert.ToInt32(But2.Uid);
            Информация_о_косметике Delete = ObchClass.base1.Информация_о_косметике.FirstOrDefault(x => x.ID_Косметики == Ind);
            ObchClass.base1.Информация_о_косметике.Remove(Delete);
            ObchClass.base1.SaveChanges();
            Frame2.Frame3.Navigate(new Str2());
            MessageBox.Show("Запись удалена!", "Удаление");
        }
    }
}
