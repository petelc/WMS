import { useState } from 'react';
import {
  Box,
  List,
  ListItem,
  IconButton,
  ListItemAvatar,
  Avatar,
  ListItemText,
} from '@mui/material';
import OpenInBrowserTwoTone from '@mui/icons-material/OpenInBrowserTwoTone';
import ShareIcon from '@mui/icons-material/Share';
import FolderIcon from '@mui/icons-material/Folder';
import CommentIcon from '@mui/icons-material/Comment';

import { Request } from '../../app/models/request';
import { useUserInfoQuery, useEmployeeInfoQuery } from '../account/accountApi';
import { Employee } from '../../app/models/employee';
import TeamMemberModal from '../../app/store/shared/components/modals/TeamMemberModal';

type Props = {
  requests: Request[];
};

export default function TeamRequestList({ requests }: Props) {
  const { data: user } = useUserInfoQuery();
  const { data: teamMembers } = useEmployeeInfoQuery(user?.employeeId || 0);
  const [openModal, setOpenModal] = useState(false);

  let tm: Employee[] = [];
  // @ts-expect-error this is ok
  tm = teamMembers ? teamMembers : [];

  if (!requests || requests.length === 0) {
    return <div>No requests found</div>;
  }

  const handleOpenModal = () => {
    setOpenModal(true);
  };

  const handleCloseModal = () => {
    setOpenModal(false);
  };

  return (
    <Box sx={{ width: '100%', bgcolor: 'background.paper' }}>
      <List>
        {requests.map((request) => (
          <ListItem
            key={request.id}
            secondaryAction={
              <Box display='flex' flexDirection='row' gap={3}>
                <IconButton edge='end' aria-label='open'>
                  <OpenInBrowserTwoTone color='primary' />
                </IconButton>
                <IconButton
                  edge='end'
                  aria-label='assign'
                  onClick={handleOpenModal}
                >
                  <ShareIcon color='info' />
                </IconButton>
                <IconButton edge='end' aria-label='comment'>
                  <CommentIcon color='success' />
                </IconButton>
              </Box>
            }
          >
            <ListItemAvatar>
              <Avatar>
                <FolderIcon />
              </Avatar>
            </ListItemAvatar>
            <ListItemText
              primary={request.requestTitle}
              secondary={`Requested by: ${request.requestedBy}`}
            />
          </ListItem>
        ))}
      </List>
      {openModal && (
        <TeamMemberModal
          openModal={openModal}
          handleCloseModal={handleCloseModal}
          handleOpenModal={handleOpenModal}
          teamMembers={tm ?? []} // Pass the team members to the modal
        />
      )}
    </Box>
  );
}
