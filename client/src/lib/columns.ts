import { GridColDef } from '@mui/x-data-grid';

export const columns: GridColDef<rows[number]>[] = [
  { field: 'id', headerName: 'ID', width: 90 },
  { field: 'requestDate', headerName: 'Request Date', width: 150 },
  { field: 'requestTitle', headerName: 'Request Title', width: 200 },
  { field: 'requestedBy', headerName: 'Requested By', width: 150 },
  { field: 'requestType', headerName: 'Request Type', width: 150 },
  { field: 'priority', headerName: 'Priority', width: 150 },
];

export type rows = [
  {
    id: number;
    requestDate: Date;
    requestTitle: string;
    requestedBy: string;
    requestType: string;
    priority: string;
  }
]; // Example data, replace with your actual data
// Compare this snippet from client/src/features/requests/new/ScopeForm.tsx:
