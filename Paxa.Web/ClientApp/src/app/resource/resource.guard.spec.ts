import { TestBed } from '@angular/core/testing';

import { ResourceGuard } from './resource.guard';

describe('ResourceGuard', () => {
  let guard: ResourceGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ResourceGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
