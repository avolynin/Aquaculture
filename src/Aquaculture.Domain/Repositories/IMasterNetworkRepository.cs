using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.Entities;
using Aquaculture.Domain.ControlWaterContext.SensorAggregate.ValueObjects;

namespace Aquaculture.Domain.Repositories;

public interface ISensorRepository
{
    void Add(Sensor sensor);
    Sensor? Get(SensorId sensorId);
}
