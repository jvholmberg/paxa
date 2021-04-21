import { Address } from "@shared/models/address.model";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  address: Address;
  followerIds: number[];
  followingIds: number[];
  bookingIds: number[];
}
