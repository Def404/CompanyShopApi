using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CompanyShopApi.Models;

public class Cart
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("hard_drive_id")]
    public string HardDriveId { get; set; } = null!;
    
    [BsonElement("count")]
    public int Count { get; set; }
}
