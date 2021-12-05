using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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


            Strana.Items.Add("Все страны");
            List<Страна> Stranas = ObchClass.base1.Страна.ToList();
            for (int i = 0; i < Stranas.Count; i++)
            {
                Strana.Items.Add(Stranas[i].Страна_изготовления);
            }
            Strana.SelectedIndex = 0;
            Text.Text = "Найдено записей" + infStart.Count + " ";

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
            int indexST = Strana.SelectedIndex;
            if (indexST != 0) // определения выбранного элемента из Combobox
            {
                infFilter = infStart.Where(x => x.Страна_изготовления == indexST).ToList();
            }
            else
            {
                infFilter = infStart;  // если ни один из эл-тов Combobox не выбран (по умолчанию в этом случае будут все записи)
            }
        }



        private void Brend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Strana_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
