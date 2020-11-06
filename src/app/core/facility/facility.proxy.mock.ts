import { Observable } from 'rxjs';
import { FacilityProxy } from './facility.proxy.base';
import { Facility } from '@shared/models/facility.model';
import { simulate } from '@utils/api';

export class FacilityProxyMock implements FacilityProxy {

  getCollection(): Observable<Facility[]> {
    const response: Facility[] = [
      {
        id: 0,
        name: 'House of Padel',
        description: 'Description 1',
        location: { longitude: '', latitude: '' },
        resources: [
          { id: 100, name: 'Bana 1', type: { id: 200, name: 'Padel', description: '...'}, timeSlots: [] },
          { id: 101, name: 'Bana 2', type: { id: 200, name: 'Padel', description: '...'}, timeSlots: [] },
          { id: 102, name: 'Bana 3', type: { id: 200, name: 'Padel', description: '...'}, timeSlots: [] },
          { id: 103, name: 'Bana 4', type: { id: 200, name: 'Padel', description: '...'}, timeSlots: [] },
        ],
      },
      {
        id: 1,
        name: 'Sankt Jörgens',
        description: 'Description 2',
        location: { longitude: '', latitude: '' },
        resources: [
          { id: 104, name: 'Bana 1', type: { id: 200, name: 'Padel', description: '...'}, timeSlots: [] },
          { id: 105, name: 'Bana 2', type: { id: 200, name: 'Padel', description: '...'}, timeSlots: [] },
        ],
      },
    ];
    return simulate(response);
  }

  post(): Observable<Facility[]> {
    throw new Error("Method not implemented.");
  }

  delete(): Observable<Facility[]> {
    throw new Error("Method not implemented.");
  }

  update(): Observable<Facility[]> {
    throw new Error("Method not implemented.");
  }

}
