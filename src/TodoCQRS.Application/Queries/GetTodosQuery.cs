using MediatR;
using TodoCQRS.Application.DTOs;

namespace TodoCQRS.Application.Queries;

public record GetTodosQuery : IRequest<IEnumerable<TodoDto>>;