using System.Reflection;
using Mapster;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Domain.Entities;

namespace TodoCQRS.Application.Mapping;

public static class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Todo, TodoDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt);

        TypeAdapterConfig<TodoDto, Todo>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt);

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}