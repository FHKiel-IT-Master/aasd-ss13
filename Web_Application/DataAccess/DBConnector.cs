using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class DBConnector
    {
        private static SqlConnection connection;

        public static void openConnection()
        {
            connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=WebAppDB;Integrated Security=True;User ID=webappuser;Password=webappuser");
            connection.Open();
        }

        public static void closeConnection()
        {
            connection.Close();
        }

        public static SqlDataReader executeQuery(string command)
        {
            SqlCommand sc = new SqlCommand(command, connection);
            SqlDataReader test = sc.ExecuteReader();

            return test;
        }
    }
}
