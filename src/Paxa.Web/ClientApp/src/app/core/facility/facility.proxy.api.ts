import { FacilityProxy } from './facility.proxy.base';
import { Observable } from 'rxjs';
import { Facility } from 'src/app/shared/models/facility.model';

export class FacilityProxyApi implements FacilityProxy {

  getCollection(): Observable<Facility[]> {
    throw new Error("Method not implemented.");
  }

  create(): Observable<Facility[]> {
    throw new Error("Method not implemented.");
  }

  delete(): Observable<Facility[]> {
    throw new Error("Method not implemented.");
  }

  update(): Observable<Facility[]> {
    throw new Error("Method not implemented.");
  }

}
