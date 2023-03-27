using MediatR;

namespace TodoCQRS.Application.Commands;

public record DeleteTodoCommand(Guid Id) : IRequest;