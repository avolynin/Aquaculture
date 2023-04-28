import { Box, Card, CardActions, CardContent, IconButton, Typography } from "@mui/material";
import { FishTypeCardInfo } from "../../../../contracts";
import BuildCircleIcon from '@mui/icons-material/BuildCircle';
import CancelIcon from '@mui/icons-material/Cancel';

interface Props{
    fishTypeInfo: FishTypeCardInfo;
}

const FishTypeCard: React.FC<Props> = ({fishTypeInfo}) => {
    return (
        <Card sx={{ minWidth: 200, minHeight: 200, display: 'flex', margin: 2, flexDirection: 'column', p:0 }}>
            <CardContent >
            <Typography sx={{ fontSize: 20 }} color="text.secondary" gutterBottom>
            🐟 <strong>{fishTypeInfo.name}</strong>
            </Typography>
            <Typography sx={{ fontSize: 16 }} color="text.secondary" gutterBottom>
            Код: {fishTypeInfo.code}
            </Typography>
            <Typography sx={{ fontSize: 16 }} color="text.secondary" gutterBottom>
            Параметры: {fishTypeInfo.params.map((p, i) => (<>{p}, </>))}
            </Typography>
            </CardContent>
            <CardActions>
                <IconButton><BuildCircleIcon /></IconButton>
                <IconButton><CancelIcon /></IconButton>
            </CardActions>
        </Card>
    );
}

export default FishTypeCard;