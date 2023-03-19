﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CompanyShopApi.Models;

public class ConnectionInterfaceType
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("transfer_rate")]
    public int TransferRate { get; set; }
}
