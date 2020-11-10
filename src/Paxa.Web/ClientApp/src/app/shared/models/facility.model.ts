import { Resource } from './resource.model';
import { Location } from './location.model';

export interface Facility {
  id: number;
  name: string;
  description: string;
  location: Location;
  resources: Resource[];
}
