using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using LovePets_Shared;

namespace LovePets_UI
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
         

        public Window4()
        {
            var bll = new LovePetsBLL();

            InitializeComponent();
            ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();


            List<Reminder_st> rems = bll.GetReminders();

            for (int i = 0; i < rems.Count; i++)
            {
                ScheduleAppointment rem = new ScheduleAppointment();

                rem.StartTime = rems[i].startTime;
                rem.EndTime = rems[i].endTime;
                rem.Subject = rems[i].subject;
                rem.Location = rems[i].location;
                rem.Notes = rems[i].notes;
                rem.RecurrenceRule = rems[i].recurrenceRule;
                rem.AppointmentBackground = new SolidColorBrush(Color.FromRgb((byte)rems[i].backR, (byte)rems[i].backG, (byte)rems[i].backB));
                rem.Foreground = new SolidColorBrush(Color.FromRgb((byte)rems[i].frontR, (byte)rems[i].frontG, (byte)rems[i].frontB));

                appointmentCollection.Add(rem); 
            }

            Schedule.ItemsSource = appointmentCollection;

        }

         private void SaveChanges()
        {
            ScheduleAppointmentCollection appointmentCollection = (ScheduleAppointmentCollection)Schedule.ItemsSource;
            var bll = new LovePetsBLL();
            bll.DeleteReminders();
            foreach (var item in appointmentCollection)
            {
                Reminder_st rem = new Reminder_st();
                rem.startTime = item.StartTime;
                rem.endTime = item.EndTime;
                rem.subject = item.Subject;
                rem.location = item.Location;
                rem.notes = item.Notes;
                rem.recurrenceRule = item.RecurrenceRule;
                rem.backR = ((SolidColorBrush)item.AppointmentBackground).Color.R;
                rem.backG = ((SolidColorBrush)item.AppointmentBackground).Color.G;
                rem.backB = ((SolidColorBrush)item.AppointmentBackground).Color.B;
                rem.frontR = ((SolidColorBrush)item.Foreground).Color.R;
                rem.frontG = ((SolidColorBrush)item.Foreground).Color.G;
                rem.frontB = ((SolidColorBrush)item.Foreground).Color.B;

                bll.AddNewReminder(rem);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {

            SaveChanges();


        }
 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveChanges();


            MainWindow window1 = new MainWindow();
            this.Visibility = Visibility.Hidden;
            window1.Show();
        }

        
    }


  

}
