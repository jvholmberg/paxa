import { UserProxy } from './user.proxy.base';
import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/user.model';
import { simulate } from '@utils/mocks/api';

export class UserProxyMock implements UserProxy {

  get(): Observable<User> {
    const response: User = { id: 0, personId: 0, email: 'get_johan@paxa.se' };
    return simulate(response);
  }

  create(): Observable<User> {
    const response: User = { id: 0, personId: 0, email: 'create_johan@paxa.se' };
    return simulate(response);
  }

  update(): Observable<User> {
    const response: User = { id: 0, personId: 0, email: 'update_johan@paxa.se' };
    return simulate(response);
  }

  delete(): Observable<boolean> {
    const response = true;
    return simulate(response);
  }

}
