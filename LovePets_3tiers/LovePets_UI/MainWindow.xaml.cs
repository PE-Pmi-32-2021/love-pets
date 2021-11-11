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

namespace LovePets_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 obj1window = new Window1();
            this.Visibility = Visibility.Hidden;
            obj1window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window4 calendarwindow = new Window4();
            this.Visibility = Visibility.Hidden;
            calendarwindow.Show();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 anctewindow = new Window2();
            this.Visibility = Visibility.Hidden;
            anctewindow.Show();
        }
    }
}
