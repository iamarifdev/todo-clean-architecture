using Mapster;
using MediatR;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Application.Queries;
using TodoCQRS.Infrastructure.Data.Repositories;

namespace TodoCQRS.Application.Handlers;

public class GetPendingTodosQueryHandler : IRequestHandler<GetPendingTodosQuery, IEnumerable<TodoDto>>
{
    private readonly ITodoRepository _repository;

    public GetPendingTodosQueryHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TodoDto>> Handle(GetPendingTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _repository.GetPendingTodosAsync();
        return todos.Adapt<IEnumerable<TodoDto>>();
    }
}