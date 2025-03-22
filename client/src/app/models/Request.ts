export type Request = {
  id: number;
  requestedDate: Date;
  requestTitle: string;
  description: string;
  requestedBy: string;
  department: string;
  explainImpact: string;
  hasStakeholderConferred: boolean;
  proposedImpDate: Date;
  boardDate: Date;
  approvalDate: Date;
  denialDate: Date;
  policies: string[];
  relatedProjects: string[];
  isNew: boolean;
  isActive: boolean;
  sendToBoard: boolean;
  approvalStatus: string;
  // priority: string;
  priority: {
    id: number;
    priorityName: string;
    priorityLevel: number;
  };
  // requestType: string;
  requestType: {
    id: number;
    requestTypeName: string;
  };
  requestStatus: string;
};
