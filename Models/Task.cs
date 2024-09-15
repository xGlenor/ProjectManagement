using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectManagement.Models;

public class Task
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

    [Required]
    [BsonElement("taskId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string taskId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    
    [BsonElement("projectId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string projectId { get; set; }
    public string taskName { get; set; }
    
    public string description { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public string priority { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public string status { get; set; }
    
    [BsonElement("assignedUserId")]
    public List<ObjectId> assignedUserId { get; set; }
}