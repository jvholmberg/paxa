export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  followerIds: number[];
  followingIds: number[];
  bookingIds: number[];
}
