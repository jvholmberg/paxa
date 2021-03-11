import { Location } from '@shared/models/location.model';

export interface Organization {
  id: number;
  name: string;
  description: string;
  location: Location;
  resourceIds: number[];
}
