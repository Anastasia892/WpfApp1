using Microsoft.Win32;
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
    /// Логика взаимодействия для Sozdanie.xaml
    /// </summary>
    public partial class Sozdanie : Page
    {
        Информация_о_косметике Список = new Информация_о_косметике();
        int index=0;
        bool Flag;
        string path;
        public Sozdanie()
        {
            InitializeComponent();
            Breand.ItemsSource = ObchClass.base1.Бренд.ToList();
            Breand.SelectedValuePath = "ID_Бренд";
            Breand.DisplayMemberPath = "Имя_бренда";
            Strana.ItemsSource = ObchClass.base1.Страна.ToList();
            Strana.SelectedValuePath = "ID_Страны";
            Strana.DisplayMemberPath = "Страна_изготовления";
            Tip.ItemsSource = ObchClass.base1.Тип_косметики.ToList();
            Tip.SelectedValuePath = "ID_Тип_косметики";
            Tip.DisplayMemberPath = "Тип_косметики1";
            Flag = false;
        }
        public Sozdanie(Информация_о_косметике info)
        {
            InitializeComponent();
            Breand.ItemsSource = ObchClass.base1.Бренд.ToList();
            Breand.SelectedValuePath = "ID_Бренд";
            Breand.DisplayMemberPath = "Имя_бренда";
            Strana.ItemsSource = ObchClass.base1.Страна.ToList();
            Strana.SelectedValuePath = "ID_Страны";
            Strana.DisplayMemberPath = "Страна_изготовления";
            Tip.ItemsSource = ObchClass.base1.Тип_косметики.ToList();
            Tip.SelectedValuePath = "ID_Тип_косметики";
            Tip.DisplayMemberPath = "Тип_косметики1";
            Список = info;
            Breand.SelectedIndex = (int)info.Бренд-1;
            Strana.SelectedIndex = (int)info.Страна_изготовления - 1;
            Tip.SelectedIndex = (int)info.ID_Тип_косметики - 1;
            Kalend.SelectedDate = info.Дата_изготовления;
            if (path != null)  
            {
                BitmapImage BI = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                Foto.Source = BI;
            }
            Flag = true;
        }
        private void zapic_Click(object sender, RoutedEventArgs e)
        {
            Список.Бренд = Breand.SelectedIndex + 1;
            Список.Страна_изготовления = Strana.SelectedIndex + 1;
            Список.ID_Тип_косметики = Tip.SelectedIndex + 1;
            Список.Дата_изготовления = (System.DateTime)Kalend.SelectedDate;
            Список.Фото = path;
            if(Flag==false)
            {
                ObchClass.base1.Информация_о_косметике.Add(Список);
            }
            ObchClass.base1.SaveChanges();
            MessageBox.Show("Записанно!", "Запись");
        }
        private void BFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();  
            OFD.ShowDialog();  
            path = OFD.FileName; 
            int n = path.IndexOf("Resources");  
            path = path.Substring(n);  
        }
    }
}
