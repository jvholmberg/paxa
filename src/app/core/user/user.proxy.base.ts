import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/user.model';

export abstract class UserProxy {
  abstract get(): Observable<User>;
  abstract post(): Observable<User>;
  abstract update(): Observable<User>;
  abstract delete(): Observable<boolean>;
}
