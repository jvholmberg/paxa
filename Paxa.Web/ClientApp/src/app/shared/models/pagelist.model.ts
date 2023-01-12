export interface PageList<T> {
  pageInfo: PageInfo;
  records: T[];
}

interface PageInfo {
  startCursor: string;
  endCursor: string;
  totalRecords
}
