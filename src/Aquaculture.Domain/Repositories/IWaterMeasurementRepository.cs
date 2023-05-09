using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;

namespace Aquaculture.Domain.Repositories;

public interface IWaterMeasurementRepository
{
    IEnumerable<WaterMeasurement> GetBy(FishTankId fishTankId);
    WaterMeasurement? Get(FishTankId fishTankId, DateTime timeStamp);
    void Add(WaterMeasurement measurement);
}
