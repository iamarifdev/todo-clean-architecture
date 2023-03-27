using MediatR;
using TodoCQRS.Application.DTOs;

namespace TodoCQRS.Application.Queries;

public record GetCompletedTodosQuery : IRequest<IEnumerable<TodoDto>>;