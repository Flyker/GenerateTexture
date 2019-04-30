using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

namespace GenerateTexture
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoBtn_Click(object sender, RoutedEventArgs e)
        {
            //
            string LoadFilePath = @"Sprites/catloader.gif";
            string SaveFilePath = @"Sprites/catloader.png";
            //получение итогового изображения
            BitmapSource Bmp = ConvertTexture.GifToLongBmp(LoadFilePath);
            //сжатие итогового изображения в png
            ConvertTexture.SaveToPng(Bmp, SaveFilePath);
        }

    }
}
