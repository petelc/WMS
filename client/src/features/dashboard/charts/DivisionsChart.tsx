import {
  Card,
  CardHeader,
  Avatar,
  IconButton,
  CardMedia,
  CardContent,
  Typography,
  CardActions,
} from '@mui/material';
import RefreshRounded from '@mui/icons-material/RefreshRounded';
import ShareIcon from '@mui/icons-material/Share';
import BorderColorIcon from '@mui/icons-material/BorderColor';
import { PieChart } from '@mui/x-charts/PieChart';
import { blueGrey } from '@mui/material/colors';

import {
  desktopOS,
  valueFormatter,
} from '../../../lib/settings/pieChartSettings';

export default function DivisionsChart() {
  return (
    <Card sx={{ maxWidth: 400 }}>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: blueGrey[500] }}>
            <BorderColorIcon fontSize='small' />
          </Avatar>
        }
        action={<IconButton aria-label='settings'></IconButton>}
        title='Divisions'
        subheader='Last 30 days'
      />
      <CardMedia sx={{ p: 2 }}>
        <PieChart
          series={[
            {
              data: desktopOS,
              highlightScope: { fade: 'global', highlight: 'item' },
              faded: { innerRadius: 30, additionalRadius: -30, color: 'gray' },
              valueFormatter,
            },
          ]}
          height={200}
        />
      </CardMedia>
      <CardContent>
        <Typography variant='body2' sx={{ color: 'text.secondary' }}>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do
          eiusmod tempor incididunt ut labore et dolore magna aliqua.
        </Typography>
      </CardContent>
      <CardActions disableSpacing>
        <IconButton aria-label='refresh'>
          <RefreshRounded />
        </IconButton>
        <IconButton aria-label='share'>
          <ShareIcon />
        </IconButton>
      </CardActions>
    </Card>
  );
}
