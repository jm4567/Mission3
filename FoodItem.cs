namespace Mission3;

public class FoodItem
{
    //defining the variables so they can be used in the constructor
    public string Name { get; private set; }
    public string Category { get; private set; }
    public int Quantity { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    // create a constructor
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than 0");
        }

        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate; 
    }

    //overriding method to make it a string to be printable 
    public override string ToString()
    {
        return $"{Name} | {Category} | {Quantity} units | Expiration: {ExpirationDate.ToShortDateString()}";
    }

}
