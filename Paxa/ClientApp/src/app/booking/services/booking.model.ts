import { User } from '@user/services/user.model';
import { Timeslot } from '@timeslot/services/timeslot.model';

export interface Booking {
  id: number;
  timeslot: Timeslot;
  users: User[];
}
