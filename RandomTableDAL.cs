namespace RandomTableApi;

public class RandomTableDAL(){
    
    public List<Item> GetMaleName()
    {
        string query =              @"
                SELECT 
                   Name,
                   Rarity,
                   Type,
                   Value,
                   Attunement,
                   Description,
                   Location,
                   Quantity
                FROM Item
            ";
        List<Item> items = DBConnection.ExecuteQuery(query, );
        return items;
    }
}

