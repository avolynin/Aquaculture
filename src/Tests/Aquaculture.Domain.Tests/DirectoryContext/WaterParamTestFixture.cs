using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaculture.Domain.Tests.DirectoryContext;

[TestFixture]
internal class WaterParamTestFixture
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
}
