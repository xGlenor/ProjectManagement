using MongoDB.Driver;
using ProjectManagement.IService;
using Task = ProjectManagement.Models.Task;

namespace ProjectManagement.Services;

public class TaskService : ITaskService
{
    private readonly DbContext db;

    public TaskService(DbContext db)
    {
        this.db = db;
    }

    public List<Task> GetAll()
    {
        try
        {
            return db.TaskRecord.FindSync(FilterDefinition<Task>.Empty).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Add(Task task)
    {
        try
        {
            db.TaskRecord.InsertOne(task);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task GetById(string Id)
    {
        try
        {
            FilterDefinition<Task> filter = Builders<Task>.Filter.Eq("taskId", Id);

            return db.TaskRecord.Find(filter).FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Update(Task task)
    {
        try
        {
            db.TaskRecord.ReplaceOne(filter: g => g.taskId == task.taskId, replacement: task);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Delete(string Id)
    {
        try
        {
            FilterDefinition<Task> taskData = Builders<Task>.Filter.Eq("taskId", Id);
            db.TaskRecord.DeleteOne(taskData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}