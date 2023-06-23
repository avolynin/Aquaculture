import { Box, List, ListItem, ListItemButton, ListItemText } from "@mui/material";
import { FishTank } from "../types";
import { useState } from "react";
import { FishTankDto } from "../../../contracts";

interface Props{
    fishTanks: FishTankDto[];
    setFishTank : React.Dispatch<React.SetStateAction<FishTankDto | undefined>>;
}

const FishTankList: React.FC<Props> = ({fishTanks, setFishTank}) => {
    const [selectedId, setSelectedId] = useState(fishTanks[0].id);

    const handleListItemClick = (
      event: React.MouseEvent<HTMLDivElement, MouseEvent>,
      fishTank: FishTankDto,
    ) => {
        setSelectedId(fishTank.id);
        setFishTank(fishTank);
    };

    return(
        <Box sx={{ width: '100%', maxWidth: 360, bgcolor: '#eeee1' }}>
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