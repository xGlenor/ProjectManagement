using System.Text.Json;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectManagement.Dtos;
using ProjectManagement.IService;
using ProjectManagement.Models;

namespace ProjectManagement.Services;

public class ProjectService : IProjectService
{
    private readonly DbContext db;
    private readonly IMapper _mapper;

    public ProjectService(DbContext db, IMapper mapper)
    {
        this.db = db;
        _mapper = mapper;
    }

    public List<Project> GetAll()
    {
        try
        {
            return db.ProjectRecord.FindSync(FilterDefinition<Project>.Empty).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Add(Project project)
    {
        try
        {
            db.ProjectRecord.InsertOne(project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Project GetById(string Id)
    {
        try
        {
            FilterDefinition<Project> filter = Builders<Project>.Filter.Eq("projectId", Id);

            return db.ProjectRecord.Find(filter).FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Update(Project project)
    {
        try
        {
            db.ProjectRecord.ReplaceOne(filter: g => g.projectId == project.projectId, replacement: project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public string GetNameById(string Id)
    {
        try
        {
            FilterDefinition<Project> filter = Builders<Project>.Filter.Eq("projectId", Id);

            return db.ProjectRecord.Find(filter).FirstOrDefault().projectName;
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
            FilterDefinition<Project> projectData = Builders<Project>.Filter.Eq("projectId", Id);
            db.ProjectRecord.DeleteOne(projectData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<ProjectDtos> GetAllProjectNames()
    {
        try
        {
            var projection = Builders<Project>.Projection.Include("projectId").Include("projectName").Exclude("_id");
            var result = db.ProjectRecord.Find(FilterDefinition<Project>.Empty).Project(projection).ToList();
            var projects =  db.ProjectRecord.FindSync(FilterDefinition<Project>.Empty).ToList();
            return _mapper.Map<List<ProjectDtos>>(projects);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}