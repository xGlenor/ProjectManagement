namespace ProjectManagement.IService;

public interface ITaskService
{
    List<Models.Task> GetAll();
    
    void Add(Models.Task task);

    Models.Task GetById(string Id);

    void Update(Models.Task task);
    
    void Delete(string Id);
}