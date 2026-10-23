

List<string> userProducts = AddProducts();
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
        //Console.ResetColor();
        Console.Write("Product: ");
        string userInput = Console.ReadLine().Trim();


        if (userInput.ToLower() == "exit")
        {
            Console.WriteLine($"\nProducts entered: \n");
            break;
        }

        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Products name can't be empty");
            Console.ResetColor();
            continue;
        }
        
        products.Add(userInput);
        

    }
    return products;
}
