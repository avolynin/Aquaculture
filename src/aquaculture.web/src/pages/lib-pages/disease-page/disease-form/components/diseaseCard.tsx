import { Box, Card, CardActions, CardContent, CssBaseline, IconButton, Typography, makeStyles } from "@mui/material";
import BuildCircleIcon from '@mui/icons-material/BuildCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import InfoRoundedIcon from '@mui/icons-material/InfoRounded';
import { useEffect, useState } from "react";
import { waterParamsTemp } from "../../../../../tempContracts";
import { DiseaseDto, WaterParamDto } from "../../../../../contracts";
import { display } from "@mui/system";

interface Props{
    diseaseDto: DiseaseDto;
}

const DiseaseCard: React.FC<Props> = ({diseaseDto}) => {
    return (
        <Card sx={{ maxWidth: 225, maxHeight: 225, minWidth: 225, minHeight: 225, display: 'flex', margin: 2, flexDirection: 'column', p:0 }}>
            <CardContent sx={{ height: '100%' }}>
            <Typography variant="h6" color="black" display='inline'>
            🧫 <strong>{diseaseDto.name} </strong>
            </Typography>
            <Box textAlign='left' borderTop='2px solid #dadada' marginTop='2px' paddingTop='5px'>
                <Typography sx={{ fontSize: 16 }} color="black" display='inline' gutterBottom>
                    Описание:
                </Typography>
                {/* <Typography sx={{ fontSize: 14 }} color="text.secondary" display='inline' noWrap gutterBottom>
                    {diseaseDto.description ?? 'Отсутсвтует'}
                </Typography> */}
                {/* <div className='display=inline '>
                    {diseaseDto.description ?? 'Отсутсвтует'}
                </div> */}
            </Box>
            <Typography noWrap gutterBottom sx={{ fontSize: 14 }}>
            {diseaseDto.description ?? 'Отсутсвтует'}
        </Typography>

            </CardContent>
            <CardActions sx={{justifyContent: 'center'}}>
                <IconButton><InfoRoundedIcon /></IconButton>
                <IconButton><BuildCircleIcon /></IconButton>
                <IconButton><CancelIcon /></IconButton>
            </CardActions>
        </Card>
    );
}

export default DiseaseCard;