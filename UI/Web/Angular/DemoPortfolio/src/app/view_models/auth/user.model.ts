export interface User {
  id: string;
  firstName: string;
  lastName: string;
  gender: string;
  age: number | null;
  email: string;
  password: string;
  refreshToken: string;
  role: string;
  isActive: boolean | null;
  createdOn: Date | null;
  modifiedOn: Date | null;
  createdBy: string;
  modifiedBy: string;
}
