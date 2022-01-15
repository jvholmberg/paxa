import { Address } from "@shared/models/address.model";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  address: Address;
  bookingIds: number[];
}
