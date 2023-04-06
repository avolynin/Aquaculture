using Aquaculture.Domain.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.WaterMeasurementAggreate;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IWaterMeasurementRepository
{
    IEnumerable<WaterMeasurement> GetBy(FishTankId fishTankId);
    WaterMeasurement? Get(FishTankId fishTankId, DateTime timeStamp);
    void Add(WaterMeasurement measurement);
}
