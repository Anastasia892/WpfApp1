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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Okno.xaml
    /// </summary>
    public partial class Okno : Window
    {

        Пользователи polz;
        public Okno(Пользователи User)
        {
            InitializeComponent();
            polz = User;
            Imi.Text = polz.Имя;
            Fam.Text = polz.Фамилия;
            Log.Text = polz.Логин;
 
        }

        private void ButtonIzmena_Click(object sender, RoutedEventArgs e)
        {
            int i;
            polz.Имя = Imi.Text;
            polz.Фамилия = Fam.Text;

            polz.Логин = Log.Text;
            i = Par.Password.GetHashCode();
            polz.Пароль=i;
            ObchClass.base1.SaveChanges();
            MessageBox.Show("Готово");
            this.Close();
        }
    }
}
