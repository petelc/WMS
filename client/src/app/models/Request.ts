export type Request = {
  id: number;
  requestDate: Date;
  requestTitle: string;
  description: string;
  isNew: boolean;
  isActive: boolean;
  sendToBoard: boolean;
  boardDate: Date;
  approvalDate: Date;
  denialDate: Date;
  approvalStatus: string;
  priority: string;
  requestType: string;
  requestStatus: string;
};
