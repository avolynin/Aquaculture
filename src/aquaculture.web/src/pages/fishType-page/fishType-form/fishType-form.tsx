import { Button, Card, CardActions, CardContent, IconButton, Typography } from "@mui/material";
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { Box } from "@mui/system";
import { FishTypeCardInfo } from "../../../contracts";
import FishTypeCard from "./components/fishTypeCard";

const fishTypes: FishTypeCardInfo[] = [
    {
        name: 'Малёк',
        code: '001',
        params: ['t', 'o2', 'am']
    },
    {
        name: 'Подрост',
        code: '002',
        params: ['t', 'o2']
    }
]

const FishTypeForm = () => {
    return(
        <Box sx={{p:0, flexDirection: 'row', display: 'flex' }}>
            <Card sx={{ minWidth: 200, minHeight: 200, display: 'flex', margin: 2 }}>
                <CardActions sx={{
                    justifyContent: 'center', 
                    alignItems: 'center', 
                    flexGrow: 1,
                }}>
                    <IconButton><AddCircleIcon style={{ fontSize: 40 }} /></IconButton>
                </CardActions>
            </Card>
            {fishTypes.map((data) => (<FishTypeCard fishTypeInfo={data}/>))}
        </Box>
    );
}

export default FishTypeForm;