import { WaterMeasurement } from "../types";

interface Props{
    meansuremensts: WaterMeasurement[];
}

const MeasurementsList: React.FC<Props> = ({meansuremensts}) => {
    return(
        <ul>
            {meansuremensts?.map(m => (
                <li key={m.id}><b>{m.timeStamp} |</b> {m.waterParams.temperature} | {m.waterParams.acidity} | {m.waterParams.alkalinity} | {m.waterParams.ammonia} | {m.waterParams.carbonDioxide} | {m.waterParams.dissolvedOxygen};</li>
            ))}
        </ul>
    );
}

export default MeasurementsList;