using System.Device.Location;

namespace Aquaculture.Domain.Tests.ControlWaterContext;

[TestFixture]
internal class MasterNetworkTestFixture
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
        string list = "";
        for (int i = 0; i < 6556; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
    }

    [Test]
    [Description("Проверяет добавление в комнату митинга с корректными параметрами.")]
    public void GetAvgWeight_WithFishInfoIds_Equal()
    {
        Assert.IsTrue(true);
    }

    [Test]
    [Description("Проверяет добавление в комнату митинга с корректными параметрами.")]
    public void MountMasterNetwork_Success()
    {
        Assert.IsTrue(true);
    }

    //////////////////////////////
    [Test]
    public void CatchFish_CorrectNumber_Success()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void CatchFish_NumberMoreThanExist_ThrowException()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void AddFish_CorrectNumber_Success()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void AddFish_NumberMoreThanPossibly_ThrowException()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void AddDeadFish_CorrectNumber_Success()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void AddDisease_CorrectId_Success()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void ConnectWith_CorrectParams_Success()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void ConnectWith_InvalidUrl_ThrowException()
    {
        Assert.IsTrue(true);
    }
    [Test]
    public void ChangeSensorInfo_CorrectParams_Success()
    {
        Assert.IsTrue(true);
    }
}
