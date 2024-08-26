using System;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.GetListUsers
{
	public class GetListUsersHandler : IRequestHandler<GetListUsersQuery, Object>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public GetListUsersHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Object> Handle(GetListUsersQuery query, CancellationToken cancellationToken)
        {
            List<User> users = _userRepository.GetAll();
            if (users is null)
                return new List<User> ();
            return users;

        }
    }
}

