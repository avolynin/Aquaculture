import { DPSDto, DiseaseDto, FishTankDto, FishTypeDto, MeasurementDto, PredictDto, PumpDto, RangeDto, WaterParamDto } from "./contracts";

// Примеры DTO типа FishType
export const fishTypesTemp: FishTypeDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000001',
        name: 'Карп',
        weight: 3.21,
        fishAge:{
            name: 'Малёк',
            code: '0001'
        },
        comfortParams: new Map(Object.entries({'00000000-0000-0000-0000-000000000001': new RangeDto(14, 18)})),
        tolerantParams: new Map(Object.entries({'00000000-0000-0000-0000-000000000001': new RangeDto(12, 22)})),
        criticalParams: new Map(Object.entries({'00000000-0000-0000-0000-000000000001': new RangeDto(7, 26)})),
    },
    {
        id: '00000000-0000-0000-0000-000000000002',
        name: 'Карп',
        weight: 2.56,
        fishAge:{
            name: 'Личинка',
            code: '0002',
        },
        comfortParams: new Map(Object.entries({'00000000-0000-0000-0000-000000000001': new RangeDto(15, 18), '00000000-0000-0000-0000-000000000002': new RangeDto(3, 4)})),
        tolerantParams: new Map(Object.entries({'00000000-0000-0000-0000-000000000001': new RangeDto(13, 20), '00000000-0000-0000-0000-000000000002': new RangeDto(2, 10)})),
        criticalParams: new Map(Object.entries({'00000000-0000-0000-0000-000000000001': new RangeDto(10, 24), '00000000-0000-0000-0000-000000000002': new RangeDto(0, 20)})),
    },
]

// Примеры DTO типа WaterParam
export const waterParamsTemp: WaterParamDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000001',
        name: 'Температура',
        unit: '℃'
    },
    {
        id: '00000000-0000-0000-0000-000000000002',
        name: 'Диоксид углерода',
        unit: 'мг/дм³'
    },
    {
        id: '00000000-0000-0000-0000-000000000003',
        name: 'Жесткость',
        unit: 'мг-экв/л'
    },
    {
        id: '00000000-0000-0000-0000-000000000004',
        name: 'Нитраты',
        unit: 'мг/л'
    }
]

// Примеры DTO типа Disease
export const diseasesTemp: DiseaseDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000001',
        name: 'Сапролегниоз',
        description: 'Предотвратить сапролегниоз можно только профилактическими мерами. Все мероприятия с рыбами нужно проводить без травматизации. Можно для профилактики и в лечебных целях применять такие препараты, как поваренная соль, бриллиантовый зеленый.'
    },
    {
        id: '00000000-0000-0000-0000-000000000002',
        name: 'Бранхиомикоз',
        description: 'Зараженный водоем ставится на карантин, погибшая рыба вылавливается и уничтожается. Осенью и весной пруды обеззараживают негашеной известью.'
    },
    {
        id: '00000000-0000-0000-0000-000000000003',
        name: 'Воспаление плавательного пузыря',
        description: undefined
    }
]

// Примеры DTO типа Disease
export const fishTanksTemp: FishTankDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000001',
        name: 'DT1',
        volume: 7,
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 47.13,
            longitude: 39.43,
            speed: 0,
            verticalAccuracy: 0,
        },
        fishInfos:[
            {
                id: '00000000-0000-0000-0000-000000000000',
                numberFish: 85,
                biomass: 14.32,
                createdDate: '01/01/2023 10:00:00',
                commitedDate: '01/01/2023 10:00:00',
                typeId: '00000000-0000-0000-0000-000000000001',
                anomaly: {
                    deadFish: 0,
                    diseaseIds: []
                }
            },
            {
                id: '00000000-0000-0000-0000-000000000001',
                numberFish: 155,
                biomass: 24.48,
                createdDate: '01/01/2023 10:00:00',
                commitedDate: '01/01/2023 10:00:00',
                typeId: '00000000-0000-0000-0000-000000000002',
                anomaly: {
                    deadFish: 0,
                    diseaseIds: []
                }
            }
        ],
        masterNetworkId: ''
    },
    {
        id: '00000000-0000-0000-0000-000000000002',
        name: 'RT1',
        volume: 9,
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 47.03,
            longitude: 39.48,
            speed: 0,
            verticalAccuracy: 0,
        },
        fishInfos: [],
        masterNetworkId: ''
    },
]

