using Back.Application.Commands.User.Create;
using Back.Application.Commands.User.Update;
using Back.Application.DTOs;
using Back.Application.Queries.Users;
using Back.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestAutosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin, Management")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesDefaultResponseType(typeof(UserCreateResponseDTO))]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetUserDetails/{userId}")]
        [ProducesDefaultResponseType(typeof(UserDetailsResponseDTO))]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            var result = await _mediator.Send(new GetUserDetailsQuery() { UserId = userId });
            return Ok(result);
        }


        [HttpGet("GetAll")]
        [ProducesDefaultResponseType(typeof(List<UserResponseDTO>))]
        public async Task<IActionResult> GetAllUserAsync()
        {
            return Ok(await _mediator.Send(new GetUserQuery()));
        }

        [HttpPut("Update/{id}")]
        [ProducesDefaultResponseType(typeof(int))]
        public async Task<IActionResult> Update(string id, UserEditDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new UpdateUserCommand(id, user)));
        }


    }
}
