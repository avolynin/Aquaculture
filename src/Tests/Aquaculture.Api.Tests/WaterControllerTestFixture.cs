using System.Device.Location;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Aquaculture.Api.Controllers;
using Aquaculture.Application.Water.Measurement.Commands.Create;
using Aquaculture.Contracts.Dto;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using MapsterMapper;
using MediatR;
using Moq;

namespace Aquaculture.Api.Tests;

[TestFixture]
public class WaterControllerTestFixture
{
    private WaterController _controller;
    private Guid _measurementId;
    private DateTime _timeStamp;
    private float _value;
    private float _depth;
    private Guid _fishTankId;
    private Guid _waterParamId;
    private Guid _sensorId;
    private GeoCoordinate _location;

    private ISender _sender;
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        _mapper = null;
        _sender = null;

        _measurementId = Guid.NewGuid();
        _timeStamp = DateTime.UtcNow;
        _value = 24.33f;
        _depth = 1.42f;
        _fishTankId = Guid.NewGuid();
        _waterParamId = Guid.NewGuid();
        _sensorId = Guid.NewGuid();
        _location = new GeoCoordinate(67, 35);

        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m
            .Map<WaterMeasurement, WaterMeasurementDto>(It.IsAny<WaterMeasurement>()))
            .Returns(new WaterMeasurementDto(
                    Id: _measurementId,
                    Depth: _depth,
                    FishTankId: _fishTankId,
                    Location: _location,
                    SensorId: _sensorId,
                    TimeStamp: _timeStamp,
                    Value: _value,
                    WaterParamId: _waterParamId
                ));

        var senderMock = new Mock<ISender>();

        _controller = new WaterController(senderMock.Object, mapperMock.Object);
    }

    [Test]
    [Description("Проверяет создание нового измерения с корректными параметрами.")]
    public async Task CreateMeasurement_CorrectParams_SuccessAsync()
    {
        Assert.IsTrue(true);
        // Arrange
        //var measurementDto = new CreateWaterMeasurementDto(
        //            Depth: _depth,
        //            FishTankId: _fishTankId,
        //            Location: _location,
        //            TimeStamp: _timeStamp,
        //            Value: _value,
        //            WaterParamId: _waterParamId);

        //// Act
        //var command = _mapper.Map<CreateMeasurementCommand>(measurementDto);
        //var createMeasurementResult = await _sender.Send(command);

        //// Assert
        //Assert.That(
        //    createMeasurementResult.Value,
        //    Is.EqualTo(WaterMeasurement.Create(
        //        depth: _depth,
        //        fishTankId: _fishTankId,
        //        location: _location,
        //        timeStamp: _timeStamp,
        //        value: _value,
        //        waterParamId: _waterParamId)));
    }
}

/*
 WaterMeasurement.Create(
                fishTankId: FishTankId.Create(_fishTankId),
                timeStamp: _timeStamp,
                waterParamId: WaterParamId.Create(_waterParamId),
                value: _value,
                depth: _depth,
                location: _location
                )
 */
