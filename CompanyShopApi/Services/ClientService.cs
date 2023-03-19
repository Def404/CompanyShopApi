using CompanyShopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CompanyShopApi.Services;

public class ClientService
{
    private readonly IMongoCollection<Client> _clientCollection;
    
    public ClientService(IOptions<CompanyShopDbSettings> companyShopDbSet)
    {
        var mongoClient = new MongoClient(companyShopDbSet.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(companyShopDbSet.Value.DatabaseName);
        _clientCollection = mongoDatabase.GetCollection<Client>("client");
    }

    public async Task<List<Client>> GetAsync() =>
        await _clientCollection.Find(_ => true).ToListAsync();

    public async Task<Client?> GetAsync(string id) =>
        await _clientCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task CreateAsync(Client newClient) =>
        await _clientCollection.InsertOneAsync(newClient);

    public async Task UpdateAsync(string id, Client updatedClient) =>
        await _clientCollection.ReplaceOneAsync(x => x.Id == id, updatedClient);

    public async Task RemoveAsync(string id) =>
        await _clientCollection.DeleteOneAsync(x => x.Id == id);
}
