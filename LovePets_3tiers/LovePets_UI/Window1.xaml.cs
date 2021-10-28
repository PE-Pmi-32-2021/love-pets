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
using System.Windows.Shapes;
using LovePets_BLL;

namespace LovePets_UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public Window1()
        {
            InitializeComponent();
            El.MouseUp += ellipse_MouseUp;

            BitmapImage lp = new BitmapImage();
            lp.BeginInit();
            lp.UriSource = new Uri(new LovePetsBLL().GetFoteo(0));
            lp.EndInit();

            ImageBrush foteo = ((ImageBrush)El.FindName("Foteo"));
            foteo.ImageSource = lp;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainwindow.Show();
            
        }

        private void ellipse_MouseUp(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage lp = new BitmapImage();
                lp.BeginInit();
                lp.UriSource = new Uri(openFileDialog.FileName);
                lp.EndInit();

                new LovePetsBLL().UpdatePhoto(0, openFileDialog.FileName);

                ImageBrush foteo = ((ImageBrush)El.FindName("Foteo"));
                foteo.ImageSource = lp;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            puasenzia.Content="Пуасенція";
        }
    }
}
