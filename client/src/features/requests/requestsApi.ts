import { createApi } from '@reduxjs/toolkit/query/react';
import { baseQueryWithErrorHandling } from '../../app/api/baseApi';

import { RequestParams } from '../../app/models/requestParams';
import { Pagination } from '../../app/models/pagination';
import { Request } from '../../app/models/request';
import { filterEmptyValues } from '../../lib/util';

export const requestsApi = createApi({
  reducerPath: 'requestsApi',
  baseQuery: baseQueryWithErrorHandling,
  tagTypes: ['Request'],
  endpoints: (builder) => ({
    fetchRequests: builder.query<
      { items: Request[]; pagination: Pagination },
      RequestParams
    >({
      query(requestParams) {
        return {
          url: '/request',
          params: filterEmptyValues(requestParams),
        };
      },
      transformResponse: (items: Request[], meta) => {
        const paginationHeader = meta?.response?.headers.get('Pagination');
        const pagination = paginationHeader
          ? JSON.parse(paginationHeader)
          : null;
        return { items, pagination };
      },
    }),
    createRequest: builder.mutation<Request, FormData>({
      query: (data: FormData) => ({
        url: '/request',
        method: 'POST',
        body: data,
      }),
    }),
    createMandate: builder.mutation<void, { id: number; data: FormData }>({
      query: ({ id, data }) => {
        data.append('requestId', id.toString());

        return {
          url: '/request/mandate',
          method: 'POST',
          body: data,
        };
      },
    }),
  }),
});

export const {
  useFetchRequestsQuery,
  useCreateRequestMutation,
  useCreateMandateMutation,
} = requestsApi;
