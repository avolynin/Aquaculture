import { Button, Card, CardActions, CardContent, IconButton, Typography } from "@mui/material";
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { Box } from "@mui/system";
import FishTypeCard from "./components/fishTypeCard";
import { fishTypesTemp } from "../../../../tempContracts";
import { useState } from "react";
import CreateFishTypeForm from "./components/createFishTypeForm";

const FishTypeForm = () => {
    const [open, setOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
    };

    return(
        <Box sx={{ p:0, flexDirection: 'row', display: 'flex' }}>
            <Card sx={{ minWidth: 225, minHeight: 225, display: 'flex', margin: 2 }}>
                <CardActions sx={{
                    justifyContent: 'center', 
                    alignItems: 'center', 
                    flexGrow: 1,
                }}>
                    <IconButton onClick={handleClickOpen}><AddCircleIcon style={{ fontSize: 40 }} /></IconButton>
                </CardActions>
            </Card>
            {fishTypesTemp.map((data) => (<FishTypeCard fishTypeDto={data}/>))}
            <CreateFishTypeForm
                open={open}
                onClose={handleClose}
            />
        </Box>
    );
}

export default FishTypeForm;