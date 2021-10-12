using System;
using Npgsql;


namespace ApplicationForDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=postgres;Password=1234;Database=love_pets";
            var con = new NpgsqlConnection(cs);
            con.Open();

            Console.Read();
        }

    }
}
