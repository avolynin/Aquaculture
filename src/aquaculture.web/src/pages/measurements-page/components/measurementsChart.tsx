import { useState } from "react";
import { MeasurementChartData, WaterMeasurement } from "../types";
import { CartesianGrid, Legend, Line, LineChart, Tooltip, XAxis, YAxis } from "recharts";

interface Props{
    data: WaterMeasurement[];
}

const MeasurementsChart: React.FC<Props> = ({data}) => {
    data?.sort(function(a, b): any{
        return (Date.parse(b.timeStamp) - Date.parse(a.timeStamp));
    });

    var chartsData = new Array();
    data?.forEach(function(item){
        chartsData.push({
            name: item.timeStamp, 
            temperature: item.waterParams.temperature,
            dissolvedOxygen: item.waterParams.dissolvedOxygen,
            acidity: item.waterParams.acidity,
            alkalinity: item.waterParams.alkalinity,
            carbonDioxide: item.waterParams.carbonDioxide,
            ammonia: item.waterParams.ammonia
        });
    });
    //setChartsData(tmp);

    return(
        <LineChart width={600} height={300} data={chartsData} >
            <Line type="monotone" dataKey="temperature" stroke="#E7C697" strokeWidth={3}/>
            <Line type="monotone" dataKey="dissolvedOxygen" stroke="#00382B" strokeWidth={3}/>
            <Line type="monotone" dataKey="acidity" stroke="#1CAC78" strokeWidth={3}/>
            <Line type="monotone" dataKey="alkalinity" stroke="#B44C43" strokeWidth={3}/>
            <Line type="monotone" dataKey="carbonDioxide" stroke="#6C7156" strokeWidth={3}/>
            <Line type="monotone" dataKey="ammonia" stroke="#FBA0E3" strokeWidth={3}/>
            
            <CartesianGrid stroke="#ccc" />
            <XAxis dataKey="name" />
            <YAxis />
            <Tooltip />
            <Legend />
        </LineChart>
    );
}

export default MeasurementsChart;