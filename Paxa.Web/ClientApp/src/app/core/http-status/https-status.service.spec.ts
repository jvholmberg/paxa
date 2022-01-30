import { TestBed } from '@angular/core/testing';

import { HttpsStatusService } from './https-status.service';

describe('HttpsStatusService', () => {
  let service: HttpsStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpsStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
