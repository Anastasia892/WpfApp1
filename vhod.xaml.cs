using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для vhod.xaml
    /// </summary>
    public partial class vhod : Page
    {
        string path = "Poliz.csv";
        List<Class1> Poliz = new List<Class1>();
        public vhod()
        {
            InitializeComponent();
        }

        private void nazad2_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame.Navigate(new nachalo());
        }

        private void vhod3_Click(object sender, RoutedEventArgs e)
        {
            int passCode = BoxParol2.Password.GetHashCode();
            Пользователи User = ObchClass.base1.Пользователи.FirstOrDefault(x => x.Логин == BoxLogin2.Text && x.Пароль == passCode);
            if (User != null)
            {
                if (User.IDроли == 1)
                {
                    MessageBox.Show("Добро пожаловать АДМИН " + User.Имя , "Авторизация");
                    Frame2.Frame.Navigate(new Admin());
                }
                else
                {
                    MessageBox.Show("Здравствуйте, " + User.Имя , "Авторизация");
                    Frame2.Frame.Navigate(new vhod_itog());
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден, повторите ввод или зарегистрируйтесь!", "Авторизация");
            }


        }
    }
}
