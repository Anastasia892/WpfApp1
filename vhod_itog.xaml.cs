using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для vhod_itog.xaml
    /// </summary>
    public partial class vhod_itog : Page
    {
        List<Karta> Search;
        List<Karta> Karr = new List<Karta>();
        public vhod_itog()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("List.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Arr = sr.ReadLine().Split(';');
                    Karr.Add(new Karta() { Фамилия = Arr[0], Имя = Arr[1], Отчество = Arr[2], Пол = Arr[3], Дата = Arr[4], Учет = Arr[5], ФИО_Врачь = Arr[6], Услуги = Arr[5] });
                }
            }
            table.ItemsSource = Karr;
            FamilCheck.IsChecked = true;
            ImiCheck.IsChecked = true;
            OtCheck.IsChecked = true;
            GenderCheck.IsChecked = true;
            DataCheck.IsChecked = true;
            UchetCheck.IsChecked = true;
            FioVCheck.IsChecked = true;
            UslugiCheck.IsChecked = true;
        }
        private void FamilCheck_Checked(object sender, RoutedEventArgs e)
        {
            FioVCheck.Visibility = Visibility.Visible;
        }

        private void ImiCheck_Checked(object sender, RoutedEventArgs e)
        {
            ImiCheck.Visibility = Visibility.Visible;
        }
        private void OtCheck_Checked(object sender, RoutedEventArgs e)
        {
            OtCheck.Visibility = Visibility.Visible;
        }

        private void GenderCheck_Checked(object sender, RoutedEventArgs e)
        {
            GenderCheck.Visibility = Visibility.Visible;
        }

        private void DataCheck_Checked(object sender, RoutedEventArgs e)
        {
            DataCheck.Visibility = Visibility.Visible;
        }

        private void UchetCheck_Checked(object sender, RoutedEventArgs e)
        {
            UchetCheck.Visibility = Visibility.Visible;
        }

        private void FioVCheck_Checked(object sender, RoutedEventArgs e)
        {
            FioVCheck.Visibility = Visibility.Visible;
        }

        private void UslugiCheck_Checked(object sender, RoutedEventArgs e)
        {
            UslugiCheck.Visibility = Visibility.Visible;
        }
        int i;
        private void ButNaiti_Click(object sender, RoutedEventArgs e)
        {
            Search = new List<Karta>();
            if (Radio_FIo.IsChecked == true)
            {
                for (int i = 0; i < Karr.Count; i++)
                {
                    if (TBPoisk.Text == Karr[i].ФИО_Врачь)
                    {
                        Karta search = new Karta
                        {
                            Фамилия = Karr[i].Фамилия,
                            Имя = Karr[i].Имя,
                            Отчество = Karr[i].Отчество,
                            Пол = Karr[i].Пол,
                            Дата = Karr[i].Дата,
                            Учет = Karr[i].Учет,
                            ФИО_Врачь = Karr[i].ФИО_Врачь,
                            Услуги = Karr[i].Услуги,

                        };
                        Search.Add(search);
                    }
                }
            }
            try
            {
                table.ItemsSource = Search;
            }
            catch
            {
                MessageBox.Show("Повторите вход ввод", "Не найдено!");
            }
            if (Radio_Pol.IsChecked == true)
            {
                for (int i = 0; i < Karr.Count; i++)
                {
                    if (TBPoisk.Text == Karr[i].Пол)
                    {
                        Karta search = new Karta
                        {
                            Фамилия = Karr[i].Фамилия,
                            Имя = Karr[i].Имя,
                            Отчество = Karr[i].Отчество,
                            Пол = Karr[i].Пол,
                            Дата = Karr[i].Дата,
                            Учет = Karr[i].Учет,
                            ФИО_Врачь = Karr[i].ФИО_Врачь,
                            Услуги = Karr[i].Услуги,

                        };
                        Search.Add(search);
                    }
                }
            }
            try
            {
                table.ItemsSource = Search;
            }
            catch
            {
                MessageBox.Show("Повторите ввод", "Не найдено!");
            }
        }
    }


}


