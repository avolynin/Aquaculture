export type WaterParamDto = {
    id: string;
    name: string;
    unit: string;
}

export type DiseaseDto = {
    id: string;
    name: string;
    description: string | undefined;
}

export class RangeDto {
    constructor(public minValue: number, public maxValue: number){}

    public toString = () : string => {
        return `(min: ${this.minValue}, max: ${this.maxValue})`;
    }
}

export type MeasurementDto = {
    id: string;
    fishTankId: string;
    timeStamp: string;
    waterParamId: string;
    masterNetworkId: string;
    value: number;
    location: LocationDto;
    depth: number;
}

export type PumpDto = {
    id: string;
    isEnable: boolean;
    model: string;
    efficiency: number;
    fishTankId: string;
    operatingTime: string;
}

export type DPSDto = {
    id: string;
    url: string;
    sensors: SensorDto[];
    location: LocationDto;
    fishTankId: string;
    duration: number;
}

export type SensorDto = {
    id: number;
    status: string;
    place: string;
    waterParamId: string;
    charging: number;
    depth: number;
}

export type AnomalyDto = {
    deadFish: number;
    diseaseIds: string[];
}

export type FishInfoDto = {
    id: string;
    numberFish: number;
    biomass: number;
    commitedDate: string;
    createdDate: string;
    anomaly: AnomalyDto;
    typeId: string;
}

export type PredictDto = {
    id: string;
    fishTankId: string;
    timeStamp: string;
    waterParamId: string;
    value: number;
    location: LocationDto;
    depth: number;
}

export type LocationDto = {
    altitude: number;
    course: number;
    horizontalAccuracy: number;
    latitude: number;
    longitude: number;
    speed: number;
    verticalAccuracy: number;
}

export type FishTankDto = {
    id: string;
    name: string;
    volume: number;
    location: LocationDto;
    fishInfos: FishInfoDto[];
    masterNetworkId: string;
}

export type FishTypeDto = {
    id: string;
    name: string;
    weight: number;
    fishAge: {
        name: string;
        code: string | undefined;
    }
    comfortParams: Map<string, RangeDto>;
    tolerantParams: Map<string, RangeDto>;
    criticalParams: Map<string, RangeDto>;
}