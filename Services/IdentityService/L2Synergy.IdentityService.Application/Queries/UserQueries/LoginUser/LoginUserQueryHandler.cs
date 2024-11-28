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

namespace L2Synergy.IdentityService.Application.Queries.UserQueries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Result<TokenDto>>
    {
        private readonly IUserRepository userRepo;
        private readonly ITokenGenerator tokenGenerator;

        public LoginUserQueryHandler(IUserRepository userRepo, ITokenGenerator tokenGenerator)
        {
            this.userRepo = userRepo;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<Result<TokenDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetAsync(_ => _.Username == request.Login.Username && _.Password == request.Login.Password);

            if (user is null)
                return (Result<TokenDto>)Result<TokenDto>.Failure(400);


            var tokenDto = tokenGenerator.GenerateToken(user);
            user.Token = tokenDto.RefreshToken;
            user.TokenExpire = DateTime.Now.AddDays(7);

            await userRepo.Update(user);

            return Result<TokenDto>.Success(statusCode: 200, value: tokenDto);

        }
    }

}
