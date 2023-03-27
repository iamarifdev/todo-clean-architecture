using Mapster;
using MediatR;
using TodoCQRS.Application.Commands;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Domain.Exceptions;
using TodoCQRS.Infrastructure.Data.Repositories;

namespace TodoCQRS.Application.Handlers;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDto>
{
    private readonly ITodoRepository _repository;

    public UpdateTodoCommandHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _repository.GetByIdAsync(request.Id);

        if (todo == null) throw new NotFoundException("Todo item not found.");

        todo.Title = request.Title;
        todo.Description = request.Description;
        todo.IsCompleted = request.IsCompleted;

        await _repository.UpdateAsync(todo);
        return todo.Adapt<TodoDto>();
    }
}