import { Observable } from 'rxjs';
import { FacilityProxy } from './facility.proxy.base';
import { Facility } from '@shared/models/facility.model';

export class FacilityProxyMock implements FacilityProxy {

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
