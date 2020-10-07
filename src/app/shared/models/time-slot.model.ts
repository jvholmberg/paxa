import { Booking } from './booking.model';
import { Resource } from './resource.model';

export interface TimeSlot {
  id: number;
  from: Date;
  to: Date;
  resource: Resource;
  booking: Booking;
}
