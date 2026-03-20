using System;
using Microsoft.Data.SqlClient;

/// connect to db
// class ConnectToCrmDb
// {
//     static void Main()
//     {
//         string connectionString = @"Server=localhost;Database=CrmDb;Trusted_Connection=True;TrustServerCertificate=True;";
//         using SqlConnection con = new SqlConnection(connectionString);

//         try
//         {
//             con.Open();
//             Console.WriteLine("Connected Successfully!");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Connection Failed: " + ex.Message);
//         }
//     }
// }

/// InsertCustomer.cs – Insert a record

// using System;
// using Microsoft.Data.SqlClient;

// class InsertCustomer
// {
//     static void Main()
//     {
//         string connectionString = @"Server=localhost;Database=CrmDb;Trusted_Connection=True;TrustServerCertificate=True;";

//         using SqlConnection con = new SqlConnection(connectionString);
//         con.Open();

//         int newId = 5; // The Id you want to insert
//         string newName = "David";
//         int newAge = 28;

//         // 🔹 Check if the Id already exists
//         string checkQuery = "SELECT COUNT(*) FROM Customers WHERE Id=@Id";
//         using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
//         {
//             checkCmd.Parameters.AddWithValue("@Id", newId);
//             int exists = (int)checkCmd.ExecuteScalar();

//             if (exists == 0)
//             {
//                 // 🔹 Insert new record
//                 string insertQuery = "INSERT INTO Customers (Id, Name, Age) VALUES (@Id, @Name, @Age)";
//                 using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
//                 {
//                     insertCmd.Parameters.AddWithValue("@Id", newId);
//                     insertCmd.Parameters.AddWithValue("@Name", newName);
//                     insertCmd.Parameters.AddWithValue("@Age", newAge);

//                     int rows = insertCmd.ExecuteNonQuery();
//                     Console.WriteLine($"{rows} Record Inserted Successfully!\n");
//                 }
//             }
//             else
//             {
//                 Console.WriteLine($"Record with Id={newId} already exists. Skipping insert.\n");
//             }
//         }

//         // 🔹 Display all records after insertion
//         string selectQuery = "SELECT * FROM Customers";
//         using (SqlCommand selectCmd = new SqlCommand(selectQuery, con))
//         using (SqlDataReader reader = selectCmd.ExecuteReader())
//         {
//             Console.WriteLine("ID  | Name       | Age");
//             Console.WriteLine("-----------------------");

//             while (reader.Read())
//             {
//                 Console.WriteLine($"{reader["Id"],-3} | {reader["Name"],-10} | {reader["Age"],-3}");
//             }
//         }
//     }
// }


/// UpdateCustomer.cs – Update a record

// using System;
// using Microsoft.Data.SqlClient;

// class UpdateCustomer
// {
//     static void Main()
//     {
//         string connectionString =
//         @"Server=localhost;Database=CrmDb;Trusted_Connection=True;TrustServerCertificate=True;";

//         using SqlConnection con = new SqlConnection(connectionString);
//         con.Open();

//         int idToUpdate = 2;
//         int newAge = 50;   // 👈 change to something very different

//         Console.WriteLine("BEFORE UPDATE:");
//         DisplayCustomer(con, idToUpdate);

//         // 🔹 UPDATE
//         string updateQuery = "UPDATE Customers SET Age=@Age WHERE Id=@Id";

//         using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
//         {
//             updateCmd.Parameters.AddWithValue("@Age", newAge);
//             updateCmd.Parameters.AddWithValue("@Id", idToUpdate);

//             int rows = updateCmd.ExecuteNonQuery();
//             Console.WriteLine($"\n{rows} Record Updated Successfully!\n");
//         }

//         Console.WriteLine("AFTER UPDATE:");
//         DisplayCustomer(con, idToUpdate);
//     }

//     static void DisplayCustomer(SqlConnection con, int id)
//     {
//         string query = "SELECT * FROM Customers WHERE Id=@Id";

//         using SqlCommand cmd = new SqlCommand(query, con);
//         cmd.Parameters.AddWithValue("@Id", id);

