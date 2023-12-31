﻿using Back.Application.Common.Interfaces;
using Back.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Queries.Users
{
    public class GetUserQuery : IRequest<List<UserResponseDTO>>
    {

    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserResponseDTO>>
    {
        private readonly IIdentityService _identityService;
        public GetUserQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<List<UserResponseDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _identityService.GetAllUsersAsync();

            return users.Select(x => new UserResponseDTO()
            {
                Id = x.id,
                UserName = x.userName,
                Email = x.email,
                PhoneNumber = x.phoneNumber

            }).ToList();
        }
    }
}
