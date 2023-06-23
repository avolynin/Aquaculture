import { Box, Card, CardActions, CardContent, CssBaseline, IconButton, Typography } from "@mui/material";
import BuildCircleIcon from '@mui/icons-material/BuildCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import InfoRoundedIcon from '@mui/icons-material/InfoRounded';
import { useEffect, useState } from "react";
import { DPSDto, PumpDto } from "../../../contracts";
import DPSCard from "./DPSCard";
import SensorCard from "./sensorCard";

interface Props{
    dps: DPSDto;
}

const DPSLine: React.FC<Props> = ({dps}) => {
    return (
        <Box sx={{display: 'flex', flexDirection: 'row', background: '#808080', alignItems: 'center'}}>
            <DPSCard dps={dps} />
            <Box sx={{overflowX: 'scroll', display: 'flex', flexDirection: 'row'}}>
                {dps.sensors.map(s => (
                    <SensorCard sensor={s}/>
                ))}
                {dps.sensors.map(s => (
                    <SensorCard sensor={s}/>
                ))}
            </Box>
        </Box>
    );
}

export default DPSLine;