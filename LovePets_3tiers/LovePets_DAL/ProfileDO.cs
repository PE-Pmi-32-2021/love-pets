namespace LovePets_DAL
{
    using System.Linq;
    using LovePets_EF;

    public class ProfileDO
    {
        public ProfileDO()
        {
        }

        public int GetProfileCount()
        {
            Database1Entities1 ne = new Database1Entities1();
            return ne.Profiles.Count();
        }

        public void AddNewProfile(string full_name, string profile_name, string breed, string color, bool sex, System.DateTime birth_date, string photo_link)
        {
            Database1Entities1 ne = new Database1Entities1();

            Profile profile = new Profile { ProfileFullname = full_name, ProfileName = profile_name, Breed = breed, Coloring = color, Age = System.DateTime.Now.Year - birth_date.Year, BirthDate = birth_date, Gender = sex, Photolink = photo_link };
            ne.Profiles.Add(profile);
            ne.SaveChanges();
        }

        public void UpdateProfileName(int id, string full_name, string profile_name, string breed, string color, bool sex, System.DateTime birth_date)
        {
            Database1Entities1 ne = new Database1Entities1();
            Profile profile = ne.Profiles.Where(u => u.ID == id).First();
            profile.ProfileFullname = full_name;
            profile.ProfileName = profile_name;
            profile.Breed = breed;
            profile.Coloring = color;
            profile.BirthDate = birth_date;
            profile.Age = System.DateTime.Now.Year - birth_date.Year;
            profile.Gender = sex;
            ne.SaveChanges();
        }

        public void SaveAnimalPhoto(string photo_url, int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            Profile profile = ne.Profiles.Where(u => u.ID == id).First();
            profile.Photolink = photo_url;
            ne.SaveChanges();
        }

        public string GetAnimalPhoto(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<string> profile = (from u in ne.Profiles
                                                               where u.ID == id
                                                               select u.Photolink).ToList();

            return profile[0];
        }

        public string GetProfileFullName(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<string> profile = (from u in ne.Profiles
                                                               where u.ID == id
                                                               select u.ProfileFullname).ToList();

            return profile[0];
        }

        public string GetProfileName(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<string> profile = (from u in ne.Profiles
                                                               where u.ID == id
                                                               select u.ProfileName).ToList();

            return profile[0];
        }

        public string GetBreed(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<string> profile = (from u in ne.Profiles
                                                               where u.ID == id
                                                               select u.Breed).ToList();

            return profile[0];
        }

        public string GetColoring(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<string> profile = (from u in ne.Profiles
                                                               where u.ID == id
                                                               select u.Coloring).ToList();

            return profile[0];
        }

        public System.DateTime GetBirthdate(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<System.DateTime> profile = (from u in ne.Profiles
                                                                        where u.ID == id
                                                                        select u.BirthDate).ToList();

            return profile[0];
        }

        public bool GetSex(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<bool> profile = (from u in ne.Profiles
                                                             where u.ID == id
                                                             select u.Gender).ToList();

            return profile[0];
        }

        public int GetAge(int id)
        {
            Database1Entities1 ne = new Database1Entities1();
            System.Collections.Generic.List<int> profile = (from u in ne.Profiles
                                                            where u.ID == id
                                                            select u.Age).ToList();

            return profile[0];
        }
    }
}
