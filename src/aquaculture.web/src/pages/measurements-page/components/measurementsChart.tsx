import { useState } from "react";
import { MeasurementChartData, WaterMeasurement } from "../types";
import { CartesianGrid, Legend, Line, LineChart, ReferenceLine, Tooltip, XAxis, YAxis } from "recharts";
import { FishTypeDto, MeasurementDto, PredictDto } from "../../../contracts";

function FishTypeParams(fishType: FishTypeDto | undefined, waterParamId: string) {
    if(fishType !== undefined)
    {
    return <>
    <ReferenceLine y={fishType.comfortParams.get(waterParamId)?.maxValue} stroke="green" strokeWidth={2} />
    <ReferenceLine y={fishType.comfortParams.get(waterParamId)?.minValue} stroke="green" strokeWidth={2} />
    <ReferenceLine y={fishType.tolerantParams.get(waterParamId)?.maxValue} stroke="yellow" strokeWidth={2} />
    <ReferenceLine y={fishType.tolerantParams.get(waterParamId)?.minValue} stroke="yellow" strokeWidth={2} />
    <ReferenceLine y={fishType.criticalParams.get(waterParamId)?.maxValue} stroke="red" strokeWidth={2} />
    <ReferenceLine y={fishType.criticalParams.get(waterParamId)?.minValue} stroke="red" strokeWidth={2} />
    </>
    }
  }

interface Props{
    data: MeasurementDto[];
    predictData: PredictDto[];
    fishType: FishTypeDto | undefined;
}

const MeasurementsChart: React.FC<Props> = ({data, predictData, fishType}) => {
    data?.sort(function(a, b): any{
        return (Date.parse(b.timeStamp) - Date.parse(a.timeStamp));
    });
    const waterParamId = data[0].waterParamId;

    var chartsData = new Array();
    data?.forEach(function(item){
        chartsData.push({
            name: item.timeStamp.split(' ')[1],
            waterParam: item.waterParamId,
            value: item.value
        });
    });
    predictData?.forEach(function(item){
        chartsData.push({
            name: item.timeStamp.split(' ')[1],
            waterParam: item.waterParamId,
            predictValue: item.value
        });
    });

    return(
        <LineChart width={600} height={300} data={chartsData} >
            <CartesianGrid stroke="#ccc" />
            <XAxis dataKey="name" />
            <YAxis />
            {FishTypeParams(fishType, waterParamId)}

            <Line isAnimationActive={false} type="monotone" dataKey="predictValue" stroke="#42a4ff" strokeWidth={4} strokeDasharray="5 5" name="Прогноз"/>
            <Line isAnimationActive={false} type="monotone" dataKey="value" stroke="#000000" strokeWidth={4} name="Значение"/>
            <Tooltip />
            <Legend />
        </LineChart>
    );
}

export default MeasurementsChart;