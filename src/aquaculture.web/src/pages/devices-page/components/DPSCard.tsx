import { Box, Card, CardActions, CardContent, CssBaseline, IconButton, Typography } from "@mui/material";
import BuildCircleIcon from '@mui/icons-material/BuildCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import InfoRoundedIcon from '@mui/icons-material/InfoRounded';
import UpdateIcon from '@mui/icons-material/Update';
import { useEffect, useState } from "react";
import { DPSDto, PumpDto } from "../../../contracts";
import { getFishTank } from "../../../api";

interface Props{
    dps: DPSDto;
}

const DPSCard: React.FC<Props> = ({dps}) => {
    const [fishTankName, setFishTankName] = useState("-");

    async function fetchFishTankName(){
        await getFishTank(dps.fishTankId).then(ft => {
            if (ft !== undefined) {
                setFishTankName(ft.name);
            }
        });
    }

    useEffect(() => {
        fetchFishTankName();
    }); 

    return (
        <Card sx={{ maxWidth: 300, maxHeight: 300, minWidth: 300, minHeight: 300, display: 'flex', margin: 2, flexDirection: 'column', p:0 }}>
            <CardContent sx={{height: '100%'}}>
            <Box textAlign='center' borderBottom='2px solid #dadada'>
                <strong>URL: {dps.url}</strong>
            </Box>
            <Box sx={{display: 'flex', textAlign: 'left', flexDirection: 'column', height: '100%'}}>
                <Typography>Период обновления данных: {dps.duration} секунд</Typography>
                <Typography>Прикреплен к садку: {fishTankName}</Typography>
                <Typography>(Долгота: {dps.location.longitude}, Широта: {dps.location.latitude})</Typography>
                <Typography>Кол-во датчиков: {dps.sensors.length + 1}</Typography>
            </Box>
            </CardContent>
            <CardActions sx={{justifyContent: 'center'}}>
                <IconButton><InfoRoundedIcon /></IconButton>
                <IconButton><UpdateIcon /></IconButton>
                <IconButton><BuildCircleIcon /></IconButton>
                <IconButton><CancelIcon /></IconButton>
            </CardActions>
        </Card>
    );
}

export default DPSCard;