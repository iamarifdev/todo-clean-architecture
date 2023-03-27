using Mapster;
using MediatR;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Application.Queries;
using TodoCQRS.Domain.Exceptions;
using TodoCQRS.Infrastructure.Data.Repositories;

namespace TodoCQRS.Application.Handlers;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
{
    private readonly ITodoRepository _repository;

    public GetTodoByIdQueryHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _repository.GetByIdAsync(request.Id);
        if (todo == null) throw new NotFoundException("Todo not found.");
        return todo.Adapt<TodoDto>();
    }
}