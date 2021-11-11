using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LovePets_EF;

namespace LovePets_DAL
{
    public class ResultsDO
    {
        public string GetTitle(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var res = (from u in ne.Results
                           where u.ID == id
                           select u.PhotoLink1).ToList();

            return res[0];
        }


        public string GetParagraph1(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var res = (from u in ne.Results
                       where u.ID == id
                           select u.Paragraph1).ToList();

            return res[0];
        }
        public string GetParagraph2(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var res = (from u in ne.Results
                       where u.ID == id
                           select u.Paragraph2).ToList();

            return res[0];
        }


        public string GetPhoto1(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var res = (from u in ne.Results
                       where u.ID == id
                           select u.PhotoLink2).ToList();

            return res[0];
        }

        public string GetPhoto2(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var res = (from u in ne.Results
                       where u.ID == id
                           select u.PhotoLink3).ToList();

            return res[0];
        }



    }
}
