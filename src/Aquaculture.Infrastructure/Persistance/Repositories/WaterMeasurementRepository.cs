using System.Reflection.Metadata.Ecma335;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.Repositories;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;

namespace Aquaculture.Infrastructure.Persistence.Repositories;

public class WaterMeasurementRepository : IWaterMeasurementRepository
{
    private readonly AquacultureDbContext _dbContext;

    public WaterMeasurementRepository(AquacultureDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(WaterMeasurement measurement)
    {
        _dbContext.Add(measurement);
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
