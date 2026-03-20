using System;
using Microsoft.Data.SqlClient;

namespace myAdoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
            "data source=.; database=Sample; integrated security=SSPI; TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tblProduct", con);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(
                        rdr["ProductId"] + " " +
                        rdr["ProductName"] + " " +
                        rdr["Price"]);
                }
            }

            Console.ReadLine();
        }
    }
}
