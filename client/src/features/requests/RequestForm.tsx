import { Cyclone } from '@mui/icons-material';
import {
  Box,
  Button,
  Container,
  Grid2,
  Paper,
  TextField,
  Typography,
} from '@mui/material';
// import { useForm } from 'react-hook-form';

export default function RequestForm() {
  //const { register, handleSubmit } = useForm();
  return (
    <Container component={Paper} maxWidth='lg' sx={{ borderRadius: 2 }}>
      <Box
        display='flex'
        flexDirection='column'
        alignItems='center'
        marginTop='8'
      >
        <Cyclone sx={{ mt: 3, mb: 2, color: 'secondary.main', fontSize: 40 }} />
        <Typography variant='h5' gutterBottom>
          Submit a New Request
        </Typography>
        <Box
          component='form'
          width='100%'
          display='flex'
          flexDirection='column'
          gap={3}
          marginY={3}
        >
          <Grid2 container spacing={2}>
            <Grid2 size={{ xs: 6, md: 8 }}>
              <TextField fullWidth label='Title' />
            </Grid2>
            <Grid2 size={{ xs: 6, md: 4 }}>
              <TextField fullWidth label='Request Date' />
            </Grid2>
            <Grid2 size={12}>
              <TextField fullWidth label='Description' multiline rows={4} />
            </Grid2>
            <Grid2 size={{ xs: 12 }}>
              <Box
                display='flex'
                flexDirection='row'
                justifyContent='end'
                gap={2}
              >
                <Button
                  variant='contained'
                  color='primary'
                  type='submit'
                  // disabled={isLoading || !isValid}
                >
                  Submit Request
                </Button>
                <Button
                  variant='contained'
                  color='error'
                  type='submit'
                  // disabled={isLoading || !isValid}
                >
                  Cancel
                </Button>
              </Box>
            </Grid2>
          </Grid2>
        </Box>
      </Box>
    </Container>
  );
}
