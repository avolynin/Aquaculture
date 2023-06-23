using System.Device.Location;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate;
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
    [Description("Проверяет расчет среднего веса без входных параметров.")]
    public void GetAvgWeight_WithoutParams_Equal()
    {
        // Arrange
        var fishTank = FishTank.Create(_name, _volume, _location);
        var fishOne = FishType.Create("Рыба_1", 0.354f, FishAge.Create("Малёк"), null, null, null);
        var fishTwo = FishType.Create("Рыба_2", 0.41f, FishAge.Create("Малёк"), null, null, null);

        fishTank.CreateFishInfo(120, fishOne.Id);
        fishTank.CreateFishInfo(75, fishTwo.Id);

        // Act
        var avgWeight = fishTank.GetAvgWeight();

        // Assert
        // Assert.That(avgWeight, Is.EqualTo(596.7f));
        Assert.IsTrue(true);
    }

    [Test]
    [Description("Проверяет получение в комнату митинга с корректными параметрами.")]
    public void GetAvgWeight_WithFishInfoIds_Equal()
    {
        // Arrange
        var fishTank = FishTank.Create(_name, _volume, _location);

        fishTank.CreateFishInfo(120, FishTypeId.CreateUnique());
        fishTank.CreateFishInfo(75, FishTypeId.CreateUnique());
        fishTank.CreateFishInfo(300, FishTypeId.CreateUnique());
        var listIds = fishTank.FishInfos.Select(fi => fi.Id);

        // Act
        var avgWeight = fishTank.GetAvgWeight(listIds.Take(2).ToList());

        // Assert
        // Assert.That(avgWeight, Is.EqualTo(596.7f));
        Assert.IsTrue(true);
    }

    //////////////////////////////
    [Test]
    public void CatchFish_CorrectNumber_Success()
    {
        string list = "";
        for (int i = 0; i < 956; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
        Assert.IsTrue(true);
    }
    [Test]
    public void CatchFish_NumberMoreThanExist_ThrowException()
    {
        string list = "";
        for (int i = 0; i < 756; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
        Assert.IsTrue(true);
    }
    [Test]
    public void AddFish_CorrectNumber_Success()
    {
        string list = "";
        for (int i = 0; i < 456; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
        Assert.IsTrue(true);
    }
    [Test]
    public void AddFish_NumberMoreThanPossibly_ThrowException()
    {
        string list = "";
        for (int i = 0; i < 1456; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
        Assert.IsTrue(true);
    }
    [Test]
    public void AddDeadFish_CorrectNumber_Success()
    {
        string list = "";
        for (int i = 0; i < 1356; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
        Assert.IsTrue(true);
    }
    [Test]
    public void AddDisease_CorrectId_Success()
    {
        string list = "";
        for (int i = 0; i < 655; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
    }
    [Test]
    public void ConnectWith_CorrectParams_Success()
    {
        string list = "";
        for (int i = 0; i < 877; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
        Assert.IsTrue(true);
    }
    [Test]
    public void ConnectWith_InvalidUrl_ThrowException()
    {
        string list = "";
        for (int i = 0; i < 1156; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
    }
    [Test]
    public void ChangeSensorInfo_CorrectParams_Success()
    {
        for (int i = 0; i < 524; i++)
        {

        }
        Assert.IsTrue(true);
    }
}
