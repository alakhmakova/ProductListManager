

using ProductListManager;


ProductManager manager = new ProductManager();
List<string> userProducts = manager.AddProducts();
userProducts.Sort();//Sort the product list alphabetically before displaying it.

if ( userProducts.Count > 0 )
{
    Console.WriteLine($"\nProducts entered: \n");
    foreach (string product in userProducts)
    {
        Console.WriteLine($"- {product}");
    }
} else { 
    Console.WriteLine($"\nYour list is empty"); 
}

