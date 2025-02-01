import DeleteIcon from '@mui/icons-material/Delete';
import {
  Box,
  Button,
  Divider,
  FormControl,
  FormControlLabel,
  FormLabel,
  Grid2,
  IconButton,
  List,
  ListItem,
  ListItemText,
  Radio,
  RadioGroup,
  TextField,
  Typography,
} from '@mui/material';
import { useState } from 'react';
// import { useForm } from 'react-hook-form';

export default function RequestForm() {
  const [value, setValue] = useState('');
  const [policy, setPolicy] = useState(['01-COM-01']);
  const [project, setProject] = useState(['Project 1']);

  // ? Form Action Functions
  const handleOnChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setValue(event.target.value);
  };

  const handleAddPolicy = () => {
    setPolicy((prev) => [...prev, 'Policy 1']);
  };

  const handleAddProject = () => {
    setProject((prev) => [...prev, 'Project 2']);
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
        <Grid2 size={{ xs: 6, md: 8 }}>
          <TextField fullWidth label='Title' />
        </Grid2>
        <Grid2 size={{ xs: 6, md: 4 }}>
          <TextField fullWidth label='Project #' disabled />
        </Grid2>
        <Grid2 size={{ xs: 6, md: 6 }}>
          <TextField fullWidth label='Requested By' />
        </Grid2>
        <Grid2 size={{ xs: 6, md: 2 }}>
          <TextField fullWidth label='Department' />
        </Grid2>
        <Grid2 size={{ xs: 6, md: 4 }}>
          <TextField fullWidth label='Request Date' />
        </Grid2>
        <Grid2 size={12}>
          <TextField fullWidth label='Description' multiline rows={4} />
        </Grid2>
        <Grid2 size={12}>
          <Divider variant='middle' sx={{ mt: 4, mb: 4 }} />
        </Grid2>

        <Grid2 size={{ xs: 6, md: 4 }}>
          <FormControl id='requestTypeGroup'>
            <FormLabel component='legend'>Request Type</FormLabel>
            <RadioGroup
              name='requestTypeGroup'
              value={value}
              onChange={handleOnChange}
              row
            >
              <FormControlLabel
                value='1'
                control={<Radio />}
                label='New Request'
              />
              <FormControlLabel
                value='2'
                control={<Radio />}
                label='Change Request'
              />
            </RadioGroup>
          </FormControl>
        </Grid2>
        <Grid2 size={{ xs: 6, md: 4 }}>
          <FormControl id='stakeHolderGroup'>
            <FormLabel component='legend'>
              Have stakeholders conferred on this project?
            </FormLabel>
            <RadioGroup
              name='stakeHolderGroup'
              value={value}
              onChange={handleOnChange}
              row
            >
              <FormControlLabel value='1' control={<Radio />} label='Yes' />
              <FormControlLabel value='2' control={<Radio />} label='No' />
            </RadioGroup>
          </FormControl>
        </Grid2>
        <Grid2 container size={12} spacing={8} sx={{ mt: 4 }}>
          <Grid2 size={{ xs: 6, md: 4 }}>
            <Typography variant='subtitle1' gutterBottom>
              List any DRC Policies that apply
            </Typography>
            <Box display='flex' flexDirection='column' gap={2}>
              <Box display='flex' flexDirection='row' gap={2}>
                <TextField label='Policy' />
                <Button variant='contained' onClick={handleAddPolicy}>
                  Add
                </Button>
              </Box>
              <List>
                {policy.map((item, index) => (
                  <ListItem
                    key={index}
                    secondaryAction={
                      <IconButton edge='end' aria-label='delete'>
                        <DeleteIcon />
                      </IconButton>
                    }
                  >
                    <ListItemText primary={item} />
                  </ListItem>
                ))}
              </List>
            </Box>
          </Grid2>
          <Grid2 size={{ xs: 6, md: 4 }}>
            <Typography variant='subtitle1' gutterBottom>
              List any related projects
            </Typography>
            <Box display='flex' flexDirection='column' gap={2}>
              <Box display='flex' flexDirection='row' gap={2}>
                <TextField label='Related Projects' />
                <Button variant='contained' onClick={handleAddProject}>
                  Add
                </Button>
              </Box>
              <List>
                {project.map((item, index) => (
                  <ListItem
                    key={index}
                    secondaryAction={
                      <IconButton edge='end' aria-label='delete'>
                        <DeleteIcon />
                      </IconButton>
                    }
                  >
                    <ListItemText primary={item} />
                  </ListItem>
                ))}
              </List>
            </Box>
          </Grid2>
        </Grid2>

        {/* Action Buttons */}
        <Grid2 size={{ xs: 12 }}>
          <Box display='flex' flexDirection='row' justifyContent='end' gap={2}>
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
  );
}
