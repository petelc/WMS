import { Grid2 as Grid, Paper, Typography } from '@mui/material';

import { useFetchTeamRequestsQuery } from './teamApi';
import { useAppSelector } from '../../app/store/store';
import RequestTable from '../../app/shared/components/table/RequestTable';
import TableHeader from '../../app/shared/components/table/TableHeader';
import TeamTableRow from '../../app/shared/components/table/team/TeamTableRow';
import MainTableBody from '../../app/shared/components/table/MainTableBody';

export default function TeamPagev1() {
  const requestParams = useAppSelector((state) => state.request);
  const { data, isLoading } = useFetchTeamRequestsQuery(requestParams);

  if (isLoading) return <div>Loading...</div>;

  if (!data) return <div>No data found</div>;

  return (
    <Paper
      sx={{ maxWidth: '100%', height: '100vh', pt: 1, pl: 2, pr: 2 }}
      square={false}
    >
      <Grid container spacing={4}>
        <Grid size={12}>
          {data?.items && data.items.length > 0 ? (
            <RequestTable requests={data.items}>
              <TableHeader
                order='asc'
                orderBy='requestTitle'
                onRequestSort={() => {}}
                numSelected={0}
                rowCount={data.items.length}
              />
              <MainTableBody>
                {data.items.map((request) => (
                  <TeamTableRow key={request.id} request={request} />
                ))}
              </MainTableBody>
            </RequestTable>
          ) : (
            <Typography variant='h5'>No requests found</Typography>
          )}
        </Grid>
      </Grid>
    </Paper>
  );
}
