import { TestBed } from '@angular/core/testing';

import { SchemaService } from './schema.service';

describe('SchemaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SchemaService = TestBed.inject(SchemaService);
    expect(service).toBeTruthy();
  });
});
