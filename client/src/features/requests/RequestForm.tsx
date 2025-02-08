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
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { useState } from 'react';
import { RequestSchema } from '../../lib/schemas/requestSchema';
import { FieldValues, useForm } from 'react-hook-form';
import AppTextInput from '../../app/store/shared/components/AppTextInput';
import { zodResolver } from '@hookform/resolvers/zod';
import { handleApiError } from '../../lib/util';
import { useCreateRequestMutation } from './requestsApi';

// type Props = {
//   setRequest: (request: RequestSchema) => void;
//   request: RequestSchema;
// };

export default function RequestForm() {
  const { control, handleSubmit, setError } = useForm<RequestSchema>({
    mode: 'onTouched',
    resolver: zodResolver(RequestSchema),
  });
  const [value, setValue] = useState('');
  const [stakeHolders, setStakeHolders] = useState('');
  const [policy, setPolicy] = useState(['01-COM-01']);
  const [project, setProject] = useState(['Project 1']);
  const [createRequest] = useCreateRequestMutation();
  const [requestId, setRequestId] = useState<number>(0);
  //const [request, setRequest] = useState<RequestSchema>({
  //   title: '',
  //   description: '',
  // });

  // ? Form Action Functions
  const handleTypeOnChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setValue(event.target.value);
  };

  const handleStakeHoldersOnChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setStakeHolders(event.target.value);
  };

  const handleAddPolicy = () => {
    setPolicy((prev) => [...prev, 'Policy 1']);
  };

  const handleAddProject = () => {
    setProject((prev) => [...prev, 'Project 2']);
  };

  const createFormData = (items: FieldValues) => {
    const formData = new FormData();
    for (const key in items) {
      formData.append(key, items[key]);
    }

    return formData;
  };

  const handleRequestSubmit = async (data: RequestSchema) => {
    try {
      const formData = createFormData(data);
      const response = await createRequest(formData).unwrap();
      setRequestId(response.id);
      console.log(requestId);
      console.log('Request Submitted');
    } catch (error) {
      console.error(error);
      handleApiError<RequestSchema>(error, setError, ['title', 'description']);
    }
    // setRequest(data);
    // console.log(request);
    // onRequestSubmit(request);
  };

  return (
    <Box
      component='form'
      width='100%'
      onSubmit={handleSubmit(handleRequestSubmit)}
      display='flex'
      flexDirection='column'
      gap={3}
      marginY={3}
    >
      <Grid2 container spacing={2}>
        <Grid2 size={{ xs: 6, md: 8 }}>
          <AppTextInput
            control={control}
            fullWidth
            label='Title'
            name='title'
          />
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
          <DatePicker label='Request Date' />
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
              onChange={handleTypeOnChange}
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
              value={stakeHolders}
              onChange={handleStakeHoldersOnChange}
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
      </Grid2>
    </Box>
  );
}

// <Grid2 size={{ xs: 12 }}>
// <Box display='flex' flexDirection='row' justifyContent='end' gap={2}>
//   <Button
//     variant='contained'
//     color='primary'
//     type='submit'
//     // disabled={isLoading || !isValid}
//   >
//     Submit Request
//   </Button>
//   <Button
//     variant='contained'
//     color='error'
//     type='submit'
//     // disabled={isLoading || !isValid}
//   >
//     Cancel
//   </Button>
// </Box>
// </Grid2>
