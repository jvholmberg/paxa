import { TestBed } from '@angular/core/testing';

import { BaseService } from './base.service';

describe('BaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BaseService<boolean> = TestBed.inject(BaseService);
    expect(service).toBeTruthy();
  });
});
