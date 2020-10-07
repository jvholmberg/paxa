import { Observable } from 'rxjs';
import { Person } from 'src/app/shared/models/person.model';

export abstract class PersonProxy {
  abstract get(ids: number[]): Observable<Person[]>;
  abstract create(): Observable<Person[]>;
  abstract update(): Observable<Person[]>;
  abstract delete(): Observable<boolean>;
}
