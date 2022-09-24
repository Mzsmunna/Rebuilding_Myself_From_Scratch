export interface Issue {
  Id: string;
  ProjectId: string;
  Title: string;
  Type: string;
  Summary: string;
  Description: string;
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

export interface IssueStat {
  //Id: string;
  Status: string;
  Count: string;
}

export interface IssueProgress {
  Pending: number;
  PendingRatio: number;
  InProgress: number;
  InProgressRatio: number;
  Done: number;
  DoneRatio: number;
  Discarded: number;
  DiscardedRatio: number;
  Total: number;
  TotalRatio: number;
}
