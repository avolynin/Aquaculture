using Aquaculture.Application.Users.Commands.Register;
using Aquaculture.Application.Users.Queries.Login;
using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.UserAggregate;
using Mapster;

namespace Aquaculture.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserDto, User>();
        config.NewConfig<User, UserDto>();
    }
}
