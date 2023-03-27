using MediatR;
using TodoCQRS.Application.DTOs;

namespace TodoCQRS.Application.Commands;

public record ToggleTodoStatusCommand(Guid Id) : IRequest<TodoDto>;