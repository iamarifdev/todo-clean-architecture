using Mapster;
using MediatR;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Application.Queries;
using TodoCQRS.Infrastructure.Data.Repositories;

namespace TodoCQRS.Application.Handlers;

public class GetCompletedTodosQueryHandler : IRequestHandler<GetCompletedTodosQuery, IEnumerable<TodoDto>>
{
    private readonly ITodoRepository _repository;

    public GetCompletedTodosQueryHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TodoDto>> Handle(GetCompletedTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _repository.GetCompletedTodosAsync();
        return todos.Adapt<IEnumerable<TodoDto>>();
    }
}