//         using SqlDataReader reader = cmd.ExecuteReader();

//         if (reader.Read())
//         {
//             Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
//         }
//         else
//         {
//             Console.WriteLine("Record not found.");
//         }
//     }
// }


//CountCustomers.cs – Count total records

// using System;
// using System.Data.SqlClient;

// class CountCustomers
// {
//     static void Main()
//     {
//         string connectionString = @"Server=localhost;Database=CrmDb;Trusted_Connection=True;TrustServerCertificate=True;";

//         using SqlConnection con = new SqlConnection(connectionString);
//         con.Open();

//         string query = "SELECT COUNT(*) FROM Customers";
//         using SqlCommand cmd = new SqlCommand(query, con);

//         int count = (int)cmd.ExecuteScalar();
//         Console.WriteLine("Total Customers: " + count);
//     }
// }


// SearchCustomerById.cs – Search record by ID (parameterized)

// using System;
// using System.Data.SqlClient;

// class SearchCustomerById
// {
//     static void Main()
//     {
//         string connectionString = @"Server=localhost;Database=CrmDb;Trusted_Connection=True;TrustServerCertificate=True;";

//         using SqlConnection con = new SqlConnection(connectionString);
//         con.Open();

//         Console.Write("Enter Customer Id: ");
//         int id = int.Parse(Console.ReadLine());

//         string query = "SELECT * FROM Customers WHERE Id=@Id";
//         using SqlCommand cmd = new SqlCommand(query, con);
//         cmd.Parameters.AddWithValue("@Id", id);

//         using SqlDataReader reader = cmd.ExecuteReader();

//         Console.WriteLine("\n-------------------------------");
//         Console.WriteLine("| ID  | Name       | Age      |");
//         Console.WriteLine("-------------------------------");

//         if (reader.Read())
//         {
//             Console.WriteLine($"| {reader["Id"],-3} | {reader["Name"],-10} | {reader["Age"],-8} |");
//         }
//         else
//         {
//             Console.WriteLine("| No matching record found.     |");
//         }
//         Console.WriteLine("-------------------------------");
//     }
// }

// SQL Injection
using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
        @"Server=localhost;
          Database=CrmDb;
          Trusted_Connection=True;
          TrustServerCertificate=True;";

        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Connected Successfully!\n");

            Console.WriteLine("1. SQL Injection Demo (Unsafe)");
            Console.WriteLine("2. Safe Parameterized Query");
            Console.Write("\nChoose Option (1 or 2): ");

            string choice = Console.ReadLine();

            if (choice == "1")
                SqlInjectionDemo(connection);
            else if (choice == "2")
                SafeQueryDemo(connection);
            else
                Console.WriteLine("Invalid Choice!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // 🚨 UNSAFE VERSION
    static void SqlInjectionDemo(SqlConnection connection)
    {
        Console.Write("\nEnter Customer Id: ");
        string userInput = Console.ReadLine();

        // ❌ Vulnerable query
        string query = $"SELECT * FROM Customers WHERE Id = {userInput}";

        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = command.ExecuteReader();

        DisplayTable(reader);
    }

    // ✅ SAFE VERSION
    static void SafeQueryDemo(SqlConnection connection)
    {
        Console.Write("\nEnter Customer Id: ");
        string userInput = Console.ReadLine();

        string query = "SELECT * FROM Customers WHERE Id = @Id";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", userInput);

        using SqlDataReader reader = command.ExecuteReader();

        DisplayTable(reader);
    }

    // 🔹 DISPLAY METHOD
    static void DisplayTable(SqlDataReader reader)
    {
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("| ID  | Name       | Age      |");
        Console.WriteLine("-------------------------------");

        bool found = false;

        while (reader.Read())
        {
            found = true;

            Console.WriteLine(
                $"| {reader["Id"],-3} " +
                $"| {reader["Name"],-10} " +
                $"| {reader["Age"],-8} |"
            );
        }

        if (!found)
        {
            Console.WriteLine("| No matching record found.     |");
        }

        Console.WriteLine("-------------------------------");
    }
}
