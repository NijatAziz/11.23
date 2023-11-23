using System;
using System.Data.SqlClient;

string connectionString = "Data Source=NIJATAZIZ\\SQLEXPRESS;Initial Catalog=SHOOP;Integrated Security=True";
SqlConnection connection = new SqlConnection(connectionString);

Console.WriteLine("1. Create");
Console.WriteLine("2. ShowAll");
Console.WriteLine("0. Close");
string Request = Console.ReadLine();

while (Request != "0")
{
    switch (Request)
    {
        case "1":
            CreateProduct(connection);
            break;
        case "2":
            GetAllProducts(connection);
            break;
        case "3":
            Updatee(connection);
            break;
        case "4":
            Remove(connection);
            break;



        default:
            Console.WriteLine("Add valid option");
            break;

    }

    Console.WriteLine("1. Create");
    Console.WriteLine("2. ShowAll");
    Console.WriteLine("0. Close");
    Request = Console.ReadLine();
}

static void GetAllProducts(SqlConnection connection)
{
    try
    {
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);

        SqlDataReader result = command.ExecuteReader();

        while (result.Read())
        {
            Console.WriteLine($"Id: {result[0]} [Name]: {result[1]} Price: {result[2]}");
        }

        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Xeta: {ex.Message}");
    }
    finally
    {
        connection.Close();
    }
}


static void CreateProduct(SqlConnection connection)
{
    Console.WriteLine("Add Id");
    int id = int.Parse( Console.ReadLine() );

    Console.WriteLine("Add Name");
    string name = (Console.ReadLine());

    Console.WriteLine("Add Price");
    float price = float.Parse(Console.ReadLine());

    try
    {
        connection.Open();

        SqlCommand command = new SqlCommand($"INSERT INTO Products VALUES ({id}, '{name}' '{price}', );", connection);

        SqlDataReader result = command.ExecuteReader();

        while (result.Read())
        {
            Console.WriteLine($"Id: {result[0]} [Name]: {result[1]} Price: {result[2]}");
        }

        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Xeta: {ex.Message}");
    }
    finally
    {
        connection.Close();
    }
}



static void Updatee(SqlConnection connection)
{
    Console.WriteLine("Enter the ID of the product you want to update:");
    int id = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the new name:");
    string newName = Console.ReadLine();

    Console.WriteLine("Enter the new price:");
    float newPrice = float.Parse(Console.ReadLine());

    try
    {
        connection.Open();

        SqlCommand command = new SqlCommand($"UPDATE Products SET [Name] = '{newName}', Price = {newPrice} WHERE ID = {id}", connection);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found with the specified ID.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    finally
    {
        connection.Close();
    }
}

static void Remove(SqlConnection connection)
{
    Console.WriteLine("Enter the ID of the product you want to remove:");
    int id = int.Parse(Console.ReadLine());

    try
    {
        connection.Open();

        SqlCommand command = new SqlCommand($"DELETE FROM Products WHERE ID = {id}", connection);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            Console.WriteLine("Product not found with the specified ID.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    finally
    {
        connection.Close();
    }
}
