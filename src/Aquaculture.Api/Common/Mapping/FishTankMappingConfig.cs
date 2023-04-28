using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;
using Mapster;

namespace Aquaculture.Api.Common.Mapping;

public class FishTankMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<FishTank, FishTankDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.FishInfoId, src => src.FishInfoId.Value)
            .Map(dest => dest.WaterMeasurementId, src => src.WaterMeasurementId.Value);
        config.NewConfig<FishTankDto, CreateFishTankDto>();
    }
}
