import { Observable } from 'rxjs';
import { Resource } from 'src/app/shared/models/resource.model';

export abstract class ResourceProxy {
  abstract getCollection(): Observable<Resource[]>;
  abstract create(): Observable<Resource[]>;
  abstract delete(): Observable<Resource[]>;
  abstract update(): Observable<Resource[]>;
}
