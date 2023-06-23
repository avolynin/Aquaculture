import { Card, CardContent, CardActions, IconButton, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { SensorDto } from "../../../contracts";
import BatteryFullIcon from '@mui/icons-material/BatteryFull';
import { getWaterParam } from "../../../api";
import { useEffect, useState } from "react";

interface Props{
    sensor: SensorDto;
}

const SensorCard: React.FC<Props> = ({sensor}) => {
    const [waterParamName, setWaterParamName] = useState("-");

    async function fetchWaterParamName(){
        await getWaterParam(sensor.waterParamId).then(w => {
            if (w !== undefined) {
                setWaterParamName(w.name);
            }
        });
    }

    useEffect(() => {
        fetchWaterParamName();
    });  

    return (
        <Card sx={{ maxWidth: 225, maxHeight: 225, minWidth: 225, minHeight: 225, display: 'flex', margin: 2, flexDirection: 'column', p:0 }}>
            <CardContent sx={{height: '100%'}}>
            <Box 
                textAlign='center' 
                borderBottom='2px solid #dadada'
            >
                ID: {sensor.id}
            </Box>
            <Box sx={{display: 'flex', textAlign: 'left', flexDirection: 'column', height: '100%', marginTop: '5px'}}>
                <Typography>Уровень заряда: {sensor.charging}%</Typography>
                <Typography>Глубина: {sensor.depth}, м</Typography>
                <Typography>Положение: {sensor.place === 'INSIDE' ? 'Внутри' : 'Снаружи'}</Typography>
                <Typography>Состояние: {sensor.status === 'DISABLE' ? 'Выключен' : 'Снаружи'}</Typography>
                <Typography>Измеряемый параметр: {waterParamName}</Typography>
            </Box>
            </CardContent>
        </Card>
    );
}

export default SensorCard;