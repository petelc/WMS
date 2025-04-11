import { useFetchTeamRequestsQuery } from './teamApi';
import { useAppSelector } from '../../app/store/store';

export default function TeamPage() {
  const requestParams = useAppSelector((state) => state.request);
  const { data, isLoading } = useFetchTeamRequestsQuery(requestParams);
  if (isLoading) return <div>Loading...</div>;
  console.log(data);
  if (!data) return <div>No data found</div>;

  return <div>TeamPage</div>;
}
