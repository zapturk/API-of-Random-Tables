namespace RandomTableApi;

public class RandomTableDAL(){
    
    public Item GetRandomName()
    {
        string query = @"
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
                ORDER BY RANDOM() LIMIT 1;
            ";
        List<Item> items = DBConnection.ExecuteQuery(query, reader =>
        {
            Item item = new Item();
            item.Name = reader.GetString(reader.GetOrdinal("Name"));
            item.Rarity = reader.GetString(reader.GetOrdinal("Rarity"));
            item.Type = reader.GetString(reader.GetOrdinal("Type"));
            item.Value = reader.GetString(reader.GetOrdinal("Value"));
            item.Attunement = reader.GetBoolean(reader.GetOrdinal("Attunement"));
            item.Description = reader.GetString(reader.GetOrdinal("Description"));
            item.Location = reader.GetString(reader.GetOrdinal("Location"));
            item.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));

            return item;
        });
        
        Item randomItem = new Item()
        {
            Name = items[0].Name,
            Rarity = items[0].Rarity,
            Type = items[0].Type,
            Value = items[0].Value,
            Attunement = items[0].Attunement,
            Description = items[0].Description,
            Location = items[0].Location,
            Quantity = rollNumber(items[0].Quantity)
        };
        
        return randomItem;
    }

    public string rollNumber(string dice)
    {
        if (!dice.Contains("d"))
        {
            return dice;
        }
        
        Random random = new Random();
        int numberOfDice = Convert.ToInt32(dice.Substring(0, dice.IndexOf("d")));
        int maxNumber = Convert.ToInt32(dice.Substring(dice.IndexOf("d") + 1));
        int value = 0;

        for (int i = 0; i < numberOfDice; i++)
        {
            value += random.Next(1, maxNumber);
        }
        
        return value.ToString();
    }
}
