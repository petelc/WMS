import { useState } from 'react';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Typography from '@mui/material/Typography';
import {
  Button,
  Checkbox,
  FormControl,
  MenuItem,
  OutlinedInput,
  Select,
  SelectChangeEvent,
} from '@mui/material';

import { TeamManager } from '../../../../../lib/types/types';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

type Props = {
  handleCloseModal: () => void;
  handleOpenModal: () => void; // If you have a function to perform additional actions when opening the modal);
  openModal: boolean; // This should be a boolean to control the visibility of the modal
  teamManagers: TeamManager[] | []; // Optional prop to pass team managers directly if needed
};

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

export default function TeamManagerModal({
  handleCloseModal,
  openModal,
  teamManagers,
}: Props) {
  const [manager, setManager] = useState<string[]>([]);

  const handleChange = (event: SelectChangeEvent<typeof manager>) => {
    const {
      target: { value },
    } = event;
    setManager(
      // On autofill we get a stringified value.
      typeof value === 'string' ? value.split(',') : value
    );
  };

  return (
    <div>
      <Modal
        open={openModal}
        onClose={handleCloseModal}
        aria-labelledby='modal-modal-title'
        aria-describedby='modal-modal-description'
      >
        <Box sx={style}>
          <Typography id='modal-modal-title' variant='h6' component='h2'>
            Select Team Manager
          </Typography>
          <FormControl sx={{ m: 1, width: 300 }}>
            <Select
              labelId='modal-modal-title'
              id='demo-multiple-checkbox'
              multiple
              value={manager}
              onChange={handleChange}
              input={<OutlinedInput label='Tag' />}
              renderValue={(selected) => selected.join(', ')}
              MenuProps={MenuProps}
            >
              {teamManagers?.map((name) => {
                const { id, email } = name; // Destructure the id and email from the team manager object
                return (
                  <MenuItem key={id} value={email}>
                    <Checkbox checked={manager.includes(email)} />
                    {name.email}
                  </MenuItem>
                );
              })}
            </Select>
          </FormControl>
          <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
            <Button sx={{ marginTop: 2 }} variant='contained'>
              Submit
            </Button>
          </Box>
        </Box>
      </Modal>
    </div>
  );
}
