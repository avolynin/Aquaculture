import { useState } from "react";
import MeasurementsList from "../components/measurementsList";
import { WaterMeasurement } from "../types";
import MeasurementsChart from "../components/measurementsChart";

const MeasurementsForm = () => {
    const [ data, setData ] = useState<WaterMeasurement[] | undefined>(undefined);
    const [fishTankId, setfishTankId] = useState('');
    
    const search = () => {
        fetchData(fishTankId);
    };
    const inputHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        const enteredfishTankId = event.target.value;
        setfishTankId(enteredfishTankId);
      };

    const fetchData = async (fishTankId: string) => {
        const response = await fetch(`api/water/measurement/${fishTankId}`, {
            method: "get"
        });

        const responseJson: WaterMeasurement[] = await response.json();
        setData(responseJson);
    }
    
    return(
        <div className="measurements-form">
            <h1>Meansurements list of 3FA85F64-5717-4562-B3FC-2C963F66AFA6:</h1>
            <input
                value={fishTankId}
                onChange={inputHandler}
                placeholder="Search measurements"
                className="input"
            />

            <button onClick={search}>Search</button>
            <br/>
            {data ? (
                <>
                    <MeasurementsChart data={data} />
                    <br/>
                    Data:
                    <MeasurementsList meansuremensts={data} />
                </>
            ) : (
                "Loading..."
            )}
        </div>
    );
}

export default MeasurementsForm;