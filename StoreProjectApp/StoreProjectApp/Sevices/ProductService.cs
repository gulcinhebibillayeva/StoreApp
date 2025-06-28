using StoreProjectApp.Database;
using StoreProjectApp.Exceptions;
using StoreProjectApp.Models;
using StoreProjectApp.Sevices.Abstract;

namespace StoreProjectApp.Sevices;

public class ProductService : BaseService, IProductService
{
    public ProductService(StoreAppDatabase database) : base(database)
    {
    }
    public List<Product> GetAll()
    {
        return _database.Products;
    }
    public Product GetById(Guid id)
    {
        var product = _database.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            throw new ProductNotFoundException($"ID'si {id} olan ürün bulunamadı.");
        }

        return product;

    }
    public void Add(Product item)
    {
        _database.Products.Add(item);
    }
    public void Update(Product item)
    {
        var product = GetById(item.Id);
        if (product != null)
        {
            product.Name = item.Name;
            product.Price = item.Price;
            product.Description = item.Description;
        }
    }
    public void Delete(Guid id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _database.Products.Remove(product);
        }
    }

    public Product GetByBarcode(Guid barcode)
    {
        throw new NotImplementedException();
    }
}
