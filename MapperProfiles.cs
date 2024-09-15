using AutoMapper;
using ProjectManagement.Dtos;
using ProjectManagement.Models;

namespace ProjectManagement;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<Project, ProjectDtos>();
        CreateMap<User, UserDtos>();
    }
    
    
}