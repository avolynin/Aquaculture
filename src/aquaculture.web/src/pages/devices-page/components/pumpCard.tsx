import { Box, Card, CardActions, CardContent, CssBaseline, FormControl, IconButton, InputLabel, MenuItem, Select, SelectChangeEvent, Switch, Typography } from "@mui/material";
import BuildCircleIcon from '@mui/icons-material/BuildCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import InfoRoundedIcon from '@mui/icons-material/InfoRounded';
import { useEffect, useState } from "react";
import { FishTankDto, PumpDto } from "../../../contracts";
import { getFishTank, getFishTanks } from "../../../api";

interface Props{
    pump: PumpDto;
}

const PumpCard: React.FC<Props> = ({pump}) => {
    const [checked, setChecked] = useState(pump.isEnable);
    const [fishTankName, setFishTankName] = useState("-");
    const [fishTanks, setFishTanks] = useState<FishTankDto[]>([]);
    const [selectedFishTank, setSelectedFishTank] = useState<string>('-');

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setChecked(event.target.checked);
    };

    const handleChangeFishTank = (event: SelectChangeEvent) => {
        setSelectedFishTank(event.target.value as string);
    };

    const formOperatingTime = (dateTime: string) => {
        var tmp = dateTime.split('.');
        var time = tmp[1].split(':');
        return tmp[0] + ' дней, ' + time[0] + ' часов и ' + time[1] + ' минут';
    }

    async function fetchFishTankName(){
        await getFishTank(pump.fishTankId).then(ft => {
            if (ft !== undefined) {
                setFishTankName(ft.name);
            }
        });
    }

    async function fetchFishTanks(){
        await getFishTanks().then(ft => {
            setFishTanks(ft);
        });
    }

    useEffect(() => {
        fetchFishTankName();
        fetchFishTanks();
    });  

    return (
        <Card sx={{ maxWidth: 300, maxHeight: 300, minWidth: 300, minHeight: 300, display: 'flex', margin: 2, flexDirection: 'column', p:0 }}>
            <Box textAlign='center' borderBottom='2px solid #dadada' marginTop='2px' paddingTop='5px' fontSize='24px'>
                <strong>{pump.model}</strong>
            </Box>
            <CardContent sx={{height: '100%'}}>
            <Box sx={{display: 'flex', textAlign: 'left', flexDirection: 'column', height: '60%'}}>
                <Typography>Мощность: {pump.efficiency} кВт</Typography>
                <Typography>Отработанное время: {formOperatingTime(pump.operatingTime)}</Typography>
            </Box>
            <Box sx={{display: 'flex', flexDirection: 'row', alignItems: 'center', justifyContent: 'center'}}>
                    <Typography><strong>Прикрепить к садку:</strong></Typography>
                    <FormControl sx={{ m: 1, minWidth: 80 }} size="small">
                    <InputLabel id="demo-select-small-label">Садок</InputLabel>
                    <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={selectedFishTank}
                    label="Садок"
                    onChange={handleChangeFishTank}
                    >
                        {fishTanks.map(ft => (
                            <MenuItem value={ft.id}>{ft.name}</MenuItem>
                        ))}
                    </Select>
                    </FormControl>
                </Box>
            <Box sx={{display: 'flex', flexDirection: 'row', alignItems: 'center', justifyContent: 'center'}}>
                <Typography><strong>Выключить</strong></Typography>
                <Switch
                checked={checked}
                onChange={handleChange}
                inputProps={{ 'aria-label': 'controlled' }}
                />
                <Typography><strong>Включить</strong></Typography>
            </Box>
            </CardContent>
            <CardActions sx={{justifyContent: 'center', marginTop: '10px'}}>
                <IconButton><InfoRoundedIcon /></IconButton>
                <IconButton><BuildCircleIcon /></IconButton>
                <IconButton><CancelIcon /></IconButton>
            </CardActions>
        </Card>
    );
}

export default PumpCard;