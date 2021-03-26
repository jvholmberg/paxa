import { Organization } from "@organization/services/organization.model";
import { Person } from "@person/services/person.model";

export interface User {
  id: number;
  person?: Person;
  organization?: Organization;
  email: string;
}
