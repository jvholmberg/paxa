import { SchemaEntry } from "./schema-entry.model";

export interface Schema {
  id?: number;
  name: string;
  active: boolean;
  organizationId: number;
  schemaEntries: SchemaEntry[];
}
