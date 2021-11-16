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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        List<RadioButton> radioButtons;

        Dictionary<string, int> results_dict = new Dictionary<string, int>(5);

        int current_question = 0;

        public Window2()
        {
            InitializeComponent();

            results_dict.Add("dogs", 0);
            results_dict.Add("cats", 0);
            results_dict.Add("rodents", 0);
            results_dict.Add("reptiles", 0);
            results_dict.Add("birds", 0);


            var bll = new LovePetsBLL();
            question.Text = bll.GetQuestion(1);
            image3.Source = new BitmapImage(new Uri(bll.GetQuestionPhoto(1)));

            var answers_list = bll.GetAnswers(1);

            radioButtons = new List<RadioButton> { answer1, answer2, answer3, answer4, answer5 };

            for (int i = 0; i < answers_list.Count; i++)
            {
                radioButtons[i].Content = answers_list[i];
            }

            for (int i = answers_list.Count; i< 5; i++)
            {
                radioButtons[i].Visibility = Visibility.Hidden;
            }
            current_question = 0;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainwindow.Show();
        }


        // next
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].IsChecked == true)
                {
                    var bll = new LovePetsBLL();
                    Dictionary<string, int> categ_dict = bll.GetCategoryPoints(current_question + 1, i);


                    results_dict["dogs"] += categ_dict["dogs"];
                    results_dict["cats"] += categ_dict["cats"];
                    results_dict["rodents"] += categ_dict["rodents"];
                    results_dict["reptiles"] += categ_dict["reptiles"];
                    results_dict["birds"] += categ_dict["birds"];


                    current_question += 1;

                    if (current_question < 20)
                    {

                        question.Text = bll.GetQuestion(current_question + 1);
                        image3.Source = new BitmapImage(new Uri(bll.GetQuestionPhoto(current_question + 1)));
                        var answers_list = bll.GetAnswers(current_question + 1);
                        radioButtons[0].IsChecked = true;
                        for (int j = 0; j < answers_list.Count; j++)
                        {
                            radioButtons[j].Content = answers_list[j];
                            radioButtons[j].Visibility = Visibility.Visible;
                        }



                        for (int j = answers_list.Count; j < 5; j++)
                        {
                            radioButtons[j].Visibility = Visibility.Hidden;
                        }
                    }
                    else
                    {
                        question.Visibility = Visibility.Hidden;
                        next_button.Visibility = Visibility.Hidden;
                        image3.Visibility = Visibility.Hidden;
                        for (int j = 0; j < 5; j++)
                        {
                            radioButtons[j].Visibility = Visibility.Hidden;
                        }

                        image1.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        textblock1.Visibility = Visibility.Visible;
                        textblock2.Visibility = Visibility.Visible;
                        textblock3.Visibility = Visibility.Visible;

                        int masx = 0;
                        string max_res = "";
                        int index = 0;
                        foreach (KeyValuePair<string, int> keyValue in results_dict)
                        {
                            if(keyValue.Value > masx)
                            {
                                masx = keyValue.Value;
                                max_res = keyValue.Key;

                            }
                        }


                        if(max_res == "dogs")
                        {
                            index = 1;
                        }
                        else if(max_res == "cats")
                        {
                            index = 2;
                        }
                        else if (max_res == "rodents")
                        {
                            index = 3;
                        }
                        else if (max_res == "reptiles")
                        {
                            index = 4;
                        }
                        else
                        {
                            index = 5;
                        }



                        image1.Source = new BitmapImage(new Uri(bll.GetPhoto1(index)));
                        image2.Source = new BitmapImage(new Uri(bll.GetPhoto2(index)));

                        textblock1.Text = bll.GetTitle(index);
                        textblock2.Text = bll.GetParagraph1(index);

                        textblock3.Text = bll.GetParagraph2(index);



                    }
                }
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
