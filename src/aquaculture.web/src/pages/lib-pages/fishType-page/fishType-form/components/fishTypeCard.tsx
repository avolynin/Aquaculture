import { Box, Card, CardActions, CardContent, CssBaseline, IconButton, Typography } from "@mui/material";
import { FishTypeDto, WaterParamDto } from "../../../../../contracts";
import BuildCircleIcon from '@mui/icons-material/BuildCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import InfoRoundedIcon from '@mui/icons-material/InfoRounded';
import { useEffect, useState } from "react";
import { waterParamsTemp } from "../../../../../tempContracts";

interface Props{
    fishTypeDto: FishTypeDto;
}

const FishTypeCard: React.FC<Props> = ({fishTypeDto}) => {
    const [ waterParams, setWaterParams ] = useState<WaterParamDto[] | undefined>(undefined);

    const getWaterParams = async () => {
        var waterParamIds = Array.from(fishTypeDto.tolerantParams.keys());
        var listOfWaterParams: WaterParamDto[] = [];
        waterParamIds.forEach(async paramId => {
            const response = await fetch(`api/waterWaterParam/measurement/${paramId}`, {
                     method: "get"
                });
            listOfWaterParams.push(await response.json());
        });
        setWaterParams(listOfWaterParams);
        console.log(waterParamsTemp);
    }

    useEffect(() => {
        //getWaterParams();
    }, [])

    return (
        <Card sx={{ maxWidth: 225, maxHeight: 225, minWidth: 225, minHeight: 225, display: 'flex', margin: 2, flexDirection: 'column', p:0 }}>
            <CardContent sx={{height: '100%'}}>
            <Typography variant="h6" color="black" display='inline'>
            🐟 <strong>{fishTypeDto.name} </strong>
            </Typography>
            <Typography sx={{ fontSize: 18 }} color="text.secondary" display='inline' gutterBottom>
            ({fishTypeDto.fishAge.name})
            </Typography>
            
            <Box textAlign='left' borderTop='2px solid #dadada' marginTop='2px' paddingTop='5px'>
                <Typography sx={{ fontSize: 16 }} color="black">
                    Вес: {fishTypeDto.weight}
                </Typography>
                <Typography sx={{ fontSize: 16 }} color="black" display='inline' gutterBottom>
                    Параметры:
                </Typography>
                <Typography sx={{ fontSize: 14 }} color="text.secondary" display='inline'>
                    {waterParamsTemp.map(param => (
                    param.name + ', '))}
                </Typography>
            </Box>
            </CardContent>
            <CardActions sx={{justifyContent: 'center'}}>
                <IconButton><InfoRoundedIcon /></IconButton>
                <IconButton><BuildCircleIcon /></IconButton>
                <IconButton><CancelIcon /></IconButton>
            </CardActions>
        </Card>
    );
}

export default FishTypeCard;