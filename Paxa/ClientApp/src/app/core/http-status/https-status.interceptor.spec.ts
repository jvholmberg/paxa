import { TestBed } from '@angular/core/testing';

import { HttpsStatusInterceptor } from './https-status.interceptor';

describe('HttpsStatusInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      HttpsStatusInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: HttpsStatusInterceptor = TestBed.inject(HttpsStatusInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
