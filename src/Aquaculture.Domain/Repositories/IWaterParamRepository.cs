using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface IWaterParamRepository
{
    void Add(WaterParam waterParam);
    WaterParam? Get(WaterParamId waterParamId);
    void Update(WaterParam waterParam);
    void Delete(WaterParam waterParam);
}
