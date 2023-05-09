using System.Device.Location;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;

namespace Aquaculture.Domain.Tests.AquacultureContext;

[TestFixture]
public class FishTankTestFixture
{
    private string _name;
    private float _volume;
    private GeoCoordinate _location;

    [SetUp]
    public void Setup()
    {
        _name = "DT1";
        _volume = 10;
        _location = new GeoCoordinate(54.4, 23.23);
    }

    [Test]
    [Description("Проверяет расчет среднего веса с корректными параметрами.")]
    public void GetAvgWeight_WithoutParams_Equal()
    {
        var fishTank = FishTank.Create(_name, _volume, _location);

        fishTank.CreateFishInfo(120, FishTypeId.CreateUnique(), FishType.Create(3.26f));
        fishTank.CreateFishInfo(75, FishTypeId.CreateUnique(), FishType.Create(2.74f));
        var avgWeight = fishTank.GetAvgWeight();

        Assert.That(avgWeight, Is.EqualTo(596.7f));
    }

    [Test]
    [Description("Проверяет добавление в комнату митинга с корректными параметрами.")]
    public void GetAvgWeight_WithFishInfoIds_Equal()
    {
        var fishTank = FishTank.Create(_name, _volume, _location);

        fishTank.CreateFishInfo(120, FishTypeId.CreateUnique(), FishType.Create(3.26f));
        fishTank.CreateFishInfo(75, FishTypeId.CreateUnique(), FishType.Create(2.74f));
        fishTank.CreateFishInfo(300, FishTypeId.CreateUnique(), FishType.Create(1.50f));
        var listIds = fishTank.FishInfos.Select(fi => fi.Id);

        var avgWeight = fishTank.GetAvgWeight(listIds.Take(2).ToList());

        Assert.That(avgWeight, Is.EqualTo(596.7f));
    }
}
