import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchemaEntryListEdit } from './schema-entry-list-edit.component';

describe('SchemaEntryListEdit', () => {
  let component: SchemaEntryListEdit;
  let fixture: ComponentFixture<SchemaEntryListEdit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchemaEntryListEdit ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchemaEntryListEdit);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
