using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LovePets_EF;
using LovePets_Shared;

namespace LovePets_DAL
{
    public class ReminderDO
    {

        public int GetRemCount()
        {
            Database1Entities1 ne = new Database1Entities1();
            return ne.Reminders.Count();
        }


        public List<int> GetIds()
        {
            Database1Entities1 ne = new Database1Entities1();
            var ID = (from u in ne.Reminders select u.ID).ToList();
            return ID;
        }
        public void Delete() {
            Database1Entities1 ne = new Database1Entities1();
            var remDelete = (from u in ne.Reminders select u);
            ne.Reminders.RemoveRange(remDelete);
            ne.SaveChanges();
        }
        public void AddNewReminder(Reminder_st rem)
        {
            Database1Entities1 ne = new Database1Entities1();
            var reminder = new Reminder { ID = rem.id, EndTime = rem.endTime, StartTime = rem.startTime, Subject = rem.subject,
            Location = rem.location, Notes = rem.notes, IsRecursive =rem.isRecursive, RecurrenceRule = rem.recurrenceRule, 
            BackR = rem.backR, BackG = rem.backG, BackB = rem.backB, FrontR = rem.frontR, FrontG = rem.frontG, FrontB = rem.frontB};
            ne.Reminders.Add(reminder);
            ne.SaveChanges();
            
        }

        public Reminder_st GetReminder(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var ID = (from u in ne.Reminders where u.ID == id select u.ID).ToList();
            var EndTime = (from u in ne.Reminders where u.ID == id select u.EndTime).ToList();
            var StartTime = (from u in ne.Reminders where u.ID == id select u.StartTime).ToList();
            var Subject = (from u in ne.Reminders where u.ID == id select u.Subject).ToList();
            var Location = (from u in ne.Reminders where u.ID == id select u.Location).ToList();
            var Notes = (from u in ne.Reminders where u.ID == id select u.Notes).ToList();
            var IsRecursive = (from u in ne.Reminders where u.ID == id select u.IsRecursive).ToList();
            var RecurrenceRule = (from u in ne.Reminders where u.ID == id select u.RecurrenceRule).ToList();
            var BackR = (from u in ne.Reminders where u.ID == id select u.BackR).ToList();
            var BackG = (from u in ne.Reminders where u.ID == id select u.BackG).ToList();
            var BackB = (from u in ne.Reminders where u.ID == id select u.BackB).ToList();
            var FrontR = (from u in ne.Reminders where u.ID == id select u.FrontR).ToList();
            var FrontG = (from u in ne.Reminders where u.ID == id select u.FrontG).ToList();
            var FrontB = (from u in ne.Reminders where u.ID == id select u.FrontB).ToList();
            Reminder_st temp = new Reminder_st();
            if (ID.Count!=0)
            {
                temp.id = ID[0];
                temp.endTime = EndTime[0];
                temp.startTime = StartTime[0];
                temp.subject = Subject[0];
                temp.location = Location[0];
                temp.notes = Notes[0];
                temp.isRecursive = (bool)IsRecursive[0];
                temp.recurrenceRule = RecurrenceRule[0];
                temp.backR = (int)BackR[0];
                temp.backG = (int)BackG[0];
                temp.backB = (int)BackB[0];
                temp.frontR = (int)FrontR[0];
                temp.frontG = (int)FrontG[0];
                temp.frontB = (int)FrontB[0];
            }
            return temp;
        }
        







    }
}
