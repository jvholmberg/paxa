import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchemaEntryListCreate } from './schema-entry-list-create.component';

describe('SchemaEntryListCreate', () => {
  let component: SchemaEntryListCreate;
  let fixture: ComponentFixture<SchemaEntryListCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchemaEntryListCreate ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchemaEntryListCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
