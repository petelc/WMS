import { Box } from '@mui/material';
import { SparkLineChart } from '@mui/x-charts';

export default function WorkChart() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <SparkLineChart
        plotType='bar'
        data={[1, 4, 2, 5, 7, 2, 4, 6]}
        height={100}
      />
    </Box>
  );
}
