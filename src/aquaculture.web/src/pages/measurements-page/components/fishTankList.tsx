import { Box, List, ListItem, ListItemButton, ListItemText } from "@mui/material";
import { FishTank } from "../types";
import { useState } from "react";

interface Props{
    fishTanks: FishTank[];
    setFishTank : React.Dispatch<React.SetStateAction<FishTank | undefined>>;
}

const FishTankList: React.FC<Props> = ({fishTanks, setFishTank}) => {
    const [selectedId, setSelectedId] = useState(fishTanks[0].id);

    const handleListItemClick = (
      event: React.MouseEvent<HTMLDivElement, MouseEvent>,
      fishTank: FishTank,
    ) => {
        setSelectedId(fishTank.id);
        setFishTank(fishTank);
    };

    return(
        <Box sx={{ width: '100%', maxWidth: 360, bgcolor: 'rgb(235, 204, 204)' }}>
            <nav aria-label="fish tanks">
                <List>
                    {fishTanks.map(ft => (
                        <ListItem disablePadding key={ft.id}>
                            <ListItemButton
                                selected={selectedId === ft.id}
                                onClick={(event) => handleListItemClick(event, ft)}
                            >
                                <ListItemText primary={ft.name} />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </List>
            </nav>
        </Box>
    );
}

export default FishTankList;