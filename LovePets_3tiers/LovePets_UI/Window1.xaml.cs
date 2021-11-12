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
        static int current_id = 0;
        List<Button> profiles;


        public Window1()
        {
            InitializeComponent();
            
            El.MouseUp += ellipse_MouseUp;

            var bll = new LovePetsBLL();

            if (bll.ProfilesCountGet() == 0)
            {
                bll.AddDefaultProfile();

            }
            else
            {

            }



            profiles = new List<Button>() { profile1, profile2, profile3, profile4, profile5 };
            for (int i = 0; i < bll.ProfilesCountGet() + 1 && i < 5; i++)
            {
                profiles[i].Visibility = Visibility.Visible;
            }
            for (int i = 0; i < bll.ProfilesCountGet(); i++)
            {
                profiles[i].Content = bll.GetProfileName(i + 1);
            }
        
            for (int i = bll.ProfilesCountGet(); i < 5; i++)
            {
                profiles[i].Content = "+";
            }

            current_id = 0;
            profiles[current_id].Background = Brushes.PaleVioletRed;

            // load photo
            BitmapImage lp = new BitmapImage();
            lp.BeginInit();
            lp.UriSource = new Uri(new LovePetsBLL().GetFoteo(1));
            lp.EndInit();

            ImageBrush foteo = ((ImageBrush)El.FindName("Foteo"));
            foteo.ImageSource = lp;



            // load info
            profile_name.Text = bll.GetProfileName(1);
            breed.Text = bll.GetBreed(1);
            color.Text = bll.GetColoring(1);
            sex.SelectedIndex = Convert.ToInt32(bll.GetSex(1));
            date.SelectedDate = bll.GetBirthdate(1);
            age.Content = bll.GetAge(1);
            full_name.Text = bll.GetProfileFullName(1);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var bll = new LovePetsBLL();

            bll.UpdateProfile(current_id+1, full_name.Text, profile_name.Text, breed.Text, color.Text, Convert.ToBoolean(sex.SelectedIndex), date.SelectedDate.HasValue ? date.SelectedDate.Value : DateTime.Now);



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

                new LovePetsBLL().UpdatePhoto(current_id+1, openFileDialog.FileName);

                ImageBrush foteo = ((ImageBrush)El.FindName("Foteo"));
                foteo.ImageSource = lp;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateProfileo(0);
        }


        private void Button_Click_Profile2(object sender, RoutedEventArgs e)
        {
            UpdateProfileo(1);
        }

        private void Button_Click_Profile3(object sender, RoutedEventArgs e)
        {
            UpdateProfileo(2);
        }

        private void Button_Click_Profile4(object sender, RoutedEventArgs e)
        {
            UpdateProfileo(3);
        }
        private void Button_Click_Profile5(object sender, RoutedEventArgs e)
        {
            UpdateProfileo(4);
        }

        private void profile_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (profiles != null)
            {
                profiles[current_id].Content = profile_name.Text;
            }
        }

        void UpdateProfileo(int button_id)
        {
            profiles[current_id].Background = Brushes.LightGray;
            var bll = new LovePetsBLL();
            bll.UpdateProfile(current_id+1, full_name.Text, profile_name.Text, breed.Text, color.Text, Convert.ToBoolean(sex.SelectedIndex), date.SelectedDate.HasValue ? date.SelectedDate.Value : DateTime.Now);

            if (profiles[button_id].Content.ToString() == "+" && bll.ProfilesCountGet() <= 5)
            {

                bll.AddDefaultProfile();
                current_id++;
                profiles[current_id].Content = bll.GetProfileName(current_id + 1);

                for (int i = 0; i < bll.ProfilesCountGet() + 1 && i < 5; i++)
                {
                    profiles[i].Visibility = Visibility.Visible;
                }
                for (int i = 0; i < bll.ProfilesCountGet(); i++)
                {
                    profiles[i].Content = bll.GetProfileName(i + 1);
                }

                for (int i = bll.ProfilesCountGet(); i < 5; i++)
                {
                    profiles[i].Content = "+";
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

            ImageBrush foteo = ((ImageBrush)El.FindName("Foteo"));
            foteo.ImageSource = lp;



            // load info
            profile_name.Text = bll.GetProfileName(current_id+1);
            breed.Text = bll.GetBreed(current_id + 1);
            color.Text = bll.GetColoring(current_id + 1);
            sex.SelectedIndex = Convert.ToInt32(bll.GetSex(current_id + 1));
            date.SelectedDate = bll.GetBirthdate(current_id + 1);
            age.Content = bll.GetAge(current_id + 1);
            full_name.Text = bll.GetProfileFullName(current_id + 1);

            profiles[current_id].Background = Brushes.PaleVioletRed;
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            age.Content = System.DateTime.Now.Year - date.SelectedDate.Value.Year;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var bll = new LovePetsBLL();
            bll.UpdateProfile(current_id+1, full_name.Text, profile_name.Text, breed.Text, color.Text, Convert.ToBoolean(sex.SelectedIndex), date.SelectedDate.HasValue ? date.SelectedDate.Value : DateTime.Now);

        }

      
    }
}
