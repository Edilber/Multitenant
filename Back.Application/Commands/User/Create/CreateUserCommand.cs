using Back.Application.Common.Interfaces;
using Back.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Commands.User.Create
{
    public class CreateUserCommand : IRequest<UserCreateResponseDTO>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }

    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserCreateResponseDTO>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserCreateResponseDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(request.UserName, request.Password, request.Email, request.PhoneNumber, request.Roles);

            var response = new UserCreateResponseDTO()
            {
                Id = result.userId,
                IsSucced = result.isSucceed
            };

            return response;
        }
    }
}
