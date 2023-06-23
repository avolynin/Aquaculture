import { MeasurementDto } from "./contracts"
import { dpsTemp, fishTanksTemp, fishTypesTemp, measurementsTemp, predictsTemp, pumpsTemp, waterParamsTemp } from "./tempContracts"

export const getMeasurements = async (fishTankId: string) => {
    return measurementsTemp.filter((elem) => elem.fishTankId === fishTankId)
}
export const getMeasurementsHandle = async (date: number) => {
    return measurementsTemp.filter((elem) => new Date(elem.timeStamp).getDay() === new Date(date).getDay() && elem.masterNetworkId === '00000000-0000-0000-0000-000000000000');
}

export const getPredicts = async (fishTankId: string) => {
    return predictsTemp.filter((elem) => elem.fishTankId === fishTankId)
}

export const getFishType = (id: string) => {
    return fishTypesTemp.find((elem) => elem.id === id)
}

export const getFishTypes = () => {
    return fishTypesTemp;
}

export const getMeasurementsPeriod = async (fishTankId: string, form: string, to: string) => {
    //return measurementsTemp.filter((elem) => elem.fishTankId === fishTankId)
    const response = await fetch(`api/measurement/${fishTankId}`, {
        method: "post",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ from: {form}, to: {to} })
    });
    const responseJson: MeasurementDto[] = await response.json();
    return responseJson;
}

export const getWaterParam = async (id: string) => {
    return waterParamsTemp.find((elem) => elem.id === id)
}

export const getWaterParams = () => {
    return waterParamsTemp;
}

export const getFishTanks = async () => {
    // const response = await fetch(`api/fishTanks`, {
    //     method: "get"
    // });
    // const responseJson: FishTankDto[] = await response.json();
    // return responseJson;
    return fishTanksTemp;
}

export const getFishTank = async (id: string) => {
    return fishTanksTemp.find((elem) => elem.id === id)
}

export const getPumps = async () => {
    return pumpsTemp;
}

export const getDps = async () => {
    return dpsTemp;
}