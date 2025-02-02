import { Box, Grid2, Typography } from '@mui/material';

export default function MandateForm() {
  return (
    <Box
      component='form'
      width='100%'
      display='flex'
      flexDirection='column'
      gap={3}
      marginY={3}
    >
      <Grid2 container spacing={2}>
        <Grid2 size={12}>
          <Typography variant='h6'>Mandate By</Typography>
          <Typography variant='caption'>(Check all that apply)</Typography>
        </Grid2>
      </Grid2>
    </Box>
  );
}
