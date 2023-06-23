import { Box, Card, CardActions, CardContent, CssBaseline, IconButton, Typography } from "@mui/material";
import BuildCircleIcon from '@mui/icons-material/BuildCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import InfoRoundedIcon from '@mui/icons-material/InfoRounded';
import { useEffect, useState } from "react";
import { waterParamsTemp } from "../../../../../tempContracts";
import { WaterParamDto } from "../../../../../contracts";

interface Props{
    waterParamDto: WaterParamDto;
}

const WaterParamCard: React.FC<Props> = ({waterParamDto}) => {
    return (
        <Card sx={{ maxWidth: 225, maxHeight: 225, minWidth: 225, minHeight: 225, display: 'flex', margin: 2, flexDirection: 'column', p:0 }}>
            <CardContent sx={{ height: '100%' }}>
            <Typography variant="h6" color="black" display='inline'>
            📊 <strong>{waterParamDto.name} </strong>
            </Typography>
            <Typography sx={{ fontSize: 18 }} color="text.secondary" gutterBottom>
            ({waterParamDto.unit})
            </Typography>

            </CardContent>
            <CardActions sx={{justifyContent: 'center'}}>
                <IconButton><BuildCircleIcon /></IconButton>
                <IconButton><CancelIcon /></IconButton>
            </CardActions>
        </Card>
    );
}

export default WaterParamCard;