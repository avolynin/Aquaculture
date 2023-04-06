using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Application.Users.Commands.Register;
using Aquaculture.Application.Users.Queries.Login;
using Aquaculture.Contracts.Dto;
using Mapster;

namespace Aquaculture.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterDto, RegisterCommand>();
        config.NewConfig<LoginDto, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationDto>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.FullName, src => src.User.FullName)
            .Map(dest => dest.Role, src => src.User.Role)
            .Map(dest => dest.Token, src => src.Token);
    }
}
