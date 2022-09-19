export interface SearchField {
  Key: string;
  Value: string;
  DataType: string;
  DataSeparator: string;
  IsId: boolean;
  IsString: boolean;
  IsCaseSensitive: boolean;
  IsPartialMatch: boolean;
  IsBoolean: boolean;
  IsDateTime: boolean;
  IsAndQuery: boolean;
  IsEncrypted: boolean;
  QueryOrder: number;
}
