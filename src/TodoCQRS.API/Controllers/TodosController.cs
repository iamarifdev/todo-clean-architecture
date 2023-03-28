using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoCQRS.Application.Commands;
using TodoCQRS.Application.DTOs;
using TodoCQRS.Application.Queries;

namespace TodoCQRS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : Controller
{
    private readonly IMediator _mediator;

    public TodosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> CreateTodo(CreateTodoCommand command)
    {
        var todo = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoDto>> GetTodoById(Guid id)
    {
        var todo = await _mediator.Send(new GetTodoByIdQuery(id));
        return Ok(todo);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodos()
    {
        var todos = await _mediator.Send(new GetTodosQuery());
        return Ok(todos);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTodo(Guid id, UpdateTodoCommand command)
    {
        if (id != command.Id) return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodo(Guid id)
    {
        await _mediator.Send(new DeleteTodoCommand(id));
        return NoContent();
    }

    [HttpGet("pending")]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetPendingTodos()
    {
        var todos = await _mediator.Send(new GetPendingTodosQuery());
        return Ok(todos);
    }

    [HttpGet("completed")]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetCompletedTodos()
    {
        var todos = await _mediator.Send(new GetCompletedTodosQuery());
        return Ok(todos);
    }

    [HttpPatch("{id:guid}/toggle-status")]
    public async Task<ActionResult<TodoDto>> ToggleTodoStatus(Guid id)
    {
        var todo = await _mediator.Send(new ToggleTodoStatusCommand(id));
        return Ok(todo);
    }
}