using Mapster;
using MediatR;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Application.Queries;
using TodoCQRS.Infrastructure.Data.Repositories;

namespace TodoCQRS.Application.Handlers;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoDto>>
{
    private readonly ITodoRepository _repository;

    public GetTodosQueryHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _repository.GetAllAsync();
        return todos.Adapt<IEnumerable<TodoDto>>();
    }
}