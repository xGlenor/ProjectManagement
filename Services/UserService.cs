using AutoMapper;
using MongoDB.Driver;
using ProjectManagement.Dtos;
using ProjectManagement.IService;
using ProjectManagement.Models;

namespace ProjectManagement.Services;

public class UserService(DbContext db, IMapper mapper) : IUserService
{
    public List<User> GetAll()
    {
        try
        {
            return db.UserRecord.FindSync(FilterDefinition<User>.Empty).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Add(User user)
    {
        try
        {
            db.UserRecord.InsertOne(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public User GetById(string Id)
    {
        try
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("userId", Id);

            return db.UserRecord.Find(filter).FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Update(User user)
    {
        try
        {
            db.UserRecord.ReplaceOne(filter: g => g.userId == user.userId, replacement: user);
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
            FilterDefinition<User> userData = Builders<User>.Filter.Eq("userId", Id);
            db.UserRecord.DeleteOne(userData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public List<UserDtos> GetAllUsers()
    {
        try
        {
            var projection = Builders<User>.Projection.Include("userId").Include("email").Exclude("_id");
            var result = db.UserRecord.Find(FilterDefinition<User>.Empty).Project(projection).ToList();
            var users =  db.UserRecord.FindSync(FilterDefinition<User>.Empty).ToList();
            return mapper.Map<List<UserDtos>>(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}