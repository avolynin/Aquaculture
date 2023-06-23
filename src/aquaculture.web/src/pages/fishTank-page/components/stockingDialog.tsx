import { Dialog, DialogTitle, List, ListItem, ListItemButton, ListItemAvatar, Avatar, ListItemText, Box, TextField, Button, InputLabel, NativeSelect } from "@mui/material";
import { blue } from "@mui/material/colors";
import React from "react";

interface SimpleDialogProps {
    open: boolean;
    onClose: () => void;
  }

const StockingDialog: React.FC<SimpleDialogProps> = ({open, onClose}) => {
    const handleClose = () => {
    };

    const handleListItemClick = () => {
        onClose();
    };

    return (
        <Dialog onClose={handleClose} open={open} sx={{p: '15px'}}>
            <DialogTitle textAlign='center' fontSize='35px'>Создание нового вида рыбы</DialogTitle> 
        </Dialog>
    );
}

export default StockingDialog;