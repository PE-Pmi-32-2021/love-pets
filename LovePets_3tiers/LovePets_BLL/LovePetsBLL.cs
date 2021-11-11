using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LovePets_DAL;
using LovePets_EF;
using LovePets_Shared;

namespace LovePets_BLL
{
    public class LovePetsBLL
    {


        public string GetTitle(int id)
        {

            ResultsDO res = new ResultsDO();
            return res.GetTitle(id);

        }
        public string GetParagraph1(int id)
        {
            ResultsDO res = new ResultsDO();
            return res.GetParagraph1(id);
        }
        public string GetParagraph2(int id)
        {
            ResultsDO res = new ResultsDO();
            return res.GetParagraph2(id);
        }


        public string GetPhoto1(int id)
        {
            ResultsDO res = new ResultsDO();
            return res.GetPhoto1(id);
        }

        public string GetPhoto2(int id)
        {
            ResultsDO res = new ResultsDO();
            return res.GetPhoto2(id);
        }

        public Dictionary<string, int> GetCategoryPoints(int id_question, int answer_num)
        {
            AnswersDO que = new AnswersDO();
            return que.GetCategoryPoints(id_question, answer_num);

        }

        public List<string> GetAnswers(int id)
        {
            AnswersDO que = new AnswersDO();
            return que.GetAnswers(id);
        }

        public string GetQuestion(int id)
        {
            QuestionDO que = new QuestionDO();
            return que.GetQuestion(id);
        }

        public void AddNewReminder(Reminder_st rem)
        {

            ReminderDO reminder = new ReminderDO();
            reminder.AddNewReminder(rem);

        }

        public List<Reminder_st> GetReminders()
        {
            List<Reminder_st> reminders = new List<Reminder_st>();

            ReminderDO reminder = new ReminderDO();
            
            foreach(var i in reminder.GetIds())
            {
                reminders.Add(reminder.GetReminder(i));

            }
            
            return reminders;
        }

        public void DeleteReminders()
        {
            ReminderDO reminder = new ReminderDO();
            reminder.Delete();
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


        public void AddDefaultProfile()
        {
            ProfileDO profile = new ProfileDO();
            profile.AddNewProfile("Enter full name", "Enter profile name", "Enter breed", "Enter color", false, new DateTime(2015, 7, 20), "C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/Photos/default_photo.png");
        }

        public void UpdateProfile(int id, string full_name, string profile_name, string breed, string color, bool sex, System.DateTime birth_date)
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
