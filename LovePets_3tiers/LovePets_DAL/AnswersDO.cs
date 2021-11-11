using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LovePets_EF;

namespace LovePets_DAL
{
    public class AnswersDO
    {
        public List<string> GetAnswers(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var answers = (from u in ne.Answers
                           where u.QuestionsID == id
                           select u.Answer1).ToList();

            return answers;
        }


        public Dictionary<string, int> GetCategoryPoints(int id_question, int answer_num)
        {
            Database1Entities1 ne = new Database1Entities1();
            var dogs = (from u in ne.Answers
                           where u.QuestionsID == id_question
                           select u.Dogs).ToList()[answer_num];
            var cats = (from u in ne.Answers
                        where u.QuestionsID == id_question
                        select u.Cats).ToList()[answer_num];

            var rodents = (from u in ne.Answers
                        where u.QuestionsID == id_question
                        select u.Rodents).ToList()[answer_num];

            var rep = (from u in ne.Answers
                        where u.QuestionsID == id_question
                        select u.Reptiles).ToList()[answer_num];

            var birds = (from u in ne.Answers
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
