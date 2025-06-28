using StoreProjectApp.Database;
using StoreProjectApp.Models;

namespace StoreProjectApp.Sevices;

public abstract class BaseService
{
    protected StoreAppDatabase _database;
    public BaseService(StoreAppDatabase database)
    {
        _database = database;
    }
}
