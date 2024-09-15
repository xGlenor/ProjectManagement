using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectManagement.Dtos;

public class UserDtos
{
    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId userId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId();
    
    [BsonElement("email")]
    public string email { get; set; }
}