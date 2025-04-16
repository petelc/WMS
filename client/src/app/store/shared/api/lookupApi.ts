import { createApi } from "@reduxjs/toolkit/query/react";
import { baseQueryWithErrorHandling } from "../../../api/baseApi";
import { TeamManager } from "../../../../lib/types/types";

export const lookupApi = createApi({
  reducerPath: "lookupApi",
  baseQuery: baseQueryWithErrorHandling,
  tagTypes: ["Lookup"],
  endpoints: (builder) => ({
    fetchPriorities: builder.query<{ priorities: [] }, void>({
      query: () => "/lookup/priorities",
    }),
    fetchRequestTypes: builder.query<{ requestTypes: [] }, void>({
      query: () => "/lookup/request-types",
    }),
    fetchApprovalStatuses: builder.query<{ approvalStatuses: [] }, void>({
      query: () => "/lookup/approval-statuses",
    }),
    fetchStatuses: builder.query<{ statuses: [] }, void>({
      query: () => "/lookup/request-statuses",
    }),
    fetchTeamManagers: builder.query<{ teamManagers: TeamManager[] }, void>({
      query: () => "/lookup/team-managers",
    }),
  }),
});

export const {
  useFetchPrioritiesQuery,
  useFetchRequestTypesQuery,
  useFetchApprovalStatusesQuery,
  useFetchStatusesQuery,
  useFetchTeamManagersQuery,
} = lookupApi;
