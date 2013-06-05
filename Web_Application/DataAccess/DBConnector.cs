using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DBConnector
    {
        private SqlConnection connection;

        public void openConnection()
        {
            connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=TempDB_1;Integrated Security=True;Encrypt=False;TrustServerCertificate=False");
            connection.Open();
        }

        public void closeConnection()
        {
            connection.Close();
        }

        public SqlDataReader executeQuery(string command)
        {
            openConnection();

            SqlCommand sc = new SqlCommand(command, connection);
            SqlDataReader test = sc.ExecuteReader();

            return test;
        }
    }
}
