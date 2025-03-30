using System.Reflection;
using Microsoft.Data.Sqlite;

namespace RandomTableApi;

public static class DBConnection
{
    private static string ConnectionString = "Data Source=db/RandomTable.db";
    // public static List<T> GetDataFromDB<T>(){
    //     List<T> results = new List<T>();
    //     using (var connection = new SqliteConnection("Data Source=db/RandomTable.db"))
    //     {
    //         connection.Open();
    //
    //         var command = connection.CreateCommand();
    //         command.CommandText =
    //         @"
    //             SELECT 
    //                Name,
    //                Rarity,
    //                Type,
    //                Value,
    //                Attunement,
    //                Description,
    //                Location,
    //                Quantity
    //             FROM Item
    //         ";
    //

    //         using (SqliteDataReader reader = command.ExecuteReader())
    //         {
    //             while (reader.Read())
    //             {
    //                 T obj = new T();
    //                 Type type = typeof(T);
    //                 for (int i = 0; i < reader.FieldCount; i++)
    //                 {
    //                     string columnName = reader.GetName(i);
    //                     PropertyInfo property = type.GetProperty(columnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    //
    //                     if (property != null && property.CanWrite)
    //                     {
    //                         object value = reader.GetValue(i);
    //                         // Handle DBNull values
    //                         if (value != DBNull.Value)
    //                         {
    //                             //Convert the value to the property type.
    //                             object convertedValue = Convert.ChangeType(value, property.PropertyType);
    //                             property.SetValue(obj, convertedValue);
    //                         }
    //                     }
    //                 }
    //                 results.Add(obj);
    //             }
    //         }
    //     }
    //
    //     return results;
    // }
    
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
        }

        return resultList;
    }
}
