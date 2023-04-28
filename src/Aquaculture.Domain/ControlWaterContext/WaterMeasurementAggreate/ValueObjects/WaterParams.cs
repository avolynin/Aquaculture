using System.Collections;
using Aquaculture.Domain.Models;

namespace Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;

public class WaterParams : ValueObject
{
    public float Temperature { get; }
    public float DissolvedOxygen { get; }
    public float Acidity { get; }
    public float Alkalinity { get; }
    public float CarbonDioxide { get; }
    public float Ammonia { get; }

    protected WaterParams()
    {
    }

    private WaterParams(
        float temperature,
        float dissolvedOxygen,
        float acidity,
        float alkalinity,
        float carbonDioxide,
        float ammonia)
    {
        Temperature = temperature;
        DissolvedOxygen = dissolvedOxygen;
        Acidity = acidity;
        Alkalinity = alkalinity;
        CarbonDioxide = carbonDioxide;
        Ammonia = ammonia;
    }

    public static WaterParams Create(
        float temperature,
        float dissolvedOxygen,
        float acidity,
        float alkalinity,
        float carbonDioxide,
        float ammonia)
        => new WaterParams(
            temperature,
            dissolvedOxygen,
            acidity,
            alkalinity,
            carbonDioxide,
            ammonia);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Temperature;
        yield return DissolvedOxygen;
        yield return Acidity;
        yield return Alkalinity;
        yield return CarbonDioxide;
        yield return Ammonia;
    }
}
