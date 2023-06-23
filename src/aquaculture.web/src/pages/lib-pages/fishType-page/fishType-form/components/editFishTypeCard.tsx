import { Dialog, DialogTitle, List, ListItem, ListItemButton, ListItemAvatar, Avatar, ListItemText, Box, TextField, Button } from "@mui/material";
import { blue } from "@mui/material/colors";
import React from "react";

interface SimpleDialogProps {
    open: boolean;
    onClose: (value: string) => void;
  }

const EditFishTypeCard: React.FC<SimpleDialogProps> = ({open, onClose}) => {
    const handleClose = () => {
    };

    const handleListItemClick = (value: string) => {
        onClose(value);
    };

    return (
        <Dialog onClose={handleClose} open={open} sx={{p: '15px'}}>
            <DialogTitle>Создание нового вида рыбы</DialogTitle>
            <Box sx={{alignText: 'center', alignItems: 'center', flexDirection: 'column', display: 'flex'}}>
                Название: <TextField></TextField>
                Возраст: <TextField></TextField>
                Вес (кг): <TextField></TextField>
            </Box>
            <Box sx={{flexDirection: 'row', display: 'flex', alignContent: 'space-between', flexWrap: 'wrap', margin: '5px', flexFlow: 'column'}}>
            <Button variant="contained">Создать</Button>
            <Button variant="outlined">Назад</Button>
            </Box>
        </Dialog>
    );
}

export default EditFishTypeCard;