using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Str2.xaml
    /// </summary>
    public partial class Str2 : Page
    {
        List<Информация_о_косметике> infStart = ObchClass.base1.Информация_о_косметике.ToList();
        List<Информация_о_косметике> infFilter;
        public Str2()
        {
            InitializeComponent();
            List.ItemsSource = infStart;
            Brend.Items.Add("Все бренды");
            List<Бренд> Brends = ObchClass.base1.Бренд.ToList();
            for (int i = 0; i < Brends.Count; i++)
            {
                Brend.Items.Add(Brends[i].Имя_бренда);
            }
            Brend.SelectedIndex = 0;
            Text.Text = "Найдено записей" + infStart.Count + " ";
            DataContext = pc;
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

        private void Filter()
        {
            int index = Brend.SelectedIndex;
            if (index != 0) // определения выбранного элемента из Combobox
            {
                infFilter = infStart.Where(x => x.Бренд == index).ToList();
            }
            else
            {
                infFilter = infStart;  // если ни один из эл-тов Combobox не выбран (по умолчанию в этом случае будут все записи)
            }
            if (CBT.IsChecked == true)
            {
                infFilter = infFilter.Where(x => x.ID_Тип_косметики == 2).ToList();
            }
            if (CBP.IsChecked == true)
            {
                infFilter = infFilter.Where(x => x.ID_Тип_косметики == 1).ToList();
            }
            if (!string.IsNullOrWhiteSpace(Kalen.SelectedDate.ToString()))
            {
                infFilter = infFilter.Where(x => x.Дата_изготовления == Kalen.SelectedDate).ToList();
            }
            List.ItemsSource = infFilter;
            Text.Text = "Найдено записей" + infFilter.Count + " ";
        }



        private void Brend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }



        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CBT_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CBP_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CBT_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CBP_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void SortVz_Click(object sender, RoutedEventArgs e)
        {
            if (SrtBreand.IsChecked == true)
            {
                infFilter.Sort((x, y) => x.Бренд.CompareTo(y.Бренд));
            }
            if (StrData.IsChecked == true)
            {
                infFilter.Sort((x, y) => x.Дата_изготовления.CompareTo(y.Дата_изготовления));
            }
            if (StrStrana.IsChecked == true)
            {
                infFilter.Sort((x, y) => x.Страна_изготовления.CompareTo(y.Страна_изготовления));
            }
            List.Items.Refresh();
        }

        private void SortUb_Click(object sender, RoutedEventArgs e)
        {
            if (SrtBreand.IsChecked == true)
            {
                infFilter.Sort((x, y) => x.Бренд.CompareTo(y.Бренд));
            }
            if (StrData.IsChecked == true)
            {
                infFilter.Sort((x, y) => x.Дата_изготовления.CompareTo(y.Дата_изготовления));
            }
            if (StrStrana.IsChecked == true)
            {
                infFilter.Sort((x, y) => x.Страна_изготовления.CompareTo(y.Страна_изготовления));

            }
            infFilter.Reverse();
            List.Items.Refresh();
        }
        PageChange pc = new PageChange();
        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            switch (tb.Uid)
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }

            List.ItemsSource = infFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
        }
        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text);
            }
            catch
            {
                pc.CountPage = infFilter.Count;
            }
            pc.Countlist = infFilter.Count;
            List.ItemsSource = infFilter.Skip(0).Take(pc.CountPage).ToList();
        }
    }
}
