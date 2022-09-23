export interface Pager {

  TotalDataCount: number;
  TotalDataFetch: number;
  CurrentData: number;
  CurrentDataStartRange: number;
  CurrentDataEndRange: number;
  CurrentPage: number;
  TotalPage: number;
  PageSize: number;
  SortField: string;
  SortDirection: string;
  IsLoading: boolean;
  IsPageChanged: boolean;
}
