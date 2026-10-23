using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductListManager
{
    
        public class ProductManager
    {
        ConsoleInput userInput = new ConsoleInput();

        public List<string> AddProducts(List<string> products)
        {
            //Console.WriteLine("Enter product names. \nType 'exit' to finish.\n");
            
            while (true)

            {
                string validInput = userInput.ReadNonEmpty("Product: ", "Product name can't be empty.");

                if (validInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // The application should only accept product names in this format: LETTERS-NUMBER between 200 and 500

                if (products.Contains(validInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("WARNING: Product already exists.");
                    Console.ResetColor();
                    continue;
                }
                else if (Regex.IsMatch(validInput, @"^[A-Z]+-([2-4][0-9]{2}|500)$")) // Valid product name
                {
                    products.Add(validInput);
                    continue;
                }

                // Error handling: collect and show all product name format errors, not just the first one
                List<string> errors = new List<string>();

                if (!Regex.IsMatch(validInput, "-")) // No dash
                {
                    errors.Add("Product must contain a dash (-).");
                }
                else
                {
                    if (Regex.IsMatch(validInput, @"^[^-]*[a-z]")) // Lowercase letter on the left side
                    {
                        errors.Add("The left side must contain capitalized letters only.");
                    }

                    if (!Regex.IsMatch(validInput, @"^[A-Za-z]+-")) // Non-letter on the left side
                    {
                        errors.Add("The left side must contain letters only.");
                    }

                    if (!Regex.IsMatch(validInput, @"-[0-9]+$")) // Right side is not only digits
                    {
                        errors.Add("The right side must contain numbers only.");
                    }
                    else if (!Regex.IsMatch(validInput, @"-([2-4][0-9]{2}|500)$")) // Number out of range
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

        public void ViewProducts(List<string> products)
        {
            if (products.Count > 0)
            {
                products.Sort();//Sort the product list alphabetically before displaying it.        
                Console.WriteLine($"\nProducts entered: \n");
                foreach (string product in products)
                { 
                    Console.WriteLine($"- {product}"); 
                }    
                
            } else
            {
                Console.WriteLine($"Your list is empty");
            }
        }

        public void DeleteProduct(List<string> products, string productName)
        {
            // Remove() returns false if there is no such product in the list.
            if (products.Remove(productName))
            {
                Console.WriteLine($"Product {productName} was removed successfully");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARNING: Product {productName} was not found.");
                Console.ResetColor();
            }
        }

        public List<string> SearchProducts(List<string> products, string productName) 
        {
            List<string> found = products
            .Where(p => p.Contains(productName, StringComparison.OrdinalIgnoreCase)) // Case-insensitive search by partial product name using LINQ 
            .ToList();

            if (found.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.WriteLine("\nResults: \n");
                foreach (string p in found)
                {
                    Console.WriteLine(p);
                }
            }

            return found;
        }

        
        public void ShowStatistics(List<string> products)
        {
            if (products.Count > 0)
            {
                Console.WriteLine("\nStatistics: \n");
                Console.WriteLine($"- Total products: {products.Count}");
            } else {
                Console.WriteLine("Your list is empty");
                return;
            }

            List<int> numbers = products
                .Select(p => int.Parse(p.Split('-')[1])) // Take the number after the dash: "CE-400" → 400
                .ToList();

            Console.WriteLine($"- Highest product number: {numbers.Max()}");
            Console.WriteLine($"- Lowest product number: {numbers.Min()}");
            Console.WriteLine($"- Average product number: {numbers.Average():F1}"); // F1 = round to 1 decimal place: 366.666 → 366.7
        }

    }

    
}
