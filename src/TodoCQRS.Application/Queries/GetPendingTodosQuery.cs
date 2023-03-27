using MediatR;
using TodoCQRS.Application.DTOs;

namespace TodoCQRS.Application.Queries;

public record GetPendingTodosQuery : IRequest<IEnumerable<TodoDto>>;