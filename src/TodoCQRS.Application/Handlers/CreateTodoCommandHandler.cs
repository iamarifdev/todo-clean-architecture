using Mapster;
using MediatR;
using TodoCQRS.Application.Commands;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Domain.Entities;
using TodoCQRS.Infrastructure.Data.Repositories;

namespace TodoCQRS.Application.Handlers;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoDto>
{
    private readonly ITodoRepository _repository;

    public CreateTodoCommandHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo(request.Title, request.Description);
        await _repository.AddAsync(todo);
        return todo.Adapt<TodoDto>();
    }
}