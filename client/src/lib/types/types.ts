export type approvalStatus = {
  id: number;
  ApprovalStatusName: string;
};

export type requestStatus = {
  id: number;
  RequestStatusName: string;
};

export type Priorities = {
  id: number;
  PriorityName: string;
  PriorityLevel: number;
};

export type RequestType = {
  id: number;
  requestTypeName: string;
};

export interface IRequest {
  requestTitle: string;
  requestedBy: string;
  department: string;
  explainImpact: string;
  sendToBoard: boolean;
  approvalStatus: {
    id: number;
    ApprovalStatusName: string;
  };
  stakeHolders: string;
  requestDate: Date;
  proposedImpDate: Date;
  boardDate: Date;
  approvalDate: Date;
  denialDate: Date;
  policies: string[];
  relatedProjects: string[];
  isNew: boolean;
  isActive: boolean;
  requestType: {
    id: number;
    requestTypeName: string;
  };
  requestStatus: {
    id: number;
    RequestStatusName: string;
  };
  priority: {
    id: number;
    PriorityName: string;
    PriorityLevel: number;
  };
  mandateBy: string[];
  mandateTitle: string;
  mandateDescription: string;
  requiredComplianceDate: string;
  codeRuleNums: string;
  internalUserCount: number;
  externalUserCount: number;
  newAutomationExplain: string;
  explainCostSavings: string;
  impactedClassifications: string[];
  impactedExternalJobTypes: string[];
  objectives: string;
  requirements: string;
  resources: string;
}
