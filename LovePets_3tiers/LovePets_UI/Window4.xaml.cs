namespace LovePets_UI
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;
    using log4net;
    using LovePets_BLL;
    using LovePets_Shared;
    using Syncfusion.UI.Xaml.Scheduler;

    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Window4()
        {
            LovePetsBLL bll = new LovePetsBLL();

            log4net.Config.XmlConfigurator.Configure();

            this.InitializeComponent();

            log.Info("Entered to reminder window!");

            ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();

            List<Reminder_st> rems = bll.GetReminders();

            for (int i = 0; i < rems.Count; i++)
            {
                ScheduleAppointment rem = new ScheduleAppointment
                {
                    StartTime = rems[i].StartTime,
                    EndTime = rems[i].EndTime,
                    Subject = rems[i].Subject,
                    Location = rems[i].Location,
                    Notes = rems[i].Notes,
                    RecurrenceRule = rems[i].RecurrenceRule,
                    AppointmentBackground = new SolidColorBrush(Color.FromRgb((byte)rems[i].BackR, (byte)rems[i].BackG, (byte)rems[i].BackB)),
                    Foreground = new SolidColorBrush(Color.FromRgb((byte)rems[i].FrontR, (byte)rems[i].FrontG, (byte)rems[i].FrontB))
                };

                appointmentCollection.Add(rem);
            }

            Schedule.ItemsSource = appointmentCollection;
            log.Info("Loaded appointments!");
        }

        private void SaveChanges()
        {
            ScheduleAppointmentCollection appointmentCollection = (ScheduleAppointmentCollection)Schedule.ItemsSource;
            LovePetsBLL bll = new LovePetsBLL();
            bll.DeleteReminders();
            foreach (ScheduleAppointment item in appointmentCollection)
            {
                Reminder_st rem = new Reminder_st
                {
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Subject = item.Subject,
                    Location = item.Location,
                    Notes = item.Notes,
                    RecurrenceRule = item.RecurrenceRule,
                    BackR = ((SolidColorBrush)item.AppointmentBackground).Color.R,
                    BackG = ((SolidColorBrush)item.AppointmentBackground).Color.G,
                    BackB = ((SolidColorBrush)item.AppointmentBackground).Color.B,
                    FrontR = ((SolidColorBrush)item.Foreground).Color.R,
                    FrontG = ((SolidColorBrush)item.Foreground).Color.G,
                    FrontB = ((SolidColorBrush)item.Foreground).Color.B
                };

                bll.AddNewReminder(rem);
            }

            log.Info("Save changes from reminders!");
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            this.SaveChanges();
            log.Info("Program closed!");
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.SaveChanges();
            log.Info("Exit from reminder window!");

            MainWindow window1 = new MainWindow();
           this.Visibility = Visibility.Hidden;
            window1.Show();
        }
    }
}
