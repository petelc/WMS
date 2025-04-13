import { AppProvider } from '@toolpad/core/AppProvider';
import { PageContainer } from '@toolpad/core/PageContainer';
import { Paper, Grid2 as Grid, Skeleton, Typography } from '@mui/material';

import { Request } from '../../../../models/request';
import TeamHeader from './TeamHeader';
import { NAVIGATION } from './TeamNavigation';
import { useTeamRouter } from './useTeamRouter';
import TeamRequestList from './TeamRequestList';

type Props = {
  requests: Request[];
};

export default function TeamContainer({ requests }: Props) {
  const router = useTeamRouter('/inbox/all');

  return (
    <AppProvider
      navigation={NAVIGATION}
      router={router}
      branding={{
        title: 'ACME Inc.',
      }}
    >
      <Paper sx={{ p: 2, width: '100%' }} elevation={1}>
        <PageContainer
          slots={{
            header: TeamHeader,
          }}
        >
          <Grid container spacing={1}>
            <Grid size={5} />
            <Grid size={12}>
              <Typography variant='h4' gutterBottom>
                Team Requests
              </Typography>
            </Grid>
            <Grid size={12}>
              <Skeleton height={14} />
            </Grid>
            <Grid size={5}>
              <TeamRequestList requests={requests} />
            </Grid>
            <Grid size={7}>
              <Paper>No Content</Paper>
            </Grid>
          </Grid>
        </PageContainer>
      </Paper>
    </AppProvider>
  );
}
