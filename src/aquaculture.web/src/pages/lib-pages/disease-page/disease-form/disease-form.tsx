import { Card, CardActions, IconButton } from "@mui/material";
import { Box } from "@mui/system";
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { diseasesTemp } from "../../../../tempContracts";
import WaterParamCard from "../../waterParam-page/waterParam-form/components/waterParamCard";
import DiseaseCard from "./components/diseaseCard";

const DiseaseForm = () => {
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
            {diseasesTemp.map((data) => (<DiseaseCard diseaseDto={data}/>))}
        </Box>
    );
}

export default DiseaseForm;