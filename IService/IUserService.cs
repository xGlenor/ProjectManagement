using ProjectManagement.Dtos;
using ProjectManagement.Models;

namespace ProjectManagement.IService;

public interface IUserService
{
    List<User> GetAll();
    
    void Add(User user);

    User GetById(string Id);

    void Update(User user);
    
    void Delete(string Id);

    List<UserDtos> GetAllUsers();
    
}