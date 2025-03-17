import { Grid2, Typography } from '@mui/material';

import { useFetchFiltersQuery, useFetchRequestsQuery } from './requestsApi';
import Filters from './Filters';
import { useAppSelector } from '../../app/store/store';
import { EnhancedTable as RequestTable } from '../../app/store/shared/components/enhancedtable/enhancedTable';

export default function RequestPage() {
  const requestParams = useAppSelector((state) => state.request);
  const { data, isLoading: requestsLoading } =
    useFetchRequestsQuery(requestParams);
  const { data: filtersData, isLoading: filtersLoading } =
    useFetchFiltersQuery();

  if (filtersLoading || requestsLoading) return <div>Loading...</div>;
  const defaultFiltersData = { priority: [], requestType: [] };

  return (
    <Grid2 container spacing={4}>
      <Grid2 size={3}>
        <Filters filtersData={filtersData || defaultFiltersData} />
      </Grid2>
      <Grid2 size={9}>
        {data?.items && data.items.length > 0 ? (
          <RequestTable rows={data.items} />
        ) : (
          <Typography variant='h5'>No requests found</Typography>
        )}
      </Grid2>
    </Grid2>
  );
}
