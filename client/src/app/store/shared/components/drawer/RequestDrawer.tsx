/**
 * This component renders the RequestDrawer.
 *
 * TODO : Pass in the selected request id to the drawer
 * TODO : Query the request details from the API
 * TODO : Render the request details in the drawer
 * TODO : Implement the request detail updating logic
 * TODO : Pass any needed functions and data to the DrawerItem component
 * TODO : Accept props for selected request id
 * @returns RequestDrawer component
 */

import { useState } from 'react';
import {
  Box,
  Divider,
  Drawer,
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
  styled,
  TextField,
  Typography,
  useTheme,
} from '@mui/material';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import dayjs from 'dayjs';

import { useFetchRequestDetailsQuery } from '../../../../../features/requests/requestsApi';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { RequestType } from '../../../../../lib/types/types';
import { useFetchRequestTypesQuery } from '../../api/lookupApi';

const drawerWidth = '75%';

type RequestDrawerProps = {
  open: boolean;
  setOpen: (open: boolean) => void;
  selectedRequestId: number | null;
  handleDrawerClose: () => void;
};

const DrawerHeader = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  padding: theme.spacing(0, 1),
  // necessary for content to be below app bar
  ...theme.mixins.toolbar,
  justifyContent: 'flex-start',
}));

const RequestDrawer: React.FC<RequestDrawerProps> = ({
  selectedRequestId,
  open,
  setOpen,
  handleDrawerClose,
}) => {
  const [requestType, setRequestType] = useState<string>('');
  const theme = useTheme();

  const { data: requestData, isLoading } = useFetchRequestDetailsQuery(
    +selectedRequestId!
  );

  const { data: requestTypes } = useFetchRequestTypesQuery();
  let rt: RequestType[] = [];
  // eslint-disable-next-line @typescript-eslint/ban-ts-comment
  // @ts-expect-error
  rt = requestTypes || [];

  if (!requestData || isLoading) return <div>Loading...</div>;

  console.log(selectedRequestId);

  const handleRequestTypeChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    requestData.requestType = {
      id: Number(event.target.value),
      requestTypeName: rt.filter(
        (type) => type.id === Number(event.target.value)
      )[0].requestTypeName,
    };
    setRequestType(event.target.value);
  };

  return (
    <Drawer
      // onClose={() => setOpen(false)}
      sx={{
        width: drawerWidth,
        flexShrink: 0,
        '& .MuiDrawer-paper': {
          width: drawerWidth,
          boxSizing: 'border-box',
        },
      }}
      variant='persistent'
      anchor='right'
      open={open}
    >
      <DrawerHeader>
        <IconButton onClick={handleDrawerClose}>
          {theme.direction === 'rtl' ? (
            <>
              <ChevronLeftIcon />
            </>
          ) : (
            <ChevronRightIcon />
          )}
        </IconButton>
        <Typography variant='subtitle2'>Close</Typography>
      </DrawerHeader>
      <Divider />
      <div role='presentation' onClick={() => setOpen(false)}>
        <Box
          width='100%'
          display='flex'
          flexDirection='column'
          gap={3}
          marginY={3}
          sx={{
            paddingLeft: 4,
            paddingRight: 4,
            paddingBottom: 4,
            paddingTop: 2,
          }}
        >
          <Grid2 container spacing={2}>
            <Grid2 size={{ xs: 6, md: 8 }}>
              <TextField
                fullWidth
                label='Title'
                name='requestTitle'
                value={requestData.requestTitle}
              />
            </Grid2>
            <Grid2 size={{ xs: 6, md: 4 }}>
              <TextField fullWidth label='Project #' disabled />
            </Grid2>
            <Grid2 size={{ xs: 6, md: 6 }}>
              <TextField
                fullWidth
                label='Requested By'
                name='requestedBy'
                value={requestData.requestedBy}
              />
            </Grid2>
            <Grid2 size={{ xs: 6, md: 2 }}>
              <TextField
                fullWidth
                label='Department'
                name='department'
                value={requestData.department}
              />
            </Grid2>
            <Grid2 size={{ xs: 6, md: 4 }}>
              <DatePicker
                label='Request Date'
                name='requestDate'
                value={dayjs(requestData.requestedDate)}
              />
            </Grid2>
            <Grid2 size={12}>
              <TextField
                fullWidth
                label='Explain Impact'
                name='explainImpact'
                value={requestData.explainImpact}
                multiline
                rows={4}
              />
            </Grid2>
            <Grid2 size={12}>
              <Divider variant='middle' sx={{ mt: 4, mb: 4 }} />
            </Grid2>

            <Grid2 size={{ xs: 6, md: 6 }}>
              <FormControl id='requestTypeGroup'>
                <FormLabel component='legend'>Request Type</FormLabel>
                <RadioGroup
                  name='requestTypeGroup'
                  value={requestData.requestType}
                  onChange={handleRequestTypeChange}
                  row
                >
                  {rt?.map((type) => {
                    const { id, requestTypeName } = type;

                    return (
                      <FormControlLabel
                        key={id}
                        value={id}
                        control={<Radio />}
                        label={requestTypeName}
                      />
                    );
                  })}
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
                  value={requestData.hasStakeholderConferred}
                  row
                >
                  <FormControlLabel
                    value='Yes'
                    control={<Radio />}
                    label='Yes'
                  />
                  <FormControlLabel value='No' control={<Radio />} label='No' />
                </RadioGroup>
              </FormControl>
            </Grid2>
            <Grid2 container size={12} spacing={8} sx={{ mt: 4 }}>
              <Grid2 size={{ xs: 6, md: 4 }}>
                <Typography variant='subtitle1' gutterBottom>
                  List any DRC Policies that apply
                </Typography>
                <Box display='flex' flexDirection='column' gap={2}>
                  {/* <Box display='flex' flexDirection='row' gap={2}>
                    <TextField
                      label='Policy'
                      id='policy'
                      value={newPolicy}
                      onChange={handlePolicyTextChange}
                    />
                    <Button variant='contained' onClick={handleAddPolicy}>
                      Add
                    </Button>
                  </Box> */}
                  <List>
                    {requestData.policies.map((item, index) => (
                      <ListItem key={index}>
                        <ListItemText primary={item} />
                        {/* <IconButton
                          edge='end'
                          aria-label='delete'
                          onClick={() => handleDeletePolicy(index)}
                        >
                          <DeleteIcon />
                        </IconButton> */}
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
                  {/* <Box display='flex' flexDirection='row' gap={2}>
                    <TextField
                      label='Related Projects'
                      id='relatedProjects'
                      value={newProject}
                      onChange={handleProjectTextChange}
                    />
                    <Button variant='contained' onClick={handleAddProject}>
                      Add
                    </Button>
                  </Box> */}
                  <List>
                    {requestData.relatedProjects.map((item, index) => (
                      <ListItem
                        key={index}
                        // secondaryAction={
                        //   <IconButton
                        //     edge='end'
                        //     aria-label='delete'
                        //     onClick={() => handleDeleteProject(index)}
                        //   >
                        //     <DeleteIcon />
                        //   </IconButton>
                        // }
                      >
                        <ListItemText primary={item} />
                      </ListItem>
                    ))}
                  </List>
                </Box>
              </Grid2>
              <Grid2 size={{ xs: 12 }}>
                <Box
                  display='flex'
                  flexDirection='row'
                  justifyContent='end'
                  gap={2}
                ></Box>
              </Grid2>
            </Grid2>
          </Grid2>
        </Box>
      </div>
    </Drawer>
  );
};

export default RequestDrawer;
