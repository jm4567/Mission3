namespace Mission3;
internal class Program
{
    public static void Main(string[] args)
    {
        List<FoodItem> foodItems = new List<FoodItem>();

        Console.WriteLine("Welcome to the Food Bank Inventory System: What would you like to do? ");

        string choice = "";
        //error handling with the do while loop 
        do
        {
            Console.WriteLine("Option 1: Add food item");
            Console.WriteLine("Option 2: Delete food items");
            Console.WriteLine("Option 3: Print current list of food items");
            Console.WriteLine("Option 4: Exit the program");
            Console.WriteLine("Enter your choice (1-4):");

            choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("You chose option 1");
                AddFoodItem(foodItems);
            }

            else if (choice == "2")
            {
                Console.WriteLine("You chose option 2");
                DeleteFoodItem(foodItems);
            }
            else if (choice == "3")
            {
                Console.WriteLine("You chose option 3");
                PrintFoodItem(foodItems);
            }
            else if (choice == "4")
            {
                Console.WriteLine("Exited the program sucessfully");
                Environment.Exit(0);  // Exits with code 0 (successful execution)
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }

        } while (choice != "4");
    }
    public static void AddFoodItem(List<FoodItem> foodItems)
    {
        //food name
        Console.WriteLine("Enter food item name: ");
        string name = Console.ReadLine();
        //loop until user enters a valid name
        while (string.IsNullOrEmpty(name) || !IsValidString(name))
        {
            Console.WriteLine("Invalid name, please try again. Please enter letters only.");
            name = Console.ReadLine();
            
        }
        
        //category. 
        Console.WriteLine("Enter food item category: ");
        string category = Console.ReadLine();

        // Loop until the user enters a valid category
        while (string.IsNullOrWhiteSpace(category) || !IsValidString(category))
        {
            Console.WriteLine("Invalid category. Please enter a valid string (letters only).");
            category = Console.ReadLine();
        }
   
        // Quantity input and validation
        Console.WriteLine("Enter food item quantity: ");
        string quantityInput = Console.ReadLine();
        int quantity;
        while (!int.TryParse(quantityInput, out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity, please enter a positive number greater than 0.");
            quantityInput = Console.ReadLine();
        }

        // Expiration date input and validation
        Console.WriteLine("Enter food item expiration date (MM/dd/yyyy): ");
        string input = Console.ReadLine();
        DateTime expirationDate;

        while (!DateTime.TryParse(input, out expirationDate) ||expirationDate == DateTime.MinValue|| expirationDate < DateTime.Now)
        {
            Console.WriteLine("Invalid expiration date. Please enter a valid future date.");
            input = Console.ReadLine();
        }
        
        var foodItem = new FoodItem(name, category, quantity, expirationDate);
        foodItems.Add(foodItem);
   
        Console.WriteLine("Food item added successfully.");
        Console.WriteLine();
    }
    public static void DeleteFoodItem(List<FoodItem>foodItems)
    {
        if (foodItems.Count == 0)
        {
            Console.WriteLine("No food items available to delete.");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("Current Food Items:");
        int index = 1;
        foreach(var fooditem in foodItems)
        {
            Console.WriteLine($"{index}: {fooditem}");
            index++;
        }
        //break 
        Console.WriteLine();
        
        Console.WriteLine("What would you like to delete? (choose which number)");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > foodItems.Count)
        {
            Console.WriteLine("Invalid choice, please try again.");
            Console.WriteLine();
            return;
        }

        
        foodItems.RemoveAt(choice - 1);
        Console.WriteLine("Food item deleted successfully.");
        Console.WriteLine();
    }
    public static void PrintFoodItem(List<FoodItem> foodItems)
    { 
        if (foodItems.Count == 0)
        {
            Console.WriteLine("No food items available");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("Current Food Items:");
        int index = 1;
        foreach(var fooditem in foodItems)
        {
            Console.WriteLine($"{index}: {fooditem}");
            index++;
        }
        //break
        Console.WriteLine();
    }
    
    // Helper method to validate strings
    public static bool IsValidString(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }
}