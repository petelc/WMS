import { Navigation } from '@toolpad/core/AppProvider';
import DashboardIcon from '@mui/icons-material/Dashboard';

export const NAVIGATION: Navigation = [
  { segment: 'inbox', title: 'Inbox' },
  {
    segment: 'inbox/all',
    title: 'All',
    icon: <DashboardIcon />,
  },
];
