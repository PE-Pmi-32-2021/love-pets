namespace LovePets_BLL
{
    using System;
    using System.Collections.Generic;
    using LovePets_DAL;
    using LovePets_Shared;

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

        public string GetQuestionPhoto(int id)
        {
            QuestionDO que = new QuestionDO();
            return que.GetQuestionPhoto(id);
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

            foreach (int i in reminder.GetIds())
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
            profile.AddNewProfile("Введіть повне ім'я", "Введіть кличку", "Введіть породу", "Введіть окрас", false, new DateTime(2015, 7, 20), "C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/Photos/default_photo.png");
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

        public void UpdateResults(Dictionary<string, int> results, int current_question, int questionID)
        {
            Dictionary<string, int> categ_dict = this.GetCategoryPoints(current_question, questionID);
            results["dogs"] += categ_dict["dogs"];
            results["cats"] += categ_dict["cats"];
            results["rodents"] += categ_dict["rodents"];
            results["reptiles"] += categ_dict["reptiles"];
            results["birds"] += categ_dict["birds"];
        }

        public int ChosenAnimal(Dictionary<string, int> result)
        {
            int index;
            int masx = 0;
            string max_res = string.Empty;
            foreach (KeyValuePair<string, int> keyValue in result)
            {
                if (keyValue.Value > masx)
                {
                    masx = keyValue.Value;
                    max_res = keyValue.Key;
                }
            }

            if (max_res == "dogs")
            {
                index = 1;
            }
            else if (max_res == "cats")
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

            return index;
        }
    }
}
