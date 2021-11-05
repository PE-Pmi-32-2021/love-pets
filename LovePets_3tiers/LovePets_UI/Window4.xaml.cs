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


            List<LovePetsBLL.Reminder_struct_bll> rems = bll.GetReminders();

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

        private void Window_Closing(object sender, CancelEventArgs e)
        {

            var bll = new LovePetsBLL();
                       



            bll.AddNewReminder();

        }
    }


  

}
