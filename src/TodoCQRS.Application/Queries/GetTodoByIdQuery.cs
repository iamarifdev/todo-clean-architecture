using MediatR;
using TodoCQRS.Application.DTOs;

namespace TodoCQRS.Application.Queries;

public record GetTodoByIdQuery(Guid Id) : IRequest<TodoDto>;