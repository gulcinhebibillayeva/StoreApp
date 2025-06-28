using StoreProjectApp.Models;

namespace StoreProjectApp.Database;

public class StoreAppDatabase
{
    public List<Customer> Customers { get; set; }
    public List<Product> Products { get; set; }
    public List<Order> Orders { get; set; }
    public StoreAppDatabase()
    {
        Customers = new List<Models.Customer>();
        Products = new List<Models.Product>();
        Orders = new List<Models.Order>();
    }
}
