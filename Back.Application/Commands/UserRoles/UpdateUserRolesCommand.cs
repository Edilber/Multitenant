using Back.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Commands.UserRoles
{
    public record UpdateUserRolesCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }

    public class UpdateUserRolesCommandHandler : IRequestHandler<UpdateUserRolesCommand, int>
    {
        private readonly IIdentityService _identityService;
        public UpdateUserRolesCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<int> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UpdateUsersRole(request.UserName, request.Roles);
            return result ? 1 : 0;
        }
    }
}
