import { UserProxy } from './user.proxy.base';
import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/user.model';

export class UserProxyApi implements UserProxy {

  get(): Observable<User> {
    throw new Error("Method not implemented.");
  }

  post(): Observable<User> {
    throw new Error("Method not implemented.");
  }

  update(): Observable<User> {
    throw new Error("Method not implemented.");
  }

  delete(): Observable<boolean> {
    throw new Error("Method not implemented.");
  }

}
