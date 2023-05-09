using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.Entities;
using Mapster;

namespace Aquaculture.Api.Common.Mapping;

public class FishTankMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<FishTank, FishTankDto>()
            .Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<FishTankDto, CreateFishTankDto>();
        config.NewConfig<FishInfo, FishInfoDto>();
    }
}
