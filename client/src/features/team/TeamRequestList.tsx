import OpenInBrowserTwoTone from '@mui/icons-material/OpenInBrowserTwoTone';
import ShareIcon from '@mui/icons-material/Share';
import FolderIcon from '@mui/icons-material/Folder';
import CommentIcon from '@mui/icons-material/Comment';
import {
  Box,
  List,
  ListItem,
  IconButton,
  ListItemAvatar,
  Avatar,
  ListItemText,
} from '@mui/material';

import { Request } from '../../app/models/request';

type Props = {
  requests: Request[];
};

export default function TeamRequestList({ requests }: Props) {
  if (!requests || requests.length === 0) {
    return <div>No requests found</div>;
  }

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
                <IconButton edge='end' aria-label='assign'>
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
    </Box>
  );
}
