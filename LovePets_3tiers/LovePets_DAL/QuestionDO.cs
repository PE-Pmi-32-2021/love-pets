using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LovePets_EF;

namespace LovePets_DAL
{
    public class QuestionDO
    {

        public string GetQuestion(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var que = (from u in ne.Questions
                           where u.ID == id
                           select u.Question1).ToList();

            return que[0];
        }
    }
}
