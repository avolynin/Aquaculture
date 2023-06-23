import classNames from "classnames";
import MenuIcon from '@mui/icons-material/Menu';
import React, { useState } from "react";
import SendIcon from '@mui/icons-material/Send';
import DraftsIcon from '@mui/icons-material/Drafts';
import InboxIcon from '@mui/icons-material/Inbox';
import StarBorder from '@mui/icons-material/StarBorder';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import HomeRoundedIcon from '@mui/icons-material/HomeRounded';
import BarChartIcon from '@mui/icons-material/BarChart';
import LibraryBooksRoundedIcon from '@mui/icons-material/LibraryBooksRounded';
import SetMealRoundedIcon from '@mui/icons-material/SetMealRounded';
import WaterRoundedIcon from '@mui/icons-material/WaterRounded';
import { Box, display, height, minWidth } from "@mui/system";
import '../main-page.css'
import { AppBar, Button, Collapse, Divider, Drawer, IconButton, List, ListItem, ListItemButton, ListItemIcon, ListItemText, ListSubheader, Toolbar, Typography } from "@mui/material";
import { BrowserRouter, NavLink, Route, Routes } from "react-router-dom";
import AuthPage from "../../auth-page/auth-page";
import MeasurementsPage from "../../measurements-page/measurements-page";
import { SideBarElement } from "../types";

interface Props{
  navOpen: boolean;
  navData: SideBarElement[];
}

const SideBar: React.FC<Props> = ({navOpen, navData}) => {
  const [open, setOpen] = useState<boolean[]>([false, false, false, false]);

  const handleClick = (event: React.MouseEvent<HTMLDivElement, MouseEvent>, id: number) => {
    let newState = [...open];
    newState[id] = !open[id];
    setOpen(newState);
  };

  return (
    <Drawer open={navOpen} variant="permanent" sx={{ 
        flexShrink: 0, 
        width: !navOpen ? '67px' : '210px', 
        whiteSpace: 'nowrap',
        boxSizing: 'border-box',
      }}>
      <List
        sx={{ 
          bgcolor: '#1976d2', 
          paddingTop: 8,
          width: navOpen ? 210 : 'min-content', 
          color: 'white',
          height: '100vh',
        }}
        component="nav"
      >
        {navData.map(data => (
          <ListItem key={data.id} sx={{ display: 'block' }} disablePadding>
            {data.children !== undefined ? 
            (
            <div>
                <ListItemButton onClick={(event) => handleClick(event, data.id)}>
                  <ListItemIcon sx={{minWidth: !navOpen ? 0 : 35, color: 'white'}}>{data.icon}</ListItemIcon>
                  <ListItemText primary={data.text} sx={{ 
                    opacity: navOpen ? 1 : 0, 
                    display: navOpen ? 'block' : 'none',
                    marginLeft: 0.5
                  }}/>
                  {open[data.id] ? <ExpandLess /> : <ExpandMore sx={{ display: !navOpen ? 'none' : 'block'}} />}
                </ListItemButton>
                {data.children?.map(child => (
                    <Collapse in={open[data.id]} timeout="auto" unmountOnExit>
                        <List component="div" disablePadding>
                            <ListItemButton sx={{ pl: 4 }} component={NavLink} to={child.link}>
                              <ListItemIcon sx={{minWidth: 0, color: 'white'}}>{child.icon}</ListItemIcon>
                              <ListItemText 
                                primary={child.text}
                                sx={{ 
                                  opacity: navOpen ? 1 : 0, 
                                  display: navOpen ? 'block' : 'none',
                                  marginLeft: 0.5
                                }}
                              />
                            </ListItemButton>
                        </List>
                    </Collapse>
                ))}
            </div>
            ) 
            : 
            (
            <ListItemButton component={NavLink} to={data.link}>
              <ListItemIcon sx={{minWidth: !navOpen ? 0 : 35, color: 'white'}}>{data.icon}</ListItemIcon>
              <ListItemText 
                primary={data.text} 
                sx={{ 
                  opacity: navOpen ? 1 : 0, 
                  display: navOpen ? 'block' : 'none',
                  marginLeft: 0.5
                }}
              />
            </ListItemButton>
            )}
          </ListItem>
      ))}
      </List>
    </Drawer>
  );
};
export default SideBar;