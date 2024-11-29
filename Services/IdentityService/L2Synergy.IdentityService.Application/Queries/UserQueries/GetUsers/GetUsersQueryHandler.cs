using L2Synergy.IdentityService.Domain.Models;
using L2Synergy.IdentityService.Infrastructure.Repositories.Contracts;
using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<UserDto>>
    {
        private readonly IUserRepository userRepo;

        public GetUsersQueryHandler(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<Result<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await userRepo.GetAllAsync() ?? Enumerable.Empty<User>();
                var usersDto = users
                    .Select(u => new UserDto(
                        u.Id,
                        u.Username,
                        u.Email,
                        u.MemberId,
                        u.Role?.RoleName
                    ))
                    .ToList();
                return Result<UserDto>.Success(statusCode: 200, values: usersDto);
            }
            catch (Exception ex)
            {
                return Result<UserDto>.Failure(statusCode: 500, error: ex.Message);
            }
        }
    }

}
