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
