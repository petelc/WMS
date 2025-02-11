import { z } from 'zod';

export const RequestSchema = z.object({
  requestTitle: z.string().min(3, {
    message: 'Title must be at least 3 characters',
  }),
  description: z.string().min(10, {
    message: 'Description must be at least 10 characters',
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
  explainImpact: z.string().min(10, {
    message: 'Please explain the impact of not doing this project',
  }),
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
});

export type RequestSchema = z.infer<typeof RequestSchema>;
