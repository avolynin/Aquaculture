#Domain Models

#WaterMeasurement

```csharp
    WaterMeasurement Create();
    void Add(WaterParam param);
    void Remove(WaterParam param);
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "fishTankId": "00000000-0000-0000-0000-000000000000",
    "timeStamp": "2020-01-01T00:00:00.0000000Z",
    "waterParams":[
        {
            "temperature": 0.0,
            "dissolvedOxygen": 0.0,
            "acidity": 0.0,
            "alkalinity": 0.0,
            "carbonDioxide": 0.0,
            "ammonia": 0.0
        }
    ]
}
```