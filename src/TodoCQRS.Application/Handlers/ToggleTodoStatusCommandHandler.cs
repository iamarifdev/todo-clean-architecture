using Mapster;
using MediatR;
using TodoCQRS.Application.Commands;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Domain.Exceptions;
using TodoCQRS.Infrastructure.Data.Repositories;

namespace TodoCQRS.Application.Handlers;

public class ToggleTodoStatusCommandHandler : IRequestHandler<ToggleTodoStatusCommand, TodoDto>
{
    private readonly ITodoRepository _repository;

    public ToggleTodoStatusCommandHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoDto> Handle(ToggleTodoStatusCommand request, CancellationToken cancellationToken)
    {
        var todo = await _repository.GetByIdAsync(request.Id);
        if (todo == null) throw new NotFoundException("Todo item not found.");

        todo.IsCompleted = !todo.IsCompleted;
        await _repository.UpdateAsync(todo);
        return todo.Adapt<TodoDto>();
    }
}