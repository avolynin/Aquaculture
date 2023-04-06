using Aquaculture.Application.Water.Measurement.Commands.Create;
using Aquaculture.Application.Water.Measurement.Queries;
using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.WaterMeasurementAggreate;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;
using Mapster;

namespace Aquaculture.Api.Common.Mapping;

public class WaterMeasurementMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<WaterParamsDto, WaterParams>();
        config.NewConfig<WaterParams, WaterParamsDto>();
        config.NewConfig<CreateWaterMeasurementDto, CreateMeasurementCommand>()
            .ConstructUsing(src => new CreateMeasurementCommand(
                src.FishTankId,
                src.TimeStamp,
                WaterParams.Create(
                    src.WaterParams.Temperature,
                    src.WaterParams.DissolvedOxygen,
                    src.WaterParams.Acidity,
                    src.WaterParams.Alkalinity,
                    src.WaterParams.CarbonDioxide,
                    src.WaterParams.Ammonia)));
        config.NewConfig<WaterMeasurement, WaterMeasurementDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.FishTankId, src => src.FishTankId.Value);
    }
}
