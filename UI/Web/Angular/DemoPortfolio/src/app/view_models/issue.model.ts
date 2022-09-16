export interface Issue {
  Id: string;
  ProjectId: string;
  Title: string;
  Type: string;
  Summary: string;
  Description: string;
  AssignerName: string;
  AssignerId: string;
  AssignedName: string;
  AssignedId: string;
  StartDate: Date | null;
  EndDate: Date | null;
  DueDate: Date | null;
  Status: string;
  Comment: string;
  IsActive: boolean | null;
  IsDeleted: boolean | null;
  IsCompleted: boolean | null;
  CreatedOn: Date | null;
  ModifiedOn: Date | null;
  CreatedBy: string;
  ModifiedBy: string;
}
