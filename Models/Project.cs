using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectManagement.Models;

public class Project
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string projectId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    
    public string projectName { get; set; }
    
    public string description { get; set; }
    
    public DateTime startDate { get; set; }
    
    public DateTime endDate { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public string status { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string managerId { get; set; }
}