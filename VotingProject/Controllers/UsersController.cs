using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingProject.Features.Commands;
using VotingProject.Features.Queries;

namespace VotingProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<BookController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetAllUsersQuery()));
    }

    // GET:api/<BookController>/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        return Ok(await _mediator.Send(new GetUsersByEmailQuery() { email = email }));
    }

    // POST: api/<BookController>/1
    [HttpPost]
    public async Task<IActionResult> UpdateUser(CreateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    // PUT: api/<BookController>/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserByEmail(string email, UpdateUserCommand command)
    {
        if (email != command.email)
        {
            return BadRequest();
        }
        return Ok(await _mediator.Send(command));
    }

    // DELETE: api/<BookController>/1
    [HttpDelete]
    public async Task<IActionResult> DeleteUser(string email)
    {
        return Ok(await _mediator.Send(new DeleteUserCommand() { email = email }));
    }
}