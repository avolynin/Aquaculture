using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;

namespace Aquaculture.Domain.Repositories;

public interface IWaterMeasurementRepository
{
    IEnumerable<WaterMeasurement> GetBy(FishTankId fishTankId);
    IEnumerable<WaterMeasurement> GetByPeriod(FishTankId fishTankId, DateTime from, DateTime to);
    WaterMeasurement? Get(FishTankId fishTankId, DateTime timeStamp);
    void Add(WaterMeasurement measurement);
}
