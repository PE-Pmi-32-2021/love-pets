namespace LovePets_DAL
{
    using System.Collections.Generic;
    using System.Linq;
    using LovePets_EF;

    public class AnswersDO
    {
        public List<string> GetAnswers(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            List<string> answers = (from u in ne.Answers
                                    where u.QuestionsID == id
                                    select u.Answer1).ToList();

            return answers;
        }

        public Dictionary<string, int> GetCategoryPoints(int id_question, int answer_num)
        {
            Database1Entities1 ne = new Database1Entities1();
            int dogs = (from u in ne.Answers
                        where u.QuestionsID == id_question
                        select u.Dogs).ToList()[answer_num];
            int cats = (from u in ne.Answers
                        where u.QuestionsID == id_question
                        select u.Cats).ToList()[answer_num];

            int rodents = (from u in ne.Answers
                           where u.QuestionsID == id_question
                           select u.Rodents).ToList()[answer_num];

            int rep = (from u in ne.Answers
                       where u.QuestionsID == id_question
                       select u.Reptiles).ToList()[answer_num];

            int birds = (from u in ne.Answers
                         where u.QuestionsID == id_question
                         select u.Birds).ToList()[answer_num];

            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                ["dogs"] = dogs,
                ["cats"] = cats,
                ["rodents"] = rodents,
                ["reptiles"] = rep,
                ["birds"] = birds
            };
            return dict;
        }
    }
}
