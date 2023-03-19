using CompanyShopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CompanyShopApi.Services;

public class OrderService
{
    private readonly IMongoCollection<Order> _orderCollection;

    public OrderService(IOptions<CompanyShopDbSettings> companyShopDbSet)
    {
        var mongoClient = new MongoClient(companyShopDbSet.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(companyShopDbSet.Value.DatabaseName);
        _orderCollection = mongoDatabase.GetCollection<Order>("order");
    }

    public async Task<List<Order>> GetAsync() =>
        await _orderCollection.Find(_ => true).ToListAsync();

    public async Task<Order?> GetAsync(string id) =>
        await _orderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task CreateAsync(Order newOrder) =>
        await _orderCollection.InsertOneAsync(newOrder);

    public async Task UpdateAsync(string id, Order updatedOrder) =>
        await _orderCollection.ReplaceOneAsync(x => x.Id == id, updatedOrder);

    public async Task RemoveAsync(string id) =>
        await _orderCollection.DeleteOneAsync(x => x.Id == id);
}
