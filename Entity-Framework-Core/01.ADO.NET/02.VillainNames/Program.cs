using Microsoft.Data.SqlClient;
using System;

namespace _02.VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True");

            connection.Open();

            var sqlCommand = new SqlCommand(Query.query, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            using (sqlDataReader)
            {
                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"{sqlDataReader["Name"]} - {sqlDataReader["Count"]}");
                }
            }
        }
        
    }
}
