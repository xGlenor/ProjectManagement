using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectManagement.Models;

public class User
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

    [Required]
    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string userId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    
    [Required]
    [BsonElement("firstName")]
    public string firstName { get; set; }
    
    [Required]
    [BsonElement("lastName")]
    public string lastName { get; set; }
    
    [Required]
    [BsonElement("email")]
    public string email { get; set; }
    
    [Required]
    [MinLength(8)]
    [BsonElement("password")]
    public string password { get; set; }
}