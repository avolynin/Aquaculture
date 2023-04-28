import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { WaterMeasurement } from "../types";

interface Props{
    meansuremensts: WaterMeasurement[];
}

const MeasurementsList: React.FC<Props> = ({meansuremensts}) => {
    return(
        <TableContainer>
            <Table sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                <TableHead>
                    <TableRow>
                        <TableCell>Дата и время замера воды</TableCell>
                        <TableCell align="right">Температура&nbsp;(&deg;C)</TableCell>
                        <TableCell align="right">Раств. Килсород&nbsp;(мг/л)</TableCell>
                        <TableCell align="right">Щелочность&nbsp;(мг/л)</TableCell>
                        <TableCell align="right">Кислотность&nbsp;(моль/л)</TableCell>
                        <TableCell align="right">Углекислый газ&nbsp;(мг/литр)</TableCell>
                        <TableCell align="right">Аммоний&nbsp;(мг/дм3)</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {meansuremensts?.map(m => (
                        <TableRow
                            key={m.timeStamp}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <TableCell component="th" scope="row">{m.timeStamp}</TableCell>
                            <TableCell align="right">{m.waterParams.temperature}</TableCell>
                            <TableCell align="right">{m.waterParams.dissolvedOxygen}</TableCell>
                            <TableCell align="right">{m.waterParams.acidity}</TableCell>
                            <TableCell align="right">{m.waterParams.alkalinity}</TableCell>
                            <TableCell align="right">{m.waterParams.carbonDioxide}</TableCell>
                            <TableCell align="right">{m.waterParams.ammonia}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}

export default MeasurementsList;