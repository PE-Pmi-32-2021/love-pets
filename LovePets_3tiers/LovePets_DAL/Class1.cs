using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LovePets_DAL
{
    public class Class1
    {
        static NpgsqlConnection Connect()
        {
            var cs = "Host=localhost;Username=postgres;Password=1234;Database=love_pets";
            var con = new NpgsqlConnection(cs);
            con.Open();

            return con;
        }
    }
}
