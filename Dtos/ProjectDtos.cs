using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectManagement.Dtos;

public class ProjectDtos
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string projectId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    
    public string projectName { get; set; }
}