import { useEffect, useState } from "react";
import MeasurementsList from "../components/measurementsList";
import { FishTank, WaterMeasurement } from "../types";
import MeasurementsChart from "../components/measurementsChart";
import FishTankList from "../components/fishTankList";
import { fishTanksTemp, fishTypesTemp, measurementsTemp } from "../../../tempContracts";
import { FishTankDto, FishTypeDto, MeasurementDto, PredictDto, WaterParamDto } from "../../../contracts";
import { Box, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, Typography } from "@mui/material";
import { Calendar, CalendarChangeEvent } from 'primereact/calendar';
import DatePicker from "react-datepicker"
import { ruRU } from '@mui/x-date-pickers/locales';
import dayjs, { Dayjs } from 'dayjs';
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import {ru} from 'date-fns/locale'
import { DateCalendar } from '@mui/x-date-pickers/DateCalendar';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider'
import { DesktopDatePicker, DesktopDateTimePicker } from "@mui/x-date-pickers";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { getFishTanks, getFishType, getFishTypes, getMeasurements, getPredicts, getWaterParam } from "../../../api";
import { uniqueFilter } from "../../../ex";
import MeasurementsHandleList from "../components/measurementsHandleList";

class MeasurementWaterParam {
    waterParamId: string;
    measurements: MeasurementDto[];
    predicts: PredictDto[];

    constructor(waterParamId: string, measurements: MeasurementDto[], predicts: PredictDto[]) {
        this.waterParamId = waterParamId;
        this.measurements = measurements;
        this.predicts = predicts;
    }
}

const russianLocale = ruRU.components.MuiLocalizationProvider.defaultProps.localeText;
const MeasurementsForm = () => {
    const currentDate = Date.now();
    const [dateValue, setDateValue] = useState<number | null>(currentDate);
    
    const [ data, setData ] = useState<WaterMeasurement[] | undefined>(undefined);
    const [ fishTanks, setFishTanks ] = useState<FishTankDto[] | undefined>(undefined);
    const [ measurementWaterParam, setMeasurementWaterParam] = useState<MeasurementWaterParam[]>([]);
    const [ fishTank, setFishTank ] = useState<FishTankDto | undefined>(undefined);
    const [ fishType, setFishType ] = useState<FishTypeDto | undefined>(undefined);
    const [ waterParams, setWaterParams ] = useState<WaterParamDto[]>([]);

    const handleChangeFishTank = (event: SelectChangeEvent) => {
        var ftTemp = fishTanksTemp.find(ft => ft.id === event.target.value);
        setFishTank(ftTemp);
      };

    const handleChangeFishType = (event: SelectChangeEvent) => {
    var ftTemp = getFishTypes().find(ft => ft.id === event.target.value);
    setFishType(ftTemp);
    };
    
    const search = () => {
        fetchData(fishTank!);
    };

    const fetchData = async (fishTank: FishTankDto) => {
        var measurements = await getMeasurements(fishTank.id);
        var predicts = await getPredicts(fishTank.id);
        var waterParamIds = measurements.map(m => m.waterParamId);
        var uniques = waterParamIds.filter(uniqueFilter);

        uniques.forEach(async wpId => {
            var m = measurements.filter(m => m.waterParamId === wpId);
            var p = predicts.filter(p => p.waterParamId === wpId);
            var tmp = measurementWaterParam;
            tmp?.push(new MeasurementWaterParam(wpId, m, p));
            setMeasurementWaterParam(tmp);

            var wp = await getWaterParam(wpId);
            if (wp !== undefined)
            {
                waterParams.push(wp);
            }
        });
    }

    const fetchFishTanks = async () => {
        setFishTanks(await getFishTanks());
    }

    useEffect(() => {
        fetchFishTanks();
    }, [])
    
    useEffect(() => {
        console.log('here')
        fishTank ? fetchData(fishTank) : console.log(fishTank);
    }, [fishTank, fishTanks])

    return(
        <Box paddingLeft='10px' paddingTop='5px'>
            <Box flexDirection='column' display='flex'>
                <Box flexDirection='row' minWidth='155px' marginRight='10px' display='flex' alignSelf='start'>
                <LocalizationProvider dateAdapter={AdapterDateFns} adapterLocale={ru} localeText={russianLocale}>
                    <DateCalendar
                        value={dateValue}
                        onChange={(newValue) => setDateValue(newValue)}
                        dayOfWeekFormatter={(day) => `${day}.`}
                    />
                </LocalizationProvider>
                <Box><MeasurementsHandleList date={dateValue!}/></Box>
                </Box>
                <Box flexDirection='row' display='flex' alignSelf='center'>
                <FormControl sx={{ m: 1, minWidth: 150 }}>
                    <InputLabel id="demo-simple-select-helper-label">☵ Садок</InputLabel>
                    <Select
                        labelId="demo-simple-select-helper-label"
                        id="demo-simple-select-helper"
                        value={fishTank ? fishTank.id : ""}
                        label="Садок"
                        onChange={handleChangeFishTank}
                        >
                        {fishTanksTemp.map(ft => (
                            <MenuItem value={ft.id}>{ft.name}</MenuItem>
                        ))}
                    </Select>
                </FormControl>
                <Box flexDirection='row' display='flex' alignSelf='center'>
                <LocalizationProvider dateAdapter={AdapterDateFns} adapterLocale={ru} localeText={russianLocale}>
                    <DesktopDatePicker label="📅 Начало измерений" defaultValue={currentDate}/>
                    <DesktopDatePicker label="📅 Конец измерений" defaultValue={currentDate}/>
                </LocalizationProvider>
                </Box>
                <FormControl sx={{ m: 1, minWidth: 180 }}>
                    <InputLabel id="demo-simple-select-helper-label">🐟 Вид рыбы</InputLabel>
                    <Select
                        labelId="demo-simple-select-helper-label"
                        id="demo-simple-select-helper"
                        value={fishType ? fishType.id : ' '}
                        label="Вид рыбы"
                        onChange={handleChangeFishType}
                        >
                        <MenuItem value=' '>Не выбран</MenuItem>
                        {fishTank?.fishInfos.map(fi => (
                            <MenuItem value={fi?.typeId}>{getFishType(fi.typeId)?.name} ({getFishType(fi.typeId)?.fishAge.name})</MenuItem>
                        ))}
                    </Select>
                </FormControl>
                </Box>
            </Box>
            <br/>
            {true ? (
                measurementWaterParam.map(mwp => (
                    <Box flexDirection='column' borderBottom='5px solid #11111111'>
                        <Typography variant="h4" textAlign='center'>📊{waterParams.find(wps => wps.id === mwp.waterParamId)?.name} ({waterParams.find(wps => wps.id === mwp.waterParamId)?.unit})</Typography>
                        <Box flexDirection='row' display='flex' paddingRight="40px">
                            <MeasurementsChart data={mwp.measurements} predictData={mwp.predicts} fishType={fishType} />
                            <Box marginRight="15px"></Box>
                            <MeasurementsList data={mwp.measurements} />
                        </Box>
                    </Box>
                ))
            ) : (
                "Loading..."
            )}
        </Box>
    );
}

export default MeasurementsForm;