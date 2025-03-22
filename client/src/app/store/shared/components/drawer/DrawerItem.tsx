import { Request } from '../../../../models/request';

type Props = {
  request: Request;
};

/**
 * This component will handle the drawer item
 * It will also handle rendering the request details
 * It will also handle updating the request details
 *
 * TODO : Implement request detail rendering logic
 * TODO : Implement request detail updating logic
 *
 * @param param request
 * @returns
 */

export default function DrawerItem({ request }: Props) {
  console.log(request);
  return (
    <div>
      <h3>Request Details</h3>
      {/* TODO: Render request details here */}
      <div>{JSON.stringify(request)}</div>
    </div>
  );
}
