using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace ScheduledTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString;
            string jsonFilePath = Path.Combine(GetSolutionDirectory().FullName, "Boekingssysteem\\appsettings.json");
            string jsonString = File.ReadAllText(jsonFilePath);

            string sqlQuery = "UPDATE BS.AspNetUsers" +
                " SET Status = NULL";

            JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
            JsonElement root = jsonDocument.RootElement;

            if (root.TryGetProperty("ConnectionStrings", out JsonElement prop))
            {
                connectionString = prop.GetProperty("LocalDBConnection").GetString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    connection.Open();

                    command.ExecuteScalar();

                    connection.Close();
                }
            }
        }

        static DirectoryInfo GetSolutionDirectory()
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directory != null && directory.GetFiles("*.sln").Length == 0)
            {
                directory = directory.Parent;
            }

            return directory;
        }
    }
}
