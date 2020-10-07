export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  friends: Person[];
  bookingIds: number[];
}
