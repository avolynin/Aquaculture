using Aquaculture.Application.Users.Commands.Register;
using Aquaculture.Application.Users.Queries.Login;
using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.PersonalContext.UserAggregate;
using Mapster;

namespace Aquaculture.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserDto, User>().
            Map(dest => dest.Id.Value, src => src.Id);
        config.NewConfig<User, UserDto>().
            Map(dest => dest.Id, src => src.Id.Value);
    }
}
