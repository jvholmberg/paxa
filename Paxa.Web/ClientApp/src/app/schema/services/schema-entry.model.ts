import { Weekday } from "@shared/services/lookup-service/weekday.model";

export interface SchemaEntry {
  id?: number;
  weekday: Weekday;
  fromTimestamp: string;
  toTimestamp: string;
}
