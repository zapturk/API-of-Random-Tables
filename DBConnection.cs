using System.Reflection;
using Microsoft.Data.Sqlite;

namespace RandomTableApi;

public static class DBConnection
{
    private static string ConnectionString = "Data Source=db/RandomTable.db";
    
    public static List<T> ExecuteQuery<T>(string query, Func<SqliteDataReader, T> mapFunction)
    {
        List<T> resultList = new List<T>();

        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultList.Add(mapFunction(reader));
                    }
                }
            }
            
            connection.Close();
        }

        return resultList;
    }
}
