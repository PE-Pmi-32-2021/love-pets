using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LovePets_DAL;
using LovePets_EF;


namespace LovePets_BLL
{
    public class LovePetsBLL
    {

        public struct Reminder_struct_bll
        {
            public int id;
            public DateTime endTime;
            public DateTime startTime;
            public string subject;
            public string location;
            public string notes;
            public bool isRecursive;
            public string recurrenceRule;
            public int backR;
            public int backG;
            public int backB;
            public int frontR;
            public int frontG;
            public int frontB;
        }


        static T CopyStruct<T>(ref object s1)
        {
            GCHandle handle = GCHandle.Alloc(s1, GCHandleType.Pinned);
            T typedStruct = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return typedStruct;
        }

        public void AddNewReminder(Reminder_struct_bll rem)
        {

            ReminderDO reminder = new ReminderDO();
            object temp = rem;
            reminder.AddNewReminder(CopyStruct<ReminderDO.Reminder_struct>(ref temp));

        }

        public List<Reminder_struct_bll> GetReminders()
        {
            List<Reminder_struct_bll> reminders = new List<Reminder_struct_bll>();

            ReminderDO reminder = new ReminderDO();
            for (int i = 0; i < reminder.GetRemCount(); i++)
            {
                object temp = reminder.GetReminder(i);
                reminders.Add(CopyStruct<Reminder_struct_bll>(ref temp));

            }

            return reminders;
        }




        public void UpdatePhoto(int id, string photo_link)
        {
            ProfileDO profile = new ProfileDO();
            profile.SaveAnimalPhoto(photo_link, id);

        }

        public string GetFoteo(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetAnimalPhoto(id);
        }

        public int ProfilesCountGet()
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetProfileCount();
        }


        public void AddDefaultPhoto()
        {
            ProfileDO profile = new ProfileDO();
            profile.AddNewProfile("Enter full name", "Enter profile name", "Enter breed", "Enter color", false, new DateTime(2015, 7, 20), "C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/Photos/default_photo.png");
        }

        public void UpdateProfileName(int id, string full_name, string profile_name, string breed, string color, bool sex, System.DateTime birth_date)
        {
            ProfileDO profile = new ProfileDO();
            profile.UpdateProfileName(id, full_name, profile_name, breed, color, sex, birth_date);
        }



        public string GetProfileFullName(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetProfileFullName(id);
        }

        public string GetProfileName(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetProfileName(id);
        }


        public string GetBreed(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetBreed(id);
        }


        public string GetColoring(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetColoring(id);
        }

        public System.DateTime GetBirthdate(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetBirthdate(id);
        }



        public bool GetSex(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetSex(id);
        }


        public int GetAge(int id)
        {
            ProfileDO profile = new ProfileDO();
            return profile.GetAge(id);
        }

    }
}
