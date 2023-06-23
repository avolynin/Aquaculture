import { useEffect, useState } from "react";
import { getDps, getFishType, getPumps } from "../../../api";
import { DPSDto, PumpDto } from "../../../contracts";
import { Card, CardContent, Typography, CardActions } from "@mui/material";
import { Box } from "@mui/system";
import CustomizedMenus from "../../fishTank-page/components/actionMenus";
import PumpCard from "../components/pumpCard";
import DPSCard from "../components/DPSCard";
import DPSLine from "../components/DPSLine";

const DevicesForm = () => {
    const [pumps, setPumps] = useState<PumpDto[]>();
    const [dps, setDps] = useState<DPSDto[]>();

    async function fetchPumps(){
        await getPumps().then(pumps => setPumps(pumps));
    }

    async function fetchDps(){
        await getDps().then(dps => setDps(dps));
    }

    useEffect(() => {
        fetchPumps();
        fetchDps();
    });

    return(
        <div className="devices-form">
            <Box sx={{display: 'flex', flexDirection: 'column'}} p='10px'>
            <Typography variant="h5" textAlign='left'>Аэраторные насосы:</Typography>
            <Box sx={{display: 'flex', flexDirection: 'row'}}>
                {pumps?.map(p => (
                    <PumpCard pump={p} />
                ))}
            </Box>
            <Typography variant="h5" textAlign='left'>Станции обработки данных:</Typography>
            {dps?.map(d => (
                <DPSLine dps={d} />
            ))}
            </Box>
        </div>
    );
}

export default DevicesForm;