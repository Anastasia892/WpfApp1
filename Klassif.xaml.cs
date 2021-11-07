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
    /// Логика взаимодействия для Klassif.xaml
    /// </summary>
    public partial class Klassif : Page
    {
        public Klassif()
        {
            InitializeComponent();
            List_Klasif.ItemsSource = ObchClass.base1.Бренд.ToList();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Класификация> TC = ObchClass.base1.Класификация.Where(x => x.ID_Бренда == index).ToList();
            string str = "";
            foreach (Класификация item in TC)
            {
                str += item.Тип_косметики.Тип_косметики1.ToString() + "\n";
            }
            tb.Text = str;
        }
    }
}
