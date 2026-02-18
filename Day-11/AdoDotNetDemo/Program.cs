// // Microsoft SQL Server

// using System;
// using System.Data;
// using System.IO;
// using Microsoft.Data.SqlClient;
// using Microsoft.Extensions.Configuration;

// // mySQL
// // using MySql.Data.SqlClient;

// // // create console application builder
// var builder = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json");

// // Connection
// // var connectionString = builder.GetConnectionString("CrmDbConnection");
// var connectionString = builder.Build().GetConnectionString("CrmDb");

// // for disposing connection object
// //using (var connection = new SqlConnection(connectionString))
// //{
// //}

// using var connection = new SqlConnection(connectionString);



// try
// {
//     connection.Open();
//     Console.WriteLine("Connection opened successfully.");
//     // Execute Reader
//     // ExecuteReader(connection);

//     // Execute NonQuery
//     // ExecuteNonQuery(connection);

//     // Execute Scalar
//     // ExecuteScalar(connection);

//     // SQL Data Adapater
//     // SqlDataAdapeterDemo(connection);

//     // Insert Customer Demo
//     // InsertCustomerDemo(connection);

//     // SQL Injection Demo
//     // SqlInjectionDemo(connection);

//     // Parameterized Query Demo
//     ParameterizedQueryDemo(connection);
// }
// catch (Exception ex)
// {
//     Console.WriteLine(ex.Message);
//     return;
// }
// finally
// {
//     connection.Close();
// }

// void ParameterizedQueryDemo(SqlConnection connection)
// {
//     using (SqlCommand command = new SqlCommand(
//         "SELECT * FROM Customers WHERE Name LIKE @Name",
//         connection))

//     {
//         // var id = "3";
//         // var id = "3 or 1 = 1";
//         // var id = "3 or 1 = 1";
//         // Add parameters - database treats them as DATA, never as SQL code
//         var name = "John or 1 = 1";
//         command.Parameters.AddWithValue("@Name", name);

//         using SqlDataReader reader = command.ExecuteReader();
//         if (reader.Read())
//         {
//             Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
//         }
//         else
//         {
//             Console.WriteLine("No customer found with the specified Id.");
//         }
//     }
// }

// void SqlInjectionDemo(SqlConnection connection)
// {
//     // Query: SELECT * FROM Customers WHERE Id = 1 or 1 = 1
//     var userInput = "1 or 1 = 1";
//     // var userInput = "1; DROP TABLE Customers; ";
//     // var userInput = "3";
//     var query = $"SELECT * FROM Customers WHERE Id = {userInput}";

//     using var command = new SqlCommand(query, connection);
//     try
//     {
//         using var reader = command.ExecuteReader();
//         while (reader.Read())
//         {
//             Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
//         }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Error executing query: {ex.Message}");
//     }
// }

// void InsertCustomerDemo(SqlConnection connection)
// {
//     var dataSet = new DataSet();
//     var selectQuery = "SELECT * FROM Customers";
//     using var selectCommand = new SqlCommand(selectQuery, connection);
//     using var adapter = new SqlDataAdapter(selectCommand);
//     adapter.Fill(dataSet, "Customers");

//     var dataTable = dataSet.Tables["Customers"];

//     var newRow = dataTable.NewRow();
//     newRow["Id"] = 2;
//     newRow["Name"] = "New Customer";
//     newRow["Age"] = 28;

//     dataTable.Rows.Add(newRow);

//     adapter.InsertCommand = new SqlCommand("INSERT INTO Customers (Id, Name, Age) VALUES (@Id, @Name, @Age)", connection)
//     {
//         CommandType = CommandType.Text
//     };

//     adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 6, "Id");
//     adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
//     adapter.InsertCommand.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");

//     adapter.Update(dataSet, "Customers");

//     dataSet.AcceptChanges();
// }


// void SqlDataAdapeterDemo(SqlConnection connection)
// {
//     var query = "SELECT * FROM Customers";
//     SqlCommand sqlCommand = new(query, connection);
//     using var selectAllCustomersCommand = sqlCommand;
//     using var adapter = new SqlDataAdapter(selectAllCustomersCommand);
//     var customerDataTable = new DataTable();

//     adapter.Fill(customerDataTable);

//     foreach (DataRow row in customerDataTable.Rows)
//     {
//         Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}");
//     }
// }

// void ExecuteScalar(SqlConnection connection)
// {
//     var query = "SELECT COUNT(*) FROM Customers";
//     using var command = new SqlCommand(query, connection);
//     var count = (int)command.ExecuteScalar();
//     Console.WriteLine($"Total customers: {count}");
// }

// void ExecuteReader(SqlConnection connection)
// {
//     var query = "SELECT * FROM Customers WHERE Age > 25";
//     using var command = new SqlCommand(query, connection);
//     using var reader = command.ExecuteReader();

//     while (reader.Read())
//     {
//         Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
//     }
// }

// void ExecuteNonQuery(SqlConnection connection)
// {
//     var query = "INSERT INTO Customers (Id, Name, Age) VALUES (1, 'Danny', 30)";
//     using var command = new SqlCommand(query, connection);
//     var rowsAffected = command.ExecuteNonQuery();
//     Console.WriteLine($"Rows affected: {rowsAffected}");
// }


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
