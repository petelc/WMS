import { PageHeader } from '@toolpad/core/PageContainer/PageHeader';
import TeamToolbar from './TeamToolbar';

export default function CustomPageHeader() {
  return <PageHeader slots={{ toolbar: TeamToolbar }} />;
}
