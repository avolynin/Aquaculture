export type WaterMeasurement = {
    id: string;
    fishTankId: string;
    timeStamp: string;
    waterParams: WaterParams;
}

export type WaterParams = {
    temperature: number;
    dissolvedOxygen: number;
    acidity: number;
    alkalinity: number;
    carbonDioxide: number;
    ammonia: number;
}

export type MeasurementChartData = {
    name: string;
    temperature: number;
    dissolvedOxygen: number;
    acidity: number;
    alkalinity: number;
    carbonDioxide: number;
    ammonia: number;
}