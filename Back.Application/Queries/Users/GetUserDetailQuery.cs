using Back.Application.Common.Interfaces;
using Back.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Queries.Users
{
    public class GetUserDetailsQuery : IRequest<UserDetailsResponseDTO>
    {
        public string UserId { get; set; }
    }

    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsResponseDTO>
    {
        private readonly IIdentityService _identityService;

        public GetUserDetailsQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<UserDetailsResponseDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var (userId, userName, email, phone, roles) = await _identityService.GetUserDetailAsync(request.UserId);
            return new UserDetailsResponseDTO() { Id = userId, UserName = userName, Email = email, PhoneNumber = phone, Roles = roles };
        }
    }
}
