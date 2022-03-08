import { TestBed } from '@angular/core/testing';

import { LookupService } from './lookup.service';

describe('LookupService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LookupService = TestBed.inject(LookupService);
    expect(service).toBeTruthy();
  });
});
