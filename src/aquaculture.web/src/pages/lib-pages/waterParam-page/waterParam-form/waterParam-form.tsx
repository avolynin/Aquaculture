import { Button, Card, CardActions, CardContent, IconButton, Typography } from "@mui/material";
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { Box } from "@mui/system";
import WaterParamCard from "./components/waterParamCard";
import { fishTypesTemp, waterParamsTemp } from "../../../../tempContracts";

const WaterParamForm = () => {
    return(
        <Box sx={{p:0, flexDirection: 'row', display: 'flex' }}>
            <Card sx={{ minWidth: 225, minHeight: 225, display: 'flex', margin: 2 }}>
                <CardActions sx={{
                    justifyContent: 'center', 
                    alignItems: 'center', 
                    flexGrow: 1,
                }}>
                    <IconButton><AddCircleIcon style={{ fontSize: 40 }} /></IconButton>
                </CardActions>
            </Card>
            {waterParamsTemp.map((data) => (<WaterParamCard waterParamDto={data}/>))}
        </Box>
    );
}

export default WaterParamForm;