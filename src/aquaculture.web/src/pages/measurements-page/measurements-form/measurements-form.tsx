import { useEffect, useState } from "react";
import MeasurementsList from "../components/measurementsList";
import { FishTank, WaterMeasurement } from "../types";
import MeasurementsChart from "../components/measurementsChart";
import FishTankList from "../components/fishTankList";

const MeasurementsForm = () => {
    const [ data, setData ] = useState<WaterMeasurement[] | undefined>(undefined);
    const [ fishTanks, setFishTanks ] = useState<FishTank[] | undefined>(undefined);
    const [ fishTank, setFishTank ] = useState<FishTank | undefined>(undefined);
    
    const search = () => {
        fetchData(fishTank!);
    };

    const fetchData = async (fishTank: FishTank) => {
        const response = await fetch(`api/water/measurement/${fishTank.id}`, {
            method: "get"
        });

        const responseJson: WaterMeasurement[] = await response.json();
        setData(responseJson);
    }

    const fetchFishTanks = async () => {
        const response = await fetch(`api/fishTanks`, {
            method: "get"
        });

        const responseJson: FishTank[] = await response.json();
        setFishTanks(responseJson);
    }

    useEffect(() => {
        fetchFishTanks();
    }, [])
    
    useEffect(() => {
        console.log('here')
        fishTank ? fetchData(fishTank) : console.log(fishTanks);
    }, [fishTank, fishTanks])

    return(
        <div className="measurements-form">
            <h1 id="title">Садки:</h1>
            {fishTanks ? (<FishTankList fishTanks={fishTanks} setFishTank={setFishTank}/>) : ("Loading...")}
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