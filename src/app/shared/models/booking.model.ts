import { User } from './user.model';
import { TimeSlot } from './time-slot.model';

export interface Booking {
  id: number;
  timeslot: TimeSlot;
  users: User[];
}
