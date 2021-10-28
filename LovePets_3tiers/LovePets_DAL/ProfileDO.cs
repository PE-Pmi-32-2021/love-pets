using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LovePets_EF;

namespace LovePets_DAL
{
    public class ProfileDO
    {
        public ProfileDO()
        {

        }

        public void SaveAnimalPhoto(string photo_url, int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var profile = (from u in ne.Profiles
                          where u.ID == id
                          select u.Photolink).ToList();

            profile[0] = photo_url;

            ne.SaveChanges();
          
        }


        public string GetAnimalPhoto(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            var profile = (from u in ne.Profiles
                           where u.ID == id
                           select u.Photolink).ToString();

            return profile;
        }




    }
}
