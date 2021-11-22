namespace LovePets_UI
{
    using System;
    using System.Windows;
    using log4net;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            this.InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Entered main window!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            log.Info("Clicked button to enter profile window!");
            Window1 obj1window = new Window1();
           this.Visibility = Visibility.Hidden;
            obj1window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            log.Info("Clicked button to enter reminder window!");
            Window4 calendarwindow = new Window4();
           this.Visibility = Visibility.Hidden;
            calendarwindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            log.Info("Clicked button to enter quize window!");
            Window2 anctewindow = new Window2();
           this.Visibility = Visibility.Hidden;
            anctewindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            log.Info("Program closed!");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
