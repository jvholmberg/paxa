import { ResourceProxy } from './resource.proxy.base';
import { Observable } from 'rxjs';
import { Resource } from 'src/app/shared/models/resource.model';

export class ResourceProxyApi implements ResourceProxy {

  getCollection(): Observable<Resource[]> {
    throw new Error("Method not implemented.");
  }

  post(): Observable<Resource[]> {
    throw new Error("Method not implemented.");
  }

  delete(): Observable<Resource[]> {
    throw new Error("Method not implemented.");
  }

  update(): Observable<Resource[]> {
    throw new Error("Method not implemented.");
  }

}
