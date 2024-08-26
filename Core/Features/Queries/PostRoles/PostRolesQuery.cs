using System;
using Core.Features.Queries.PostUsers;
using MediatR;

namespace Core.Features.Queries.PostRoles
{
    public class PostRolesQuery : IRequest<PostRolesResponse>
    {
        public string Name { get; set; }
    }
}

