

using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // The application should only accept product names in this format: LETTERS-NUMBER between 200 and 500

        if (Regex.IsMatch(userInput, @"^[A-Z]+-([2-4][0-9]{2}|500)$")) // Valid product name
        {
            products.Add(userInput);
            continue;
        }

        // Error handling: collect and show all product name format errors, not just the first one
        List<string> errors = new List<string>();

        if (!Regex.IsMatch(userInput, "-")) // No dash
        {
            errors.Add("Product must contain a dash (-).");
        }
        else
        {
            if (Regex.IsMatch(userInput, @"^[^-]*[a-z]")) // Lowercase letter on the left side
            {
                errors.Add("The left side must contain capitalized letters only.");
            }

            if (!Regex.IsMatch(userInput, @"^[A-Za-z]+-")) // Non-letter on the left side
            {
                errors.Add("The left side must contain letters only.");
            }

            if (!Regex.IsMatch(userInput, @"-[0-9]+$")) // Right side is not only digits
            {
                errors.Add("The right side must contain numbers only.");
            }
            else if (!Regex.IsMatch(userInput, @"-([2-4][0-9]{2}|500)$")) // Number out of range
            {
                errors.Add("The numeric part must be between 200 and 500.");
            }
        }

        if (errors.Count == 0) // Unexpected invalid product name
        {
            errors.Add("Product name is invalid.");
        }

        Console.ForegroundColor = ConsoleColor.Red;
        foreach (string error in errors)
        {
            Console.WriteLine($"ERROR: {error}");
        }
        Console.ResetColor();
        continue;



    }
    return products;
}
