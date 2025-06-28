using StoreProjectApp.Database;
using StoreProjectApp.Exceptions;
using StoreProjectApp.Models;
using StoreProjectApp.Sevices;
using StoreProjectApp.Sevices.Abstract;

Product product1 = new Product
{
    Id = Guid.NewGuid(),
    Name = "Laptop",
    Price = 1200,
    Description = "A high-performance laptop for gaming and work."
};
Product product2 = new Product
{
    Id = Guid.NewGuid(),
    Name = "Smartphone",
    Price = 800,
    Description = "A latest model smartphone with advanced features."
};
Product product3 = new Product
{
    Id = Guid.NewGuid(),
    Name = "Headphones",
    Price = 200,
    Description = "Noise-cancelling over-ear headphones."
};
Product product4 = new Product
{
    Id = Guid.NewGuid(),
    Name = "Smartwatch",
    Price = 300,
    Description = "A smartwatch with fitness tracking features."
};


Order order = new Order
{
    Id = Guid.NewGuid(),
    Products = new List<Product> { product1, product2 },
    TotalPrice = 0
};
Order order2 = new Order
{
    Id = Guid.NewGuid(),
    Products = new List<Product> { product3, product4 },
    TotalPrice = 0
};


Customer customer = new Customer
{
    Id = Guid.NewGuid(),
    Name = "John",
    Surname = "Doe",
    Orders = new List<Order> { order, order2 }
};



StoreAppDatabase database = new StoreAppDatabase();
database.Products.Add(product1);
database.Products.Add(product2);
database.Products.Add(product3);
database.Products.Add(product4);
database.Customers.Add(customer);
database.Orders.Add(order);
database.Orders.Add(order2);


Console.WriteLine("Weleeecome StoreApp");
Console.WriteLine("1. Show all products");
Console.WriteLine("2. Add product");
Console.WriteLine("3. Update product");
Console.WriteLine("4. Delete product");
Console.WriteLine("5. Show all customers");
Console.WriteLine("6. Show all orders");
Console.WriteLine("7. Add order");
Console.WriteLine("8. Update order");
Console.WriteLine("9. Delete order");


IProductService productService = new ProductService(database);
IOrderService orderService = new OrderService(database);

while (true)
{
    Console.Write("Please select an option: ");
    string input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.WriteLine("All Products:");
            foreach (var product in database.Products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
            }
            break;
        case "2":
            try
            {
                Console.WriteLine("Add Product");
                Product product = new Product();
                Console.Write("Enter product name: ");
                product.Name = Console.ReadLine();
                Console.Write("Enter product price: ");
                string inputprice  = Console.ReadLine();
                if (!double.TryParse(inputprice, out double price) || price < 0)
                {
                    throw new InvalidPriceException();
                }
                else
                {
                    product.Price = price;
                }
                Console.Write("Enter product description: ");
                product.Description = Console.ReadLine();
                product.Id = Guid.NewGuid();
                productService.Add(product);

            }
            catch (InvalidPriceException ex)
            {
                Console.WriteLine("Invalid price: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            break;
        case "3":
            try
            {
                Console.WriteLine("Id ni daxil edin");
                    string idProduct=Console.ReadLine();
                if(!Guid.TryParse(idProduct,out Guid productId))
                {
                    throw new CustomFormatException();
                   
                }
                Product productExist = productService.GetById(productId);

                if (productExist == null)
                {
                    throw new CustomFormatException();
                }

                Console.WriteLine($"Name:{productExist.Name}");
                Console.WriteLine("Enter new name:");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    productExist.Name = newName;
                }
                Console.WriteLine($"Price:{productExist.Price}");
                Console.WriteLine("New price:");
                string newPriceInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPriceInput))
                {
                    if (double.TryParse(newPriceInput, out double newPrice) && newPrice >= 0)
                    {
                        productExist.Price = newPrice;
                    }
                    else
                    {
                        throw new InvalidPriceException();
                    }
                }
                Console.WriteLine($"Description: {productExist.Description}");
                Console.Write("New Description: ");
                string newDesc = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDesc))
                {
                    productExist.Description = newDesc;
                }
                productService.Update(productExist);
                Console.WriteLine("Product updated successfully.");
            }

            catch (ProductNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InvalidPriceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (CustomFormatException ex)
            {
                Console.WriteLine("Format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            break;
        case "4":
            try
            {
                Console.WriteLine("Delete Product");
                // Delete product logic here
                Console.WriteLine("Id ni daxil edin");
                string idProductdel = Console.ReadLine();
                if (!Guid.TryParse(idProductdel, out Guid productIddel))
                {
                    throw new CustomFormatException();
                 
                }
                Product productExistdel = productService.GetById(productIddel);

                if (productExistdel == null)
                {
                    throw new CustomFormatException();
                }
                productService.Delete(productIddel);

                Console.WriteLine("Product uğurla silindi.");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format xətası: " + ex.Message);
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine("Məhsul xətası: " + ex.Message);
            }

            break;
        case "5":
            Console.WriteLine("All Customers:");
            foreach (var customers in database.Customers)
            {
                Console.WriteLine($"ID: {customers.Id}, Name: {customers.Name}, Surname: {customers.Surname}");
            }
            break;
        case "6":
            Console.WriteLine("All Orders:");
            foreach (var orders in database.Orders)
            {
                Console.WriteLine($"Order ID: {orders.Id}, Total Price: {orders.TotalPrice}");
                foreach (var product in order.Products)
                {
                    Console.WriteLine($"\tProduct ID: {product.Id}, Name: {product.Name}");
                }
            }
            break;
        case "7":
            try
            {

                Console.WriteLine("Add Order");
                // Add order logic here

                Order newOrder = new Order();
                newOrder.Id = Guid.NewGuid();
                newOrder.Products = new List<Product>();
                bool addMore = true;
                while (addMore)
                {
                    Console.WriteLine("All Products");
                    foreach (var product in database.Products)
                    {
                        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
                    }
                    Console.WriteLine("Sifariş idsini daxil edin:");
                    string inputProduct = Console.ReadLine();
                    if (!Guid.TryParse(inputProduct, out Guid productIdOrder))
                    {
                        throw new CustomFormatException();

                    }
                    var productOrder = productService.GetById(productIdOrder);
                    if (productOrder == null)
                    {
                        throw new ProductNotFoundException();
                    }

                    newOrder.Products.Add(productOrder);
                    Console.WriteLine($"Məhsul əlavə olundu:{productOrder.Name}-{productOrder.Price}");
                    Console.Write("Davam etmək istəyirsinizmi? (bəli/xeyr): ");
                    string answer = Console.ReadLine().Trim().ToLower();

                    if (answer != "bəli" && answer != "beli")
                    {
                        addMore = false;
                    }
                }
                if (order.Products.Count == 0)
                {
                    Console.WriteLine("mehsul elave edin");
                }
                orderService.Add(newOrder);
                Console.WriteLine("\nSifariş uğurla yaradıldı!");
                Console.WriteLine($"Ümumi qiymət: {newOrder.TotalPrice} AZN");
            }
            catch
            {

            }
    
    break;
        case "8":
            Console.WriteLine("Update Order");
            // Update order logic here
            break;
        case "9":
            Console.WriteLine("Delete Order");
            // Delete order logic here
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }
}


//Thread t = new Thread(() => {
//    while(true)
//    {
//        Console.WriteLine("\tyyyyyyyyyy");
//    }
//});


//t.Name = "Worker Thread";
//t.Start();



//while (true)
//{
//    Console.WriteLine("xxxxxxxxxx");
//}

//Console.WriteLine("Hello");