export const measurementsTemp: MeasurementDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000000',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.342,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000000',
        value: 24.89,
        timeStamp: '01/01/2023 13:00:00'
    },
    {
        id: '00000000-0000-0000-0000-002000000001',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.352,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 24.973,
        timeStamp: '01/01/2023 12:55:00'
    },
    {
        id: '00000002-0000-0000-0000-000000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.14,
        timeStamp: '01/01/2023 12:50:00'
    },
    {
        id: '00000011-0000-0000-0000-000000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 24.98,
        timeStamp: '01/01/2023 12:45:00'
    },
    {
        id: '01000000-0000-0000-0000-000000000001',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 24.78,
        timeStamp: '01/01/2023 12:40:00'
    },
    {
        id: '00001000-0000-0000-0000-000000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 24.89,
        timeStamp: '01/01/2023 12:35:00'
    },
    {
        id: '00000001-0000-0000-0000-000000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.43,
        timeStamp: '01/01/2023 12:30:00'
    },
    {
        id: '00000000-0010-0000-0000-000000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.55,
        timeStamp: '01/01/2023 12:25:00'
    },
    {
        id: '00000000-0000-0000-0010-000000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.45,
        timeStamp: '01/01/2023 12:20:00'
    },
    {
        id: '00000000-0000-0000-0000-100000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.56,
        timeStamp: '01/01/2023 12:15:00'
    },
    {
        id: '00000000-0000-0000-0000-000000100002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.79,
        timeStamp: '01/01/2023 12:10:00'
    },
    {
        id: '00000000-0000-0000-0000-000010000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.65,
        timeStamp: '01/01/2023 12:05:00'
    },
    {
        id: '00000000-0000-0000-0000-000000100002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        masterNetworkId: '00000000-0000-0000-0000-000000000001',
        value: 25.76,
        timeStamp: '01/01/2023 12:00:00'
    },
]

export const predictsTemp: PredictDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000001',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        value: 23.89,
        timeStamp: '01/01/2023 13:25:00'
    },
    {
        id: '00000000-0000-0000-0000-000000000002',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        value: 24.2,
        timeStamp: '01/01/2023 13:20:00'
    },
    {
        id: '00000000-0000-0000-0000-000000000003',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        value: 24.13,
        timeStamp: '01/01/2023 13:15:00'
    },
    {
        id: '00000000-0000-0000-0000-000000000004',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        value: 24.14,
        timeStamp: '01/01/2023 13:10:00'
    },
    {
        id: '00000000-0000-0000-0000-000000000005',
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 0,
            longitude: 0,
            speed: 0,
            verticalAccuracy: 0,
        },
        depth: 1.33,
        fishTankId: '00000000-0000-0000-0000-000000000001',
        waterParamId: '00000000-0000-0000-0000-000000000001',
        value: 24.23,
        timeStamp: '01/01/2023 13:05:00'
    },
]

export const dpsTemp: DPSDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000001',
        url: 'https://aquaculture/dps/1',
        fishTankId: '00000000-0000-0000-0000-000000000001',
        duration: 600,
        location:
        {
            altitude: 0,
            course: 0,
            horizontalAccuracy: 0,
            latitude: 47.13,
            longitude: 39.43,
            speed: 0,
            verticalAccuracy: 0,
        },
        sensors:[
            {
                id: 0,
                charging: 0,
                depth: 1.3,
                place: 'INSIDE',
                status: 'DISABLE',
                waterParamId: '00000000-0000-0000-0000-000000000001',
            },
            {
                id: 1,
                charging: 0,
                depth: 1.324,
                place: 'INSIDE',
                status: 'DISABLE',
                waterParamId: '00000000-0000-0000-0000-000000000003',
            },
            {
                id: 2,
                charging: 0,
                depth: 1.4,
                place: 'OUTSIDE',
                status: 'DISABLE',
                waterParamId: '00000000-0000-0000-0000-000000000002',
            },
            {
                id: 3,
                charging: 0,
                depth: 1.4,
                place: 'OUTSIDE',
                status: 'DISABLE',
                waterParamId: '00000000-0000-0000-0000-000000000004',
            }
        ],
    },
]

export const pumpsTemp: PumpDto[] = [
    {
        id: '00000000-0000-0000-0000-000000000001',
        efficiency: 70,
        fishTankId: '00000000-0000-0000-0000-000000000000',
        model: 'Model_1',
        isEnable: false,
        operatingTime: '0.4:56:9'
    },
    {
        id: '00000000-0000-0000-0000-000000000002',
        efficiency: 120,
        fishTankId: '00000000-0000-0000-0000-000000000000',
        model: 'Model_2',
        isEnable: false,
        operatingTime: '7.16:25:43'
    },
]