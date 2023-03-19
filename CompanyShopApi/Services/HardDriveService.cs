using CompanyShopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CompanyShopApi.Services;

public class HardDriveService
{
    private readonly IMongoCollection<HardDrive> _hardDriveCollection;
    
    public HardDriveService(IOptions<CompanyShopDbSettings> companyShopDbSet)
    {
        var mongoClient = new MongoClient(companyShopDbSet.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(companyShopDbSet.Value.DatabaseName);
        _hardDriveCollection = mongoDatabase.GetCollection<HardDrive>("hardDrive");
    }
    
    public async Task<List<HardDrive>> GetAsync() =>
        await _hardDriveCollection.Find(_ => true).ToListAsync();

    public async Task<HardDrive?> GetAsync(string id) =>
        await _hardDriveCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task CreateAsync(HardDrive newHardDrive) =>
        await _hardDriveCollection.InsertOneAsync(newHardDrive);

    public async Task UpdateAsync(string id, HardDrive updatedHardDrive) =>
        await _hardDriveCollection.ReplaceOneAsync(x => x.Id == id, updatedHardDrive);

    public async Task RemoveAsync(string id) =>
        await _hardDriveCollection.DeleteOneAsync(x => x.Id == id);
}
