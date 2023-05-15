import { IUser } from "./user";
export interface UserData {
  totalCount: number;
  totalPages: number;
  currentPage: number;
  pageSize: number;
  data: IUser[];
}
