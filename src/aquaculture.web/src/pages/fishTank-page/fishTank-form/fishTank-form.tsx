import { Box, Card, CardActions, CardContent, Paper, Typography } from "@mui/material";
import { FishTankDto } from "../../../contracts";
import { getFishType } from "../../../api";
import CustomizedMenus from "../components/actionMenus";

interface Props{
    fishTanks: FishTankDto[]
}

const FishTankForm: React.FC<Props> = ({fishTanks}) => {
    return(
        <div className="fishTank-form">
            <Box sx={{display: 'flex'}} p='10px'>
            {fishTanks.map(ft => (
                <Card sx={{width: 350, height: 300, marginRight: '10px', p: '5px', display: 'flex', flexDirection: 'column'}}>
                    <CardContent sx={{ height: '100%' }}>
                    <Typography variant="h4">{ft.name}</Typography>
                    <Typography textAlign='left'>Объем: {ft.volume} м³.</Typography>
                    <Typography textAlign='left'>(Долгота: {ft.location.longitude}, Широта: {ft.location.latitude}).</Typography>
                    <Typography textAlign='left'>Связь с мастером сети: {ft.masterNetworkId === '' ? 'Отсутствует' : 'Есть'}.</Typography>
                    <Typography textAlign='left'>Виды рыб: {ft.fishInfos.length === 0 ? 'Нет информации' : ''}</Typography>
                    {ft.fishInfos.map(fi => (
                        <Typography textAlign='left'>🐟 {getFishType(fi.typeId)?.name}({getFishType(fi.typeId)?.fishAge.name}): {fi.numberFish} особей.</Typography>
                    ))}
                    </CardContent>
                    <CardActions sx={{justifyContent: 'center'}}>    
                        {CustomizedMenus()}
                    </CardActions>
                </Card>
            ))}
            </Box>
        </div>
    );
}

export default FishTankForm;