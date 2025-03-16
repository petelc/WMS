import { Grid2, Typography } from '@mui/material';

import { useFetchFiltersQuery, useFetchRequestsQuery } from './requestsApi';
import Filters from './Filters';
import { useAppSelector } from '../../app/store/store';
// import AppPagination from '../../app/store/shared/components/AppPagination';
// import { setPageNumber } from './requestSlice';
//import RequestTable from './RequestTable';
import { EnhancedTable as RequestTable } from '../../app/store/shared/components/enhancedtable/enhancedTable';
export default function RequestPage() {
  const requestParams = useAppSelector((state) => state.request);
  // const dispatch = useAppDispatch();
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
          <>
            <RequestTable rows={data.items} />
            {/* <AppPagination
              metadata={data.pagination}
              onPageChange={(page: number) => {
                dispatch(setPageNumber(page));
                window.scrollTo({ top: 0, behavior: 'smooth' });
              }}
            /> */}
          </>
        ) : (
          <Typography variant='h5'>No requests found</Typography>
        )}
      </Grid2>
    </Grid2>
  );
}
