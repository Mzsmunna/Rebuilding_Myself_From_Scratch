export interface User {
  Id: string;
  FirstName: string;
  LastName: string;
  Gender: string;
  BirthDate: Date | null;
  Age: number | null;
  Email: string;
  Password: string;
  RefreshToken: string;
  Role: string;
  IsActive: boolean | null;
  CreatedOn: Date | null;
  ModifiedOn: Date | null;
  CreatedBy: string;
  ModifiedBy: string;
}

export interface AssignUser {
  Id: string;
  Name: string;
  Email: string;
  Role: string;
}
