using Back.Application.Commands.User.Update;
using Back.Application.Commands.UserRoles;
using Back.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;

namespace ApiRestAutosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin, Management")]
    public class UserRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("Update")]
        [ProducesDefaultResponseType(typeof(int))]
        public async Task<IActionResult> Update(UpdateUserRolesCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
