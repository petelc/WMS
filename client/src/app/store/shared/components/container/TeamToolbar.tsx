import { Stack, Button } from '@mui/material';
import { PageHeaderToolbar } from '@toolpad/core/PageContainer/PageHeaderToolbar';
import DownloadIcon from '@mui/icons-material/Download';
import PrintIcon from '@mui/icons-material/Print';

export default function TeamToolbar() {
  return (
    <PageHeaderToolbar>
      <Stack direction='row' spacing={1} alignItems='center'>
        <Button
          variant='outlined'
          size='small'
          color='primary'
          startIcon={<DownloadIcon fontSize='inherit' />}
        >
          Download
        </Button>
        <Button
          variant='outlined'
          size='small'
          color='primary'
          startIcon={<PrintIcon fontSize='inherit' />}
        >
          Print
        </Button>
      </Stack>
    </PageHeaderToolbar>
  );
}
