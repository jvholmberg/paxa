import { ResourceType } from './resource-type.model';
import { TimeSlot } from './time-slot.model';

export interface Resource {
  id: number;
  name: string;
  type: ResourceType;
  timeSlots: TimeSlot[];
}
