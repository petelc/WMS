import { DataGrid } from '@mui/x-data-grid';
import { Box, Typography } from '@mui/material';

import { Request } from '../../app/models/request';
import { columns } from '../../lib/columns';

type Props = {
  requests: Request[];
};

export default function RequestTable({ requests }: Props) {
  console.log(requests);
  return (
    <Box sx={{ height: '100%', width: '100%' }}>
      <Typography variant='h5' marginBottom={2}>
        Requests
      </Typography>
      <Typography variant='body2' marginBottom={4}>
        Select the requests you want to view so you can submit the request to
        the CAB board or submit the request to the appropriate team.
      </Typography>

      <Box sx={{ height: 550, width: '100%' }}>
        <DataGrid
          rows={requests}
          columns={columns}
          initialState={{
            pagination: {
              paginationModel: { page: 0, pageSize: 8 },
            },
          }}
          pageSizeOptions={[8]}
          checkboxSelection
          getRowId={(row) => row.id}
        />
      </Box>
    </Box>
  );
}
