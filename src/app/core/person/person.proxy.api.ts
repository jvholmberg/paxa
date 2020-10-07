import { PersonProxy } from './person.proxy.base';
import { Observable } from 'rxjs';
import { Person } from 'src/app/shared/models/person.model';

export class PersonProxyApi implements PersonProxy {

  get(ids: number[]): Observable<Person[]> {
    throw new Error("Method not implemented.");
  }

  create(): Observable<Person[]> {
    throw new Error("Method not implemented.");
  }

  update(): Observable<Person[]> {
    throw new Error("Method not implemented.");
  }

  delete(): Observable<boolean> {
    throw new Error("Method not implemented.");
  }

}
