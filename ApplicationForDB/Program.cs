using System;
using Npgsql;


namespace ApplicationForDB
{
    class Program
    {
        static void PrintAllTables(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand("SELECT * FROM  Results", con))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("Results: ");
                    while (rdr.Read())
                    {
                        Console.WriteLine("\t{0} {1} {2} {3} {4}", rdr.GetString(1), rdr.GetString(2),
                        rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
                    }
                }
            }



            using (var cmd = new NpgsqlCommand("SELECT * FROM  Questions", con))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nQuestions: ");
                    while (rdr.Read())
                    {
                        Console.WriteLine("\t{0} {1} {2}", rdr.GetString(1), rdr.GetBoolean(2), rdr.GetString(3));
                    }
                }
            }


            using (var cmd = new NpgsqlCommand("SELECT * FROM  Profile", con))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nProfile: ");
                    while (rdr.Read())
                    {
                        Console.WriteLine("\t{0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                            rdr.GetString(4), rdr.GetBoolean(5), rdr.GetDate(6), rdr.GetInt32(7), rdr.GetString(8));
                    }
                }
            }


            using (var cmd = new NpgsqlCommand("SELECT * FROM  Reminder", con))
            {
                Console.WriteLine("\nReminder: ");
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine("\t{0} {1} {2} {3}", rdr.GetTimeStamp(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4));
                    }
                }
            }


            using (var cmd = new NpgsqlCommand("SELECT * FROM  Categories", con))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nCategories: ");
                    while (rdr.Read())
                    {
                        Console.WriteLine("\t{0} {1} {2}", rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                    }
                }
            }

            using (var cmd = new NpgsqlCommand("SELECT * FROM  Information", con))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nInformation: ");
                    while (rdr.Read())
                    {
                        Console.WriteLine("\t{0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                            rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetInt32(8));
                    }
                }
            }

            using (var cmd = new NpgsqlCommand("SELECT * FROM  Answers", con))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nAnswers: ");
                    while (rdr.Read())
                    {

                        Console.WriteLine("\t{0} {1} {2} {3} {4} {5} {6}", rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3),
                           rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7));
                    }
                }
            }
        }

        static void GenerateRandDataProfile(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                for (int i = 0; i < 30; i++)
                {
                    cmd.CommandText = "INSERT INTO Profile(ProfileFullname, ProfileName, Breed, Coloring, Gender, BirthDate, Age, Photolink)" +
                        $" VALUES('ProfileFullname{i}', 'ProfileName{i}', 'Breed{i}', 'Coloring{i}',true,' 10/{i + 1}/{2000 + i}', {i}, 'Photolink{i}')";
                    cmd.ExecuteNonQuery();
                }

            }

        }


        static void GenerateRandReminder(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                for (int i = 0; i < 30; i++)
                {
                    cmd.CommandText = "INSERT INTO Reminder (RemindingDate, Reminding, ReminderType, ProfileID)" +
                        $" VALUES ('2021-11-08 22:05:06', 'Reminding{i}', 'feeding', {i + 1})";
                    cmd.ExecuteNonQuery();
                }

            }

        }


        static void GenerateRandCategories(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                for (int i = 0; i < 30; i++)
                {
                    cmd.CommandText = "INSERT INTO Categories (Category, Breed, PhotoLink)" +
                        $" VALUES ('Category{i}', 'Breed{i}', 'PhotoLink{i}')";
                    cmd.ExecuteNonQuery();
                }

            }

        }



        static void GenerateRandInformation(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                for (int i = 0; i < 30; i++)
                {
                    cmd.CommandText = "INSERT INTO Information (InGeneral, Nutrition, Care, Health, PhotoLink1, PhotoLink2, PhotoLink3, CategoriesID)" +
                        $" VALUES ('InGeneral{i}', 'Nutrition{i}', 'Care{i}',  'Health{i}', 'PhotoLink1{i}', 'PhotoLink2{i}', 'PhotoLink3{i}', {i + 1})";
                    cmd.ExecuteNonQuery();
                }

            }

        }

        static void GenerateRandQuestions(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                for (int i = 0; i < 30; i++)
                {
                    cmd.CommandText = "INSERT INTO Questions (Question, QuestionType, PhotoLink)" +
                        $" VALUES ('Question{i}', true, 'PhotoLink{i}')";
                    cmd.ExecuteNonQuery();
                }

            }

        }


        static void GenerateRandAnswers(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                for (int i = 0; i < 30; i++)
                {
                    cmd.CommandText = "INSERT INTO Answers (Answer, Dogs, Cats, Rodents, Reptiles, Birds, QuestionsID)" +
                        $" VALUES ('Answer{i}', {i}, {i},  {i}, {i}, {i}, {i + 1})";
                    cmd.ExecuteNonQuery();
                }

            }

        }


        static void GenerateRandResults(NpgsqlConnection con)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                for (int i = 0; i < 30; i++)
                {
                    cmd.CommandText = "INSERT INTO Results (Paragraph1, Paragraph2, PhotoLink1, PhotoLink2, PhotoLink3)" +
                        $" VALUES ('Paragraph1{i}', 'Paragraph2{i}', 'PhotoLink1{i}',  'PhotoLink2{i}', 'PhotoLink3{i}')";
                    cmd.ExecuteNonQuery();
                }

            }

        }

        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=postgres;Password=1234;Database=love_pets";
            var con = new NpgsqlConnection(cs);
            con.Open();
            //PrintAllTables(con);
            Console.Read();
        }

    }
}
