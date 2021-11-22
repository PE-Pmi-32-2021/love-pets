namespace LovePets_UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using log4net;
    using LovePets_BLL;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static int current_id = 0;
        private readonly List<Button> profiles;

        public Window1()
        {
            this.InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();

            log.Info("Entered to profile window!");

            this.El.MouseUp += this.ellipse_MouseUp;

            LovePetsBLL bll = new LovePetsBLL();

            if (bll.ProfilesCountGet() == 0)
            {
                bll.AddDefaultProfile();
            }

            this.profiles = new List<Button>() { profile1, profile2, profile3, profile4, profile5 };

            for (int i = 0; i < bll.ProfilesCountGet() + 1 && i < 5; i++)
            {
                this.profiles[i].Visibility = Visibility.Visible;
            }

            for (int i = 0; i < bll.ProfilesCountGet(); i++)
            {
                this.profiles[i].Content = bll.GetProfileName(i + 1);
            }

            for (int i = bll.ProfilesCountGet(); i < 5; i++)
            {
                this.profiles[i].Content = "+";
            }

            current_id = 0;
            this.profiles[current_id].Background = Brushes.PaleVioletRed;

            // load photo
            BitmapImage lp = new BitmapImage();
            lp.BeginInit();
            lp.UriSource = new Uri(new LovePetsBLL().GetFoteo(1));
            lp.EndInit();

            ImageBrush foteo = (ImageBrush)El.FindName("Foteo");
            foteo.ImageSource = lp;

            // load info
            profile_name.Text = bll.GetProfileName(1);
            breed.Text = bll.GetBreed(1);
            color.Text = bll.GetColoring(1);
            sex.SelectedIndex = Convert.ToInt32(bll.GetSex(1));
            date.SelectedDate = bll.GetBirthdate(1);
            age.Content = bll.GetAge(1);
            full_name.Text = bll.GetProfileFullName(1);

            log.Info("Load profile info from DB");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LovePetsBLL bll = new LovePetsBLL();

            bll.UpdateProfile(current_id + 1, full_name.Text, profile_name.Text, breed.Text, color.Text, Convert.ToBoolean(sex.SelectedIndex), date.SelectedDate.HasValue ? date.SelectedDate.Value : DateTime.Now);
            log.Info("Update profiles in DB");

            log.Info("Exit from profile window!");

            MainWindow mainwindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainwindow.Show();
        }

        private void ellipse_MouseUp(object sender, RoutedEventArgs e)
        {
            log.Info("Try load new image!");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage lp = new BitmapImage();
                try
                {
                    lp.BeginInit();
                    lp.UriSource = new Uri(openFileDialog.FileName);
                    lp.EndInit();

                    new LovePetsBLL().UpdatePhoto(current_id + 1, openFileDialog.FileName);

                    ImageBrush foteo = (ImageBrush)El.FindName("Foteo");
                    foteo.ImageSource = lp;

                    log.Info("Image succesfully loaded!");
                }
                catch (Exception)
                {
                    log.Error("Error during image loading. Check the extension!");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.UpdateProfileo(0);
        }

        private void Button_Click_Profile2(object sender, RoutedEventArgs e)
        {
            this.UpdateProfileo(1);
        }

        private void Button_Click_Profile3(object sender, RoutedEventArgs e)
        {
            this.UpdateProfileo(2);
        }

        private void Button_Click_Profile4(object sender, RoutedEventArgs e)
        {
            this.UpdateProfileo(3);
        }

        private void Button_Click_Profile5(object sender, RoutedEventArgs e)
        {
            this.UpdateProfileo(4);
        }

        private void profile_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.profiles != null)
            {
                this.profiles[current_id].Content = profile_name.Text;
            }
        }

        private void UpdateProfileo(int button_id)
        {
            this.profiles[current_id].Background = Brushes.LightGray;
            LovePetsBLL bll = new LovePetsBLL();
            bll.UpdateProfile(current_id + 1, full_name.Text, profile_name.Text, breed.Text, color.Text, Convert.ToBoolean(sex.SelectedIndex), date.SelectedDate.HasValue ? date.SelectedDate.Value : DateTime.Now);

            if (this.profiles[button_id].Content.ToString() == "+" && bll.ProfilesCountGet() <= 5)
            {
                bll.AddDefaultProfile();
                current_id++;
                this.profiles[current_id].Content = bll.GetProfileName(current_id + 1);

                for (int i = 0; i < bll.ProfilesCountGet() + 1 && i < 5; i++)
                {
                    this.profiles[i].Visibility = Visibility.Visible;
                }

                for (int i = 0; i < bll.ProfilesCountGet(); i++)
                {
                    this.profiles[i].Content = bll.GetProfileName(i + 1);
                }

                for (int i = bll.ProfilesCountGet(); i < 5; i++)
                {
                    this.profiles[i].Content = "+";
                }
            }
            else
            {
                current_id = button_id;
            }

            // load photo
            BitmapImage lp = new BitmapImage();
            lp.BeginInit();
            lp.UriSource = new Uri(new LovePetsBLL().GetFoteo(current_id + 1));
            lp.EndInit();

            ImageBrush foteo = (ImageBrush)El.FindName("Foteo");
            foteo.ImageSource = lp;

            // load info
            profile_name.Text = bll.GetProfileName(current_id + 1);
            breed.Text = bll.GetBreed(current_id + 1);
            color.Text = bll.GetColoring(current_id + 1);
            sex.SelectedIndex = Convert.ToInt32(bll.GetSex(current_id + 1));
            date.SelectedDate = bll.GetBirthdate(current_id + 1);
            age.Content = bll.GetAge(current_id + 1);
            full_name.Text = bll.GetProfileFullName(current_id + 1);

            this.profiles[current_id].Background = Brushes.PaleVioletRed;

            log.Info($"Switch to profile {current_id + 1}");
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            age.Content = System.DateTime.Now.Year - date.SelectedDate.Value.Year;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LovePetsBLL bll = new LovePetsBLL();
            bll.UpdateProfile(current_id + 1, full_name.Text, profile_name.Text, breed.Text, color.Text, Convert.ToBoolean(sex.SelectedIndex), date.SelectedDate.HasValue ? date.SelectedDate.Value : DateTime.Now);
            log.Info("Program closed!");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
