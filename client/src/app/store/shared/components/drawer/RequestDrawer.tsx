/**
 * This component renders the RequestDrawer.
 *
 * TODO : Pass in the selected request id to the drawer
 * TODO : Query the request details from the API
 * TODO : Render the request details in the drawer
 * TODO : Implement the request detail updating logic
 * TODO : Pass any needed functions and data to the DrawerItem component
 * TODO : Accept props for selected request id
 * @returns RequestDrawer component
 */

type RequestDrawerProps = {
  open: boolean;
  onClose: () => void;
  selectedRequestId: string;
};

const RequestDrawer: React.FC<RequestDrawerProps> = ({
  selectedRequestId,
  open,
  onClose,
}) => {
  return (
    <div>
      <h2>Request Drawer</h2>
      <p>Selected Request ID: {selectedRequestId}</p>
    </div>
  );
};

export default RequestDrawer;
