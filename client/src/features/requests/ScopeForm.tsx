import { Box, Grid2, Typography, TextField } from '@mui/material';

export default function ScopeForm() {
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
          <Box display='flex' flexDirection='row' gap={2} alignItems='center'>
            <Typography variant='subtitle1'>Project Scope</Typography>
          </Box>
        </Grid2>
        <Grid2 size={12}>
          <TextField
            fullWidth
            label='Objectives/Purpose: (what is to be accomplished and its benefits)'
            multiline
            rows={4}
          />
        </Grid2>
        <Grid2 size={12}>
          <TextField
            fullWidth
            label='Requirements: Specify what items and/or functionality is needed to fulfill the request (e.g. forms, buisiness flow, reports, data sharing, etc.)'
            multiline
            rows={4}
          />
        </Grid2>
        <Grid2 size={12}>
          <TextField
            fullWidth
            label='List resources and/or equipment needed (hardware, software, licenses, etc.)'
            multiline
            rows={4}
          />
        </Grid2>
      </Grid2>
    </Box>
  );
}
