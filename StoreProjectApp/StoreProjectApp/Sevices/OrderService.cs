using StoreProjectApp.Database;
using StoreProjectApp.Models;
using StoreProjectApp.Sevices.Abstract;

namespace StoreProjectApp.Sevices;

public class OrderService : BaseService, IOrderService
{
    public OrderService(StoreAppDatabase database) : base(database)
    {
    }

    public void Add(Order item)
    {
        foreach (var product in item.Products)
        {
            item.TotalPrice += product.Price;
        }
        _database.Orders.Add(item);
    }

    public void Delete(Guid id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _database.Orders.Remove(product);
        }
    }

    public List<Order> GetAll()
    {
        return _database.Orders.ToList();
    }

    public Order GetByBarcode(Guid barcode)
    {
        throw new NotImplementedException();
    }

    public Order GetById(Guid id)
    {
        return _database.Orders.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Order item)
    {
        throw new NotImplementedException();
    }
}
