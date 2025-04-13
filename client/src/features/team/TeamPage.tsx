import { Grid2 as Grid, Typography } from '@mui/material';

import { useFetchTeamRequestsQuery } from './teamApi';
import { useAppSelector } from '../../app/store/store';
import TeamContainer from '../../app/store/shared/components/container/TeamContainer';

export default function TeamPage() {
  const requestParams = useAppSelector((state) => state.request);
  const { data, isLoading } = useFetchTeamRequestsQuery(requestParams);

  if (isLoading) return <div>Loading...</div>;

  if (!data) return <div>No data found</div>;

  console.log(data.items);
  return (
    <Grid container>
      {data?.items && data.items.length > 0 ? (
        <TeamContainer requests={data.items} />
      ) : (
        <Typography variant='h5'>No requests found</Typography>
      )}
    </Grid>
  );
}
