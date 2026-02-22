using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Application.Features.Users.Commands;
using UserManagementSystem.Application.Features.Users.DTO;
using UserManagementSystem.Application.Features.Users.Queries;

namespace UserManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
            => Ok(await _mediator.Send(new GetAllUsersQuery()));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid user ID.");

            var updatedCommand = command with { Id = id };

            await _mediator.Send(updatedCommand);

            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}
