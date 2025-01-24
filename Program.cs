namespace Mission3;

using System;
using System.Collections.Generic; 

class Program
{
    // list to hold FoodItem objects
    static List<FoodItem> FoodItems = new List<FoodItem>();

    static void Main(string[] args)
    {
        bool running = true; // keeps the program running until the user exits

        // Main loop for the program
        while (running)
        {
            DisplayMenu(); 
            string choice = Console.ReadLine(); 

            switch (choice)
            {
                case "1":
                    AddFoodItem(); 
                    break;
                case "2":
                    DeleteFoodItem(); 
                    break;
                case "3":
                    PrintFoodItems(); 
                    break;
                case "4":
                    running = false; 
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Display the menu options to the user
    static void DisplayMenu()
    {
        Console.WriteLine("\nFood Bank Inventory System");
        Console.WriteLine("1. Add Food Item");
        Console.WriteLine("2. Delete Food Item");
        Console.WriteLine("3. Print List of Food Items");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
    }

    // add a food item to the list
    static void AddFoodItem()
    {
        Console.Write("Enter the name of the food item: ");
        string name = Console.ReadLine();

        Console.Write("Enter the category of the food item: ");
        string category = Console.ReadLine();

        int quantity;
        while (true)
        {
            Console.Write("Enter the quantity of the food item: ");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                break;
            else
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
        }

        DateTime expirationDate;
        while (true)
        {
            Console.Write("Enter the expiration date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out expirationDate))
                break;
            else
                Console.WriteLine("Invalid date format. Please try again.");
        }

        // Create a new FoodItem and add it to the list
        FoodItem item = new FoodItem(name, category, quantity, expirationDate);
        FoodItems.Add(item); // Add the FoodItem object to the list
        Console.WriteLine("Food item added successfully!");
    }

    // delete a food item from the list
    static void DeleteFoodItem()
    {
        Console.WriteLine("\nCurrent Food Items:");
        if (FoodItems.Count == 0)
        {
            Console.WriteLine("No items in the inventory to delete.");
            return;
        }

        // Print all items
        for (int i = 0; i < FoodItems.Count; i++)
        {
            FoodItem item = FoodItems[i];
            Console.WriteLine($"{i + 1}. {item.Name} ({item.Quantity} units, expires on {item.ExpirationDate.ToShortDateString()})");
        }

        int index;
        while (true)
        {
            Console.Write("Enter the number of the food item to delete: ");
            if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= FoodItems.Count)
                break;
            else
                Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        // Remove the selected item from the list
        FoodItems.RemoveAt(index - 1);
        Console.WriteLine("Food item deleted successfully!");
    }

    // rint all food items in the inventory
    static void PrintFoodItems()
    {
        Console.WriteLine("\nCurrent Food Items:");
        if (FoodItems.Count == 0)
        {
            Console.WriteLine("No items in the inventory.");
            return;
        }

        // Loop through the list and print each item
        foreach (FoodItem item in FoodItems)
        {
            Console.WriteLine($"{item.Name} - {item.Category} - {item.Quantity} units - Expires on {item.ExpirationDate.ToShortDateString()}");
        }
    }
}


   
