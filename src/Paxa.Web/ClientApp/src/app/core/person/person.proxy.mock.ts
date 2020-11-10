import { PersonProxy } from './person.proxy.base';
import { Observable } from 'rxjs';
import { Person } from 'src/app/shared/models/person.model';
import { simulate } from '@utils/api';

export class PersonProxyMock implements PersonProxy {

  get(ids: number[]): Observable<Person[]> {
    const response: Person = {
      id: 0,
      firstName: 'Johan',
      lastName: 'Holmberg',
      bookingIds: [0],
      friends: [
        { id: 1, firstName: 'Joel', lastName: 'Holmberg', friends: [], bookingIds: [1] },
        { id: 2, firstName: 'Oliver', lastName: 'Holmberg', friends: [], bookingIds: [0, 2] },
      ],
    };
    return simulate(response);
  }

  post(): Observable<Person[]> {
    const response: Person = {
      id: 0,
      firstName: 'Johan',
      lastName: 'Holmberg',
      friends: [],
      bookingIds: [],
    };
    return simulate(response);
  }

  update(): Observable<Person[]> {
    const response: Person = { id: 0,
      firstName: 'Johan',
      lastName: 'Holmberg',
      bookingIds: [0],
      friends: [
        { id: 1, firstName: 'Joel', lastName: 'Holmberg', friends: [], bookingIds: [1] },
        { id: 2, firstName: 'Oliver', lastName: 'Holmberg', friends: [], bookingIds: [0, 2] },
        { id: 2, firstName: 'Bengt', lastName: 'Holmberg', friends: [], bookingIds: [0] },
      ],
    };
    return simulate(response);
  }

  delete(): Observable<boolean> {
    const response = true;
    return simulate(response);
  }

}
