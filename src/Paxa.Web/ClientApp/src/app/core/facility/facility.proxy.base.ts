import { Observable } from 'rxjs';
import { Facility } from 'src/app/shared/models/facility.model';

export abstract class FacilityProxy {
  abstract getCollection(): Observable<Facility[]>;
  abstract post(): Observable<Facility[]>;
  abstract delete(): Observable<Facility[]>;
  abstract update(): Observable<Facility[]>;
}
