using MediatR;
using TodoCQRS.Application.DTOs;

namespace TodoCQRS.Application.Commands;

public record CreateTodoCommand(string Title, string Description) : IRequest<TodoDto>;