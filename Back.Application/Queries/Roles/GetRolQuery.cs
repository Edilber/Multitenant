using Back.Application.Common.Interfaces;
using Back.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Queries.Roles
{
    public class GetRolQuery : IRequest<List<RolResponseDTO>>
    {
        
    }

    public class GetRolQueryHandler : IRequestHandler<GetRolQuery, List<RolResponseDTO>>
    {
        private readonly IIdentityService _identityService;
        public GetRolQueryHandler(IIdentityService identityService) 
        {
            _identityService = identityService;
        }
        public async Task<List<RolResponseDTO>> Handle(GetRolQuery request, CancellationToken cancellationToken)
        {
            var roles = await _identityService.GetRolesAsync();

            return roles.Select(x => new RolResponseDTO()
            {
                Id = x.id,
                Name = x.roleName

            }).ToList();
        }
    }
}
