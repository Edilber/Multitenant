using Back.Application.Common.Exceptions;
using Back.Application.Common.Interfaces;
using Back.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Commands.Auth
{
    public class AuthCommand : IRequest<ServiceResponse<AuthResponseDTO>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthCommandHandler : IRequestHandler<AuthCommand, ServiceResponse<AuthResponseDTO>>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
        {
            _identityService = identityService;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ServiceResponse<AuthResponseDTO>> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            ServiceResponse<AuthResponseDTO> response = new ServiceResponse<AuthResponseDTO>();

            var result = await _identityService.SigninUserAsync(request.UserName, request.Password);

            if (!result)
            {
                response.Success = false;
                response.ErrorList.Add(new ErrorDataModel { Code = "001", Message = "Usuario o password inválidos" });
                //throw new BadRequestException("Usuario o password inválidos");
            }

            var (userId, userName, email, phone, roles) = await _identityService.GetUserDetailAsync(await _identityService.GetUserIdAsync(request.UserName));

            string token = _tokenGenerator.GenerateJWTToken((userId: userId, userName: userName, roles: roles));

            response.Success = true;
            response.Data = new List<AuthResponseDTO>();
            response.Data.Add(new AuthResponseDTO
            {
                UserId = userId,
                Name = userName,
                Token = token
            });

            return response;
        }
    }
}
