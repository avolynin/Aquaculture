import { Card, CardActions, IconButton, Menu, MenuProps, TextField } from "@mui/material"
import { FC, useEffect, useState } from "react";
import { FishTankDto, MeasurementDto, WaterParamDto } from "../../../contracts";
import { Box, alpha, styled } from "@mui/system";
import { makeStyles } from '@mui/material/styles';
import { getFishTank, getFishTanks, getWaterParam } from "../../../api";
import SaveIcon from '@mui/icons-material/Save';
import DeleteIcon from '@mui/icons-material/Delete';

const StyledMenu = styled((props: MenuProps) => (
    <Menu
      elevation={0}
      anchorOrigin={{
        vertical: 'bottom',
        horizontal: 'right',
      }}
      transformOrigin={{
        vertical: 'top',
        horizontal: 'right',
      }}
      {...props}
    />
  ))(({ theme }) => ({
    '& .MuiPaper-root': {
      borderRadius: 6,
      marginTop: theme.spacing(1),
      minWidth: 180,
      color:
        theme.palette.mode === 'light' ? 'rgb(55, 65, 81)' : theme.palette.grey[300],
      boxShadow:
        'rgb(255, 255, 255) 0px 0px 0px 0px, rgba(0, 0, 0, 0.05) 0px 0px 0px 1px, rgba(0, 0, 0, 0.1) 0px 10px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px',
      '& .MuiMenu-list': {
        padding: '4px 0',
      },
      '& .MuiMenuItem-root': {
        '& .MuiSvgIcon-root': {
          fontSize: 18,
          color: theme.palette.text.secondary,
          marginRight: theme.spacing(1.5),
        },
        '&:active': {
          backgroundColor: alpha(
            theme.palette.primary.main,
            theme.palette.action.selectedOpacity,
          ),
        },
      },
    },
  }));

interface Props {
    measurement: MeasurementDto | undefined;
    date: number | undefined;
}

const MeasurementHandleCard: React.FC<Props> = ({ measurement, date }) => 
{
    const [fishTanks, setFishTanks] = useState<FishTankDto[] | undefined>([]);
    const [fishTank, setFishTank] = useState<FishTankDto>();
    const [waterParam, setWaterParam] = useState<WaterParamDto | undefined>(undefined);

    if(measurement === undefined){
        measurement = {
            id: '',
            depth: 0,
            fishTankId: '',
            masterNetworkId: '',
            waterParamId: '',
            timeStamp: '',
            value: 0,
            location:{
                altitude: 0,
                course: 0,
                horizontalAccuracy: 0,
                latitude: 0, 
                longitude: 0,
                speed: 0,
                verticalAccuracy: 0
            }
        }
    }

    async function fetchWaterParam(){
      await getWaterParam(measurement!.waterParamId).then(w => {
          setWaterParam(w);
      });
  }

    useEffect(() => {
    const fetchData = async () => {
        await getFishTank(measurement!.waterParamId).then(v => {
            setFishTank(v);
        });
        console.log('ft1: ' + measurement!.fishTankId);
        console.log('ft: ' + fishTank);
    }

      fetchData();
      fetchWaterParam();
    }, [])

    return(
    <Card style={{backgroundColor: date === undefined ? 'white' : '#F5F5F5'}} sx={{minWidth: '270px', minHeight: '270px', height: '270px', width: '270px', p: '10px', marginRight: '10px', flexFlow: 'column'}}>
        <Box sx={{display: 'flex', flexFlow: 'row', marginBottom: '15px'}}>
        <TextField id="outlined-basic" label="Дата" variant="outlined" sx={{marginRight: '5px'}} defaultValue={date ? new Date(date).toLocaleDateString() : new Date(measurement.timeStamp).toLocaleDateString()}/>
        <TextField id="outlined-basic" label="Время" variant="outlined" defaultValue={date ? new Date(date).toLocaleTimeString() : new Date(measurement.timeStamp).toLocaleTimeString()}/>
        </Box>
        <Box sx={{display: 'flex', flexFlow: 'row', marginBottom: '15px'}}>
        <TextField id="outlined-basic" label={"Значение"+ (waterParam ?(" (" + waterParam?.unit + ")") : "")} sx={{marginRight: '5px'}} variant="outlined" defaultValue={measurement!.value}/>
        <TextField id="outlined-basic" label="Параметр" variant="outlined" defaultValue={waterParam?.name}/>
        </Box>
        <Box sx={{display: 'flex', flexFlow: 'row'}}>
        <TextField id="outlined-basic" label="Глубина (м)" variant="outlined" defaultValue={measurement!.depth} sx={{marginRight: '5px'}}/>
        <TextField id="outlined-basic" label="Садок" variant="outlined" defaultValue={fishTank ? fishTank.name : 'f'}/>
        </Box>
        <CardActions sx={{justifyContent: 'center', placeContent: 'space-evenly'}}>
            <IconButton color='default' size="large"><SaveIcon fontSize="large" /></IconButton>
            <IconButton color='primary' size="large"><DeleteIcon fontSize="large" /></IconButton>
        </CardActions>
    </Card>
    );
}

export default MeasurementHandleCard;