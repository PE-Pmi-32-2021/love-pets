using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LovePets_DAL;
using LovePets_EF;

namespace LovePets_BLL
{
    public class LovePetsBLL
    {
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

    }
}
