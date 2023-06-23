using Aquaculture.Application.Water.Measurement.Commands.Create;
using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Mapster;

namespace Aquaculture.Api.Common.Mapping;

public class WaterMeasurementMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<WaterParamDto, WaterParam>();
        config.NewConfig<WaterParam, WaterParamDto>();
        config.NewConfig<CreateWaterMeasurementDto, CreateMeasurementCommand>();
        config.NewConfig<WaterMeasurement, WaterMeasurementDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.FishTankId, src => src.FishTankId.Value);
    }
}
