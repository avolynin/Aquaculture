import { AppBar, Box, Breadcrumbs, Button, Collapse, Divider, IconButton, Link, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Paper, Theme, ThemeProvider, Toolbar, Typography, createStyles, createTheme, makeStyles, styled } from "@mui/material";
import './main-page.css';
import HomeIcon from '@mui/icons-material/Home';
import TravelExploreIcon from '@mui/icons-material/TravelExplore';
import BarChartIcon from '@mui/icons-material/BarChart';
import SettingsIcon from '@mui/icons-material/Settings';
import DashboardIcon from '@mui/icons-material/Dashboard';
import MenuIcon from '@mui/icons-material/Menu';
import Avatar from '@mui/material/Avatar';
import SendIcon from '@mui/icons-material/Send';
import PersonIcon from '@mui/icons-material/Person';
import GroupIcon from '@mui/icons-material/Group';
import KeyboardArrowLeftIcon from '@mui/icons-material/KeyboardArrowLeft';
import { NavLink, Route, BrowserRouter, Routes, MemoryRouter, LinkProps, Link as RouterLink } from "react-router-dom";
import { useState } from "react";
import AuthPage from "../auth-page/auth-page";
import LibraryBooksRoundedIcon from '@mui/icons-material/LibraryBooksRounded';
import SetMealRoundedIcon from '@mui/icons-material/SetMealRounded';
import WaterRoundedIcon from '@mui/icons-material/WaterRounded';
import HomeRoundedIcon from '@mui/icons-material/HomeRounded';
import MeasurementsPage from "../measurements-page/measurements-page";
import CoronavirusIcon from '@mui/icons-material/Coronavirus';
import { ExpandLess, ExpandMore, StarBorder } from "@mui/icons-material";
import SideBar from "./components/sidebar";
import CssBaseline from '@mui/material/CssBaseline';
import DisplaySettingsIcon from '@mui/icons-material/DisplaySettings';
import { SideBarElement } from "./types";
import WaterParamPage from "../lib-pages/waterParam-page/waterParam-page";
import FishTypePage from "../lib-pages/fishType-page/fishType-page";
import DiseasePage from "../lib-pages/disease-page/disease-page";
import FishTankPage from "../fishTank-page/fishTank-page";
import DevicesPage from "../devices-page/devices-page";

export const navData: SideBarElement[] = [
    {
        id: 0,
        icon: <HomeRoundedIcon sx={{fontSize: "35px"}}/>,
        text: "Главная",
        link: "/",
        children: undefined
    },
    {
        id: 1,
        icon: <BarChartIcon sx={{fontSize: "35px"}}/>,
        text: "Измерения",
        link: "/measurements",
        children: undefined
    },
    {
        id: 3,
        icon: <DisplaySettingsIcon sx={{fontSize: "35px"}}/>,
        text: "Устройства",
        link: "/devices",
        children: undefined
    },
    {
        id: 2,
        icon: <LibraryBooksRoundedIcon sx={{fontSize: "35px"}}/>,
        text: "Библиотека",
        link: "/auth/login",
        children:
        [   
            {
                id: 201,
                icon: <SetMealRoundedIcon sx={{fontSize: "25px"}}/>,
                text: "Виды рыб",
                link: "/lib/fishTypes",
                children: undefined
            },
            {
                id: 202,
                icon: <WaterRoundedIcon sx={{fontSize: "25px"}}/>,
                text: "Параметры",
                link: "/lib/waterParams",
                children: undefined
            },
            {
                id: 203,
                icon: <CoronavirusIcon sx={{fontSize: "25px"}}/>,
                text: "Болезни",
                link: "/lib/diseases",
                children: undefined
            }
        ]
    }
]

const MainPage: React.FC = () => {
    const [navOpen , setNavOpen] = useState(true);
    const [open, setOpen] = useState<boolean[]>([false, false, false, false]);

    const handleClick = (event: React.MouseEvent<HTMLDivElement, MouseEvent>, id: number) => {
        let newState = [...open];
        newState[id] = !open[id];
        setOpen(newState);
        console.log(open);
    };
    const handleClickMenu = () => {
    setNavOpen(!navOpen);
    };

    return (
        <BrowserRouter>
        <Box sx={{ display: 'flex', width: '100%', height:'100%' }}>
            <CssBaseline />
            <AppBar position="fixed" sx={{zIndex: 1400}}>
            <Toolbar>
                <IconButton
                size="large"
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
                onClick={handleClickMenu}
                >
                <MenuIcon />
                </IconButton>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1, textAlign: 'center'}}>
                Аквакультура
                </Typography>
                <Button color="inherit">И.И.Иванов</Button>
            </Toolbar>
            </AppBar>
            <SideBar navOpen={navOpen} navData={navData}/>
            <Box component="main" sx={{ 
                paddingTop: 8+2, 
                paddingLeft: 2,
                paddingRight: 2,
                paddingBottom: 2,
                display: 'flex', 
                width: '100%', 
                height:'100vh'
            }}>
                 <Routes>
                     <Route path="/" element={<FishTankPage />} />
                     <Route path="/lib/fishTypes"element={<FishTypePage />} />
                     <Route path="/devices"element={<DevicesPage />} />
                     <Route path="/lib/waterParams"element={<WaterParamPage />} />
                     <Route path="/lib/diseases"element={<DiseasePage />} />
                     <Route path="/auth/login" element={<AuthPage />} />
                     <Route path="/measurements" element={<MeasurementsPage />} />
                 </Routes>
            </Box>
        </Box>
        </BrowserRouter>
    );
}

export default MainPage;