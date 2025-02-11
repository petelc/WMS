import {
  Box,
  Checkbox,
  FormControlLabel,
  Grid2,
  TextField,
  Typography,
} from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';

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
          <Box display='flex' flexDirection='row' gap={2} alignItems='center'>
            <Typography variant='h6'>Mandate By</Typography>
            <Typography variant='caption'>(Check all that apply)</Typography>
          </Box>
        </Grid2>
        <Grid2 size={12}>
          <Box display='flex' flexDirection='row' gap={2} sx={{ ml: 2 }}>
            <FormControlLabel
              control={<Checkbox />}
              label='Director'
              name='mandateBy'
            />
            <FormControlLabel
              control={<Checkbox />}
              label='Deputy Director'
              name='mandateBy'
            />
            <FormControlLabel
              control={<Checkbox />}
              label='Ohio Revised Code'
              name='mandateBy'
            />
            <FormControlLabel
              control={<Checkbox />}
              label='Agency Need'
              name='mandateBy'
            />
          </Box>
        </Grid2>
        <Grid2 size={{ xs: 6, sm: 6 }}>
          <TextField fullWidth label='Mandate Title' />
        </Grid2>
        <Grid2 size={{ xs: 6, sm: 2 }}>
          <TextField fullWidth label='ORC #' />
        </Grid2>
        <Grid2 size={{ xs: 6, sm: 4 }}>
          <DatePicker
            label='Compliance Date'
            slotProps={{ textField: { helperText: 'Required' } }}
          />
        </Grid2>
        <Grid2 size={12}>
          <TextField fullWidth label='Mandate Description' multiline rows={4} />
        </Grid2>
      </Grid2>
    </Box>
  );
}
