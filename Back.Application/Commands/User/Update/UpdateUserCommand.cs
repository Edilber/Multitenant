using Back.Application.Common.Interfaces;
using Back.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Commands.User.Update
{
    public record UpdateUserCommand(string id, UserEditDTO user):IRequest<int>
    {
        
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IIdentityService _identityService;
        public UpdateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UpdateUserProfile(request.user.Id, request.user.Email, request.user.PhoneNumber, new List<string>());
            return result ? 1 : 0;
        }
    }
}
