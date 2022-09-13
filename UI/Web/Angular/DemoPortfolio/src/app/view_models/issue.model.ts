export interface Issue {
  id: string;
  projectId: string;
  title: string;
  type: string;
  summary: string;
  description: string;
  assignerName: string;
  assignerId: string;
  assignedName: string;
  assignedId: string;
  startDate: Date | null;
  endDate: Date | null;
  dueDate: Date | null;
  status: string;
  comment: string;
  isActive: boolean | null;
  isDeleted: boolean | null;
  isCompleted: boolean | null;
  createdOn: Date | null;
  modifiedOn: Date | null;
  createdBy: string;
  modifiedBy: string;
}
