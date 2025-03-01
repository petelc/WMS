import { z } from 'zod';

export const RequestSchema = z.object({
  requestTitle: z.string().min(3, {
    message: 'Title must be at least 3 characters',
  }),
  explainImpact: z.string().min(10, {
    message: 'Please explain the impact of not doing this project',
  }),
  requestedBy: z
    .string()
    .min(3, {
      message: 'Requester name must be at least 3 characters',
    })
    .max(50, {
      message: 'Requester name must be less than 50 characters',
    }),
  department: z.string().min(2, {
    message: 'Department must be at least 2 characters',
  }),

  stakeHolders: z.string().min(10, {
    message: 'Please list the stakeholders',
  }),
  requestDate: z.date(),
  proposedImpDate: z.date(),
  boardDate: z.date(),
  approvalDate: z.date(),
  denialDate: z.date(),
  policies: z.array(z.string()),
  relatedProjects: z.array(z.string()),
  isNew: z.boolean(),
  isActive: z.boolean(),
  sendToBoard: z.boolean(),
  approvalStatus: z.string(),
  priority: z.string(),
  requestType: z.string(),
  requestStatus: z.string(),
  // mandate
  mandateBy: z.array(z.string()),
  mandateTitle: z.string(),
  mandateDescription: z.string(),
  requiredComplianceDate: z.date(),
  codeRuleNums: z.array(z.string()),
  // impact
  internalUserCount: z.number(),
  externalUserCount: z.number(),
  newAutomationExplain: z.string(),
  explainCostSavings: z.string(),
  impactedClassifications: z.array(z.string()),
  impactedExternalJobTypes: z.array(z.string()),
  // scope
  objectives: z.string(),
  requirements: z.string(),
  resources: z.string(),
});

export type RequestSchema = z.infer<typeof RequestSchema>;
