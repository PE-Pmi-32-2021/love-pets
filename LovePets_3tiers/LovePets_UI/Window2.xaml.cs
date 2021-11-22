namespace LovePets_UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using log4net;
    using LovePets_BLL;

    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly List<RadioButton> radioButtons;
        private readonly Dictionary<string, int> results_dict = new Dictionary<string, int>(5);
        private int current_question = 0;

        public Window2()
        {
            this.InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

            log.Info("Entered to quize window!");

            this.results_dict.Add("dogs", 0);
            this.results_dict.Add("cats", 0);
            this.results_dict.Add("rodents", 0);
            this.results_dict.Add("reptiles", 0);
            this.results_dict.Add("birds", 0);

            LovePetsBLL bll = new LovePetsBLL();
            question.Text = bll.GetQuestion(1);
            image3.Source = new BitmapImage(new Uri(bll.GetQuestionPhoto(1)));

            List<string> answers_list = bll.GetAnswers(1);

            this.radioButtons = new List<RadioButton> { answer1, answer2, answer3, answer4, answer5 };

            for (int i = 0; i < answers_list.Count; i++)
            {
                this.radioButtons[i].Content = answers_list[i];
            }

            for (int i = answers_list.Count; i < 5; i++)
            {
                this.radioButtons[i].Visibility = Visibility.Hidden;
            }

            this.current_question = 0;
            log.Info("Loaded first question!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            log.Info("Exit from quize window!");

            MainWindow mainwindow = new MainWindow();
           this.Visibility = Visibility.Hidden;
            mainwindow.Show();
        }

        // next
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < this.radioButtons.Count; i++)
            {
                if (this.radioButtons[i].IsChecked == true)
                {
                    LovePetsBLL bll = new LovePetsBLL();
                    bll.UpdateResults(this.results_dict, ++this.current_question, i);

                    if (this.current_question < 20)
                    {
                        question.Text = bll.GetQuestion(this.current_question + 1);
                        image3.Source = new BitmapImage(new Uri(bll.GetQuestionPhoto(this.current_question + 1)));
                        List<string> answers_list = bll.GetAnswers(this.current_question + 1);
                        this.radioButtons[0].IsChecked = true;
                        for (int j = 0; j < answers_list.Count; j++)
                        {
                            this.radioButtons[j].Content = answers_list[j];
                            this.radioButtons[j].Visibility = Visibility.Visible;
                        }

                        for (int j = answers_list.Count; j < 5; j++)
                        {
                            this.radioButtons[j].Visibility = Visibility.Hidden;
                        }

                        log.Info("Next question loaded!");
                    }
                    else
                    {
                        question.Visibility = Visibility.Hidden;
                        next_button.Visibility = Visibility.Hidden;
                        image3.Visibility = Visibility.Hidden;
                        for (int j = 0; j < 5; j++)
                        {
                            this.radioButtons[j].Visibility = Visibility.Hidden;
                        }

                        image1.Visibility = Visibility.Visible;
                        image2.Visibility = Visibility.Visible;
                        textblock1.Visibility = Visibility.Visible;
                        textblock2.Visibility = Visibility.Visible;
                        textblock3.Visibility = Visibility.Visible;

                        int index = bll.ChosenAnimal(this.results_dict);

                        image1.Source = new BitmapImage(new Uri(bll.GetPhoto1(index)));
                        image2.Source = new BitmapImage(new Uri(bll.GetPhoto2(index)));

                        textblock1.Text = bll.GetTitle(index);
                        textblock2.Text = bll.GetParagraph1(index);

                        textblock3.Text = bll.GetParagraph2(index);

                        log.Info("Result loaded!");
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            log.Info("Program closed!");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
