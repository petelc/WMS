import {
  Grid2,
  ListItemIcon,
  ListItemText,
  MenuItem,
  MenuList,
  Paper,
} from '@mui/material';
import { Link } from 'react-router-dom';
import BorderColorIcon from '@mui/icons-material/BorderColor';
import WorkspacesIcon from '@mui/icons-material/Workspaces';

import RequestChart from './charts/RequestChart';
import DivisionsChart from './charts/DivisionsChart';
import WorkChart from './charts/WorkChart';

export default function DashboardPage() {
  return (
    <Grid2 container spacing={0}>
      <Grid2 size={2}>
        <Paper sx={{ width: 220, maxWidth: '100%', height: '100vh', pt: 1 }}>
          <MenuList sx={{ mt: 3 }}>
            <MenuItem
              component={Link}
              to='/request'
              sx={{ textDecoration: 'none', color: 'inherit', pb: 2 }}
            >
              <ListItemIcon>
                <BorderColorIcon fontSize='small' />
              </ListItemIcon>
              <ListItemText>New Request</ListItemText>
            </MenuItem>
            <MenuItem
              component={Link}
              to='/my-work'
              sx={{ textDecoration: 'none', color: 'inherit', pb: 2 }}
            >
              <ListItemIcon>
                <WorkspacesIcon fontSize='small' />
              </ListItemIcon>
              <ListItemText>My Work</ListItemText>
            </MenuItem>
            <MenuItem
              component={Link}
              to='/team'
              sx={{ textDecoration: 'none', color: 'inherit', pb: 2 }}
            >
              <ListItemIcon>
                <WorkspacesIcon fontSize='small' />
              </ListItemIcon>
              <ListItemText>My Team</ListItemText>
            </MenuItem>
            <MenuItem
              component={Link}
              to='/my-teams-work'
              sx={{ textDecoration: 'none', color: 'inherit', pb: 2 }}
            >
              <ListItemIcon>
                <WorkspacesIcon fontSize='small' />
              </ListItemIcon>
              <ListItemText>My Teams Work</ListItemText>
            </MenuItem>
          </MenuList>
        </Paper>
      </Grid2>
      <Grid2 size={10}>
        <Paper sx={{ maxWidth: '100%', height: '100vh', pt: 1, pl: 2, pr: 2 }}>
          <h1>Dashboard</h1>
          <hr />

          <Grid2
            container
            direction='row'
            sx={{
              justifyContent: 'space-evenly',
              alignItems: 'top',
            }}
          >
            <RequestChart />
            <DivisionsChart />
            <WorkChart />
          </Grid2>
        </Paper>
      </Grid2>
    </Grid2>
  );
}
