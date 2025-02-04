/* eslint-disable @typescript-eslint/no-empty-object-type */
import { useState } from 'react';
import { Autocomplete, Box, Grid2, TextField, Typography } from '@mui/material';
import AppNumberInput from '../../app/store/shared/components/appnumberinput/AppNumberInput';
import { JobTitleOptions, Titles } from '../../lib/titles';

export default function ImpactForm() {
  const [internal, setInternal] = useState<JobTitleOptions[]>([]);
  const [external, setExternal] = useState<JobTitleOptions[]>([]);

  const handleInternalChange = (
    _event: React.ChangeEvent<{}>,
    value: JobTitleOptions[]
  ): void => {
    setInternal(value);
  };

  const handleExternalChange = (
    _event: React.ChangeEvent<{}>,
    value: JobTitleOptions[]
  ): void => {
    setExternal(value);
  };

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
            <Typography variant='subtitle1'>Impact</Typography>
          </Box>
        </Grid2>
        <Grid2 size={12}>
          <Box display='flex' flexDirection='row' gap={2}>
            <AppNumberInput label='How many internal staff will be impacted?' />
            <AppNumberInput label='How many external staff will be impacted?' />
          </Box>
        </Grid2>
        <Grid2 size={{ xs: 6, sm: 6 }}>
          <Autocomplete
            multiple
            id='internal'
            options={Titles}
            getOptionLabel={(option) => option.title}
            value={internal}
            onChange={(event, value) => handleInternalChange(event, value)}
            filterSelectedOptions
            renderInput={(params) => (
              <TextField
                {...params}
                label='Identify the impacted internal users by job classification'
                placeholder='Job Titles'
              />
            )}
          />
        </Grid2>
        <Grid2 size={{ xs: 6, sm: 6 }}>
          <Autocomplete
            multiple
            id='external'
            options={Titles}
            getOptionLabel={(option) => option.title}
            value={external}
            onChange={(event, value) => handleExternalChange(event, value)}
            filterSelectedOptions
            renderInput={(params) => (
              <TextField
                {...params}
                label='Identify the impacted external users by job classification'
                placeholder='Job Titles'
              />
            )}
          />
        </Grid2>
        <Grid2 size={12}>
          <TextField
            fullWidth
            label='Explain if the project will create a new automation or correct a current system'
            multiline
            rows={4}
          />
        </Grid2>
        <Grid2 size={12}>
          <TextField
            fullWidth
            label='Explain if there is a cost saving (include a breakdown of the estimated amount)'
            multiline
            rows={4}
          />
        </Grid2>
      </Grid2>
    </Box>
  );
}
