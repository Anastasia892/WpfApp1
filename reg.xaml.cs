using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Page
    {
        public reg()
        {
            InitializeComponent();
        }

        private void vhod2_Click(object sender, RoutedEventArgs e)
        {
            string passCheck = BoxParol.Password.ToString();

            if (passCheck.Length < 8) { MessageBox.Show("Длина пароля - минимум восемь символов, повторите ввод", "Пароль"); return; }
            Regex LAT = new Regex("(?=[A-Z])");
            bool LATmatch = LAT.IsMatch(passCheck);
            if (LATmatch != true) { MessageBox.Show("В пароле должна быть минимум одна заглавная латинская буква, повторите ввод", "Пароль"); return; }
            Regex lat = new Regex("(?=[a-z])");
            MatchCollection latMC = lat.Matches(passCheck);
            if (latMC.Count < 3) { MessageBox.Show("Количество строчных латинских букв в пароле должно быть не меньше трех, повторите ввод", "Пароль"); return; }
            Regex cif = new Regex("(?=[0-9])");
            MatchCollection cifMC = cif.Matches(passCheck);
            if (cifMC.Count < 2) { MessageBox.Show("Количество цифр в пароле должно быть не меньше двух, повторите ввод", "Пароль"); return; }
            Regex spec = new Regex("(?=[#?!@$%^&*-])");
            bool specMatch = spec.IsMatch(passCheck);
            if (specMatch != true) { MessageBox.Show("В пароле должен быть минимум один специальный символ (#?!@$%^&*-), повторите ввод", "Пароль"); return; }


            int pasCode = BoxParol.Password.GetHashCode();
            Пользователи UserRg = new Пользователи() { Имя = BoxIma.Text, Фамилия = BoxFam.Text, Логин = BoxLogin.Text, Пароль = pasCode, IDроли = 2 };
            ObchClass.base1.Пользователи.Add(UserRg);
            ObchClass.base1.SaveChanges();
            MessageBox.Show("Регистрация успешна!", "Регистрация");
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

