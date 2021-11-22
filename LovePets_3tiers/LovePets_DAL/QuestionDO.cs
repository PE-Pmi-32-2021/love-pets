namespace LovePets_DAL
{
    using System.Linq;
    using LovePets_EF;

    public class QuestionDO
    {
        public string GetQuestion(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<string> que = (from u in ne.Questions
                                                           where u.ID == id
                                                           select u.Question1).ToList();

            return que[0];
        }

        public string GetQuestionPhoto(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<string> que = (from u in ne.Questions
                                                           where u.ID == id
                                                           select u.PhotoLink).ToList();

            return que[0];
        }
    }
}
