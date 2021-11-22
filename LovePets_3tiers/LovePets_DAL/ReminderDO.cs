namespace LovePets_DAL
{
    using System.Collections.Generic;
    using System.Linq;
    using LovePets_EF;
    using LovePets_Shared;

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
            List<int> ID = (from u in ne.Reminders select u.ID).ToList();
            return ID;
        }

        public void Delete()
        {
            Database1Entities1 ne = new Database1Entities1();
            IQueryable<Reminder> remDelete = from u in ne.Reminders select u;
            ne.Reminders.RemoveRange(remDelete);
            ne.SaveChanges();
        }

        public void AddNewReminder(Reminder_st rem)
        {
            Database1Entities1 ne = new Database1Entities1();
            Reminder reminder = new Reminder
            {
                ID = rem.Id,
                EndTime = rem.EndTime,
                StartTime = rem.StartTime,
                Subject = rem.Subject,
                Location = rem.Location,
                Notes = rem.Notes,
                IsRecursive = rem.IsRecursive,
                RecurrenceRule = rem.RecurrenceRule,
                BackR = rem.BackR,
                BackG = rem.BackG,
                BackB = rem.BackB,
                FrontR = rem.FrontR,
                FrontG = rem.FrontG,
                FrontB = rem.FrontB
            };
            ne.Reminders.Add(reminder);
            ne.SaveChanges();
        }

        public Reminder_st GetReminder(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            List<int> ID = (from u in ne.Reminders where u.ID == id select u.ID).ToList();
            List<System.DateTime> EndTime = (from u in ne.Reminders where u.ID == id select u.EndTime).ToList();
            List<System.DateTime> StartTime = (from u in ne.Reminders where u.ID == id select u.StartTime).ToList();
            List<string> Subject = (from u in ne.Reminders where u.ID == id select u.Subject).ToList();
            List<string> Location = (from u in ne.Reminders where u.ID == id select u.Location).ToList();
            List<string> Notes = (from u in ne.Reminders where u.ID == id select u.Notes).ToList();
            List<bool?> IsRecursive = (from u in ne.Reminders where u.ID == id select u.IsRecursive).ToList();
            List<string> RecurrenceRule = (from u in ne.Reminders where u.ID == id select u.RecurrenceRule).ToList();
            List<int?> BackR = (from u in ne.Reminders where u.ID == id select u.BackR).ToList();
            List<int?> BackG = (from u in ne.Reminders where u.ID == id select u.BackG).ToList();
            List<int?> BackB = (from u in ne.Reminders where u.ID == id select u.BackB).ToList();
            List<int?> FrontR = (from u in ne.Reminders where u.ID == id select u.FrontR).ToList();
            List<int?> FrontG = (from u in ne.Reminders where u.ID == id select u.FrontG).ToList();
            List<int?> FrontB = (from u in ne.Reminders where u.ID == id select u.FrontB).ToList();
            Reminder_st temp = new Reminder_st();
            if (ID.Count != 0)
            {
                temp.Id = ID[0];
                temp.EndTime = EndTime[0];
                temp.StartTime = StartTime[0];
                temp.Subject = Subject[0];
                temp.Location = Location[0];
                temp.Notes = Notes[0];
                temp.IsRecursive = (bool)IsRecursive[0];
                temp.RecurrenceRule = RecurrenceRule[0];
                temp.BackR = (int)BackR[0];
                temp.BackG = (int)BackG[0];
                temp.BackB = (int)BackB[0];
                temp.FrontR = (int)FrontR[0];
                temp.FrontG = (int)FrontG[0];
                temp.FrontB = (int)FrontB[0];
            }

            return temp;
        }
    }
}
