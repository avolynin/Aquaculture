using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.Repositories;

namespace Aquaculture.Infrastructure.Persistance.ControlWaterContext;

public class WaterMeasurementRepository : IWaterMeasurementRepository
{
    private readonly WaterControlDbContext _dbContext;

    public WaterMeasurementRepository(WaterControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(WaterMeasurement measurement)
    {
        _dbContext.WaterMeasurements.Add(measurement);
        _dbContext.SaveChanges();
    }

    public IEnumerable<WaterMeasurement> GetBy(FishTankId fishTankId)
    {
        return _dbContext.WaterMeasurements.Where(
            m => m.FishTankId == fishTankId).ToList();
    }

    public WaterMeasurement? Get(FishTankId fishTankId, DateTime timeStamp)
    {
        return _dbContext.WaterMeasurements.SingleOrDefault(
            m => m.FishTankId == fishTankId && m.TimeStamp == timeStamp);
    }
}
