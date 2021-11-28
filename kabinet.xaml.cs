using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для kabinet.xaml
    /// </summary>
    public partial class kabinet : Page

    {
        Пользователи us;
        string path;
        Фото usPh;
        public kabinet(Пользователи p)
        {
            InitializeComponent();
            us = p;
            TBIm.Text = us.Имя;
            TBFam.Text = us.Фамилия;
            if (us.Фото != null && us.Фото.БиФото != null)
            {
                byte[] binArr = us.Фото.БиФото;
                BitmapImage bmUserPic = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(binArr))
                {
                    bmUserPic.BeginInit();
                    bmUserPic.StreamSource = ms;
                    bmUserPic.CacheOption = BitmapCacheOption.OnLoad;
                    bmUserPic.EndInit();
                }
                UserPhoto.Source = bmUserPic;
            }
        }
     private void ButtonRed_Click(object sender, RoutedEventArgs e)
        
        {
            Okno o = new Okno(us);
            o.ShowDialog();
            Frame2.Frame.Navigate(new kabinet(us));
        }

        private void ButtonIzPhoto_Click(object sender, RoutedEventArgs e)
        {
            Фото pic = ObchClass.base1.Фото.FirstOrDefault(x => x.ID == us.ID);
            if (pic == null)
            {
                usPh = new Фото();
                usPh.ID = us.ID;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                ImageConverter imageConverter = new ImageConverter();
                byte[] bi = (byte[])imageConverter.ConvertTo(img, typeof(byte[]));
                usPh.БиФото = bi;
                ObchClass.base1.Фото.Add(usPh);
                ObchClass.base1.SaveChanges();
                MessageBox.Show("Фото добавлено!", "Личный кабинет");
            }
            else
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                ImageConverter imageConverter = new ImageConverter();
                byte[] bi = (byte[])imageConverter.ConvertTo(img, typeof(byte[]));
                pic.БиФото = bi;
                ObchClass.base1.SaveChanges();
                MessageBox.Show("Фото обновлено!", "Личный кабинет");
            }
            Frame2.Frame.Navigate(new kabinet(us));
        }

        private void ButtonVihod_Click(object sender, RoutedEventArgs e)
        {
            Frame2.Frame.Navigate(new vhod());
        }
    }
}
    
