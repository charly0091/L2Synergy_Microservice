using L2Synergy.IdentityService.Application.TokenService;
using L2Synergy.IdentityService.Infrastructure.Repositories.Contracts;
using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserByRefreshToken
{
    public class GetUserByRefreshTokenQueryHandler : IRequestHandler<GetUserByRefreshTokenQuery, IResult<TokenDto>>
    {
        private readonly IUserRepository userRepo;
        private readonly ITokenGenerator tokenGenerator;

        public GetUserByRefreshTokenQueryHandler(IUserRepository userRepo, ITokenGenerator tokenGenerator)
        {
            this.userRepo = userRepo;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<IResult<TokenDto>> Handle(GetUserByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetAsync(predicate: _ => _.Token == request.RefreshToken);
            if (user is null)
                return Result<TokenDto>.Failure(404, "User not found!");

            var token = tokenGenerator.GenerateToken(user);
            user.Token = token.RefreshToken;
            user.TokenExpire = Convert.ToDateTime(token.RefreshExpire);

            await userRepo.Update(user);
            return Result<TokenDto>.Success(token);

        }
    }

}
