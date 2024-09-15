using ProjectManagement.Dtos;
using ProjectManagement.Models;

namespace ProjectManagement.IService;

public interface IProjectService
{
    List<Project> GetAll();
    
    void Add(Project project);

    Project GetById(string Id);

    void Update(Project project);

    string GetNameById(string Id);
    
    void Delete(string Id);

    List<ProjectDtos> GetAllProjectNames();
}