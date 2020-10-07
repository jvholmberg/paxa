import { Resource } from './resource.model';

export interface Facility {
  id: number;
  name: string;
  description: string;
  resources: Resource[];
}
