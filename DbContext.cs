using MongoDB.Driver;
using ProjectManagement.Models;
using Task = ProjectManagement.Models.Task;

namespace ProjectManagement;

public class DbContext
{
    private readonly IMongoDatabase _mongoDatabase;

    public DbContext()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        _mongoDatabase = client.GetDatabase("project_management");
    }

    public IMongoCollection<User> UserRecord
    {
        get => _mongoDatabase.GetCollection<User>("Users");
    }
    
    public IMongoCollection<Task> TaskRecord
    {
        get => _mongoDatabase.GetCollection<Task>("Tasks");
    }
    
    public IMongoCollection<Project> ProjectRecord
    {
        get => _mongoDatabase.GetCollection<Project>("Projects");
    }
    
}