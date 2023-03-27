using MediatR;
using TodoCQRS.Application.DTOs;

namespace TodoCQRS.Application.Commands;

public record UpdateTodoCommand(Guid Id, string Title, string Description, bool IsCompleted) : IRequest<TodoDto>;