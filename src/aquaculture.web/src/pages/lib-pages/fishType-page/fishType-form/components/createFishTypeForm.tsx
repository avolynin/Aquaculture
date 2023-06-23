import { Dialog, DialogTitle, List, ListItem, ListItemButton, ListItemAvatar, Avatar, ListItemText, Box, TextField, Button, InputLabel, NativeSelect } from "@mui/material";
import { blue } from "@mui/material/colors";
import React from "react";
import { getWaterParams } from "../../../../../api";

interface SimpleDialogProps {
    open: boolean;
    onClose: () => void;
  }

const CreateFishTypeForm: React.FC<SimpleDialogProps> = ({open, onClose}) => {
    const handleClose = () => {
    };

    const handleListItemClick = () => {
        onClose();
    };

    return (
        <Dialog onClose={handleClose} open={open} sx={{p: '15px'}}>
            <DialogTitle textAlign='center' fontSize='35px'>Создание нового вида рыбы</DialogTitle>
            <Box sx={{flexDirection: 'row', display: 'flex', p: '15px'}}>
            <Box sx={{alignText: 'center', alignItems: 'center', flexDirection: 'column', display: 'flex'}}>
                Название: <TextField></TextField>
                Возраст: <TextField></TextField>
                Вес (кг): <TextField></TextField>
            </Box>
            <Box sx={{flexDirection: 'column', display: 'flex', alignText: 'center', alignItems: 'center', marginLeft: '10px'}}>
            Параметр водной среды
            <NativeSelect
                defaultValue={30}
                inputProps={{
                name: 'waterParam',
                id: 'uncontrolled-native',
                }}
            >
                {getWaterParams().map(wp => (
                    <option value={wp.id}>{wp.name} ({wp.unit})</option>
                ))}
            </NativeSelect>
            Критические параметры:
            <Box sx={{flexDirection: 'row', display: 'flex'}}>Макс.: <TextField></TextField> Мин.:<TextField></TextField></Box>
            Толерантные параметры:
            <Box sx={{flexDirection: 'row', display: 'flex'}}>Макс.: <TextField></TextField> Мин.:<TextField></TextField></Box>
            Комфортные параметры:
            <Box sx={{flexDirection: 'row', display: 'flex'}}>Макс.: <TextField></TextField> Мин.:<TextField></TextField></Box>
            </Box>
            </Box>
            <Box sx={{flexDirection: 'row', display: 'flex', alignContent: 'space-between', flexWrap: 'wrap', margin: '5px', flexFlow: 'column'}}>
            <Button variant="contained">Создать</Button>
            <Button variant="outlined" onClick={handleListItemClick}>Назад</Button>
            </Box>
        </Dialog>
    );
}

export default CreateFishTypeForm;