using Aquaculture.Application.Common;
using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.Repositories;
using Aquaculture.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetByEmail(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        var isCorrectPassword = _passwordHasher.Verify(user.Password, query.Password);

        if (!isCorrectPassword)
            return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}
