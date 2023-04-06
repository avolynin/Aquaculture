using Aquaculture.Application.Common;
using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Domain.Common.Errors;
using Aquaculture.Domain.Repositories;
using Aquaculture.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Users.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var passwordHash = _passwordHasher.Hash(command.Password);

        User user = User.CreateNew(
            command.FullName,
            command.Email,
            passwordHash);
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}
