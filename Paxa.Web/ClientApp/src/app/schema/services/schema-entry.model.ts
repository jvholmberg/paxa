import { Weekday } from "@shared/services/lookup-service/weekday.model";

export interface SchemaEntry {
  id?: number;
  weekday: Weekday;
  StartHour: number;
  StartMinute: number;
  StartSeconds: number;
  EndHour: number;
  EndMinute: number;
  EndSeconds: number;
}
