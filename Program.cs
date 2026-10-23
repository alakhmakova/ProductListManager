

using ProductListManager;

List<string> products = new List<string>(); //create an empty list - продукты исчезают при повторном выборе 1
ProductManager manager = new ProductManager();
ConsoleInput userInput = new ConsoleInput();
bool runMenu = true;
while (runMenu)
{ 

//Ask user to choose menu option 
Console.WriteLine("\nSelect option 1-5. Type 0 to exit:\r\n\n1. Add Product\r\n2. View Products\r\n3. Search Product\r\n4. Delete Product\r\n5. Save products to the file\r\n0. Exit");
string input = userInput.ReadNonEmpty("Select option: ", "Menu option can't be empty.");

// Without this check, any non-number (e.g. "abc") would become 0 and close the program.
if (!int.TryParse(input, out int option))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Menu option must be a number.");
    Console.ResetColor();
    continue;
}


    switch (option)
    {
        case 1:
            Console.WriteLine("Enter product names. \nType 'exit' to finish.\n");
            products = manager.AddProducts(products);
            break;

        case 2:
            manager.ViewProducts(products);
            break;

        case 3:
            string productNameOrNumber = userInput.ReadNonEmpty("Search products by name (ABC) or product number (200-500): ", "Search can't be empty.");
            manager.SearchProducts(products, productNameOrNumber);
            break;
        case 4:
            string productName = userInput.ReadNonEmpty("Product to delete: ", "Product name can't be empty.");
            manager.DeleteProduct(products, productName);
            break;
        case 5:
            Console.WriteLine($"Save products to the file");
            break;
        case 0:
            Console.WriteLine("Application closed.");
            runMenu = false;
        break;
        default:
            Console.WriteLine($"Wrong menu option.");
            break;
    }
}