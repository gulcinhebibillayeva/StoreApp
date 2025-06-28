using StoreProjectApp.Database;
using StoreProjectApp.Models;
using StoreProjectApp.Sevices.Abstract;

namespace StoreProjectApp.Sevices;

class CustomerService : BaseService, ICustomerService
{
    public CustomerService(StoreAppDatabase database) : base(database)
    {
    }

    public void Add(Customer item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Customer GetByBarcode(Guid barcode)
    {
        throw new NotImplementedException();
    }

    public Customer GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer item)
    {
        throw new NotImplementedException();
    }
}
