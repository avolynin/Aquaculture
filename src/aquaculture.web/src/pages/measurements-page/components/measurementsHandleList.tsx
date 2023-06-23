import { useEffect, useState } from "react";
import { MeasurementDto } from "../../../contracts";
import { getMeasurementsHandle } from "../../../api";
import { Box } from "@mui/system";
import MeasurementHandleCard from "./measurementHandleCard";
import AddCircleSharpIcon from '@mui/icons-material/AddCircleSharp';
import { IconButton } from "@mui/material";

interface Props {
    date: number;
}

const MeasurementsHandleList: React.FC<Props> = ({ date }) => {
    const [measurements, setMeasurements] = useState<MeasurementDto[]>();

    const fetchData = async () => {
        setMeasurements(await getMeasurementsHandle(date));
    }

    useEffect(() => {
        console.log(date);
        fetchData();
    }, []);

    return(
    <Box sx={{flexFlow: 'row', display: 'flex'}}>
        <Box marginLeft='10px' marginRight='10px' alignSelf='center'>
        <IconButton color="primary" size="large">
            <AddCircleSharpIcon fontSize="large" />
        </IconButton> 
        </Box>
        <MeasurementHandleCard measurement={undefined} date={date} />
        {measurements?.map(m => (
            <MeasurementHandleCard measurement={m} date={undefined} />
        ))}
    </Box>
    );
}

export default MeasurementsHandleList;