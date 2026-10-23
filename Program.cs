

List<string> userProducts = AddProducts();
userProducts.Sort();//Sort the product list alphabetically before displaying it.
foreach (string product in userProducts)
{
    Console.WriteLine($"- {product}");
}

List<string> AddProducts()
{
    Console.WriteLine("Enter product names. \nType 'exit' to finish.\n");
    List<string> products = new List<string>();
    while (true)

    {
        Console.Write("Product: ");
        // If ReadLine() returns null, use "" instead; otherwise trim leading and trailing spaces.
        string userInput = Console.ReadLine()?.Trim() ?? ""; 

        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Products name can't be empty");
            Console.ResetColor();
            continue;
        }

        if (userInput.ToLower() == "exit")
        {
            Console.WriteLine($"\nProducts entered: \n");
            break;
        }
        
        products.Add(userInput);
        

    }
    return products;
}
