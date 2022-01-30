import { ResourceType } from "./resource-type.model";

export interface Resource {
  id: number;
  organizationId: number;
  name: string;
  type: ResourceType;
  timeslotIds: number[];
}
