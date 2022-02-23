import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchemaListViewComponent } from './schema-list-view.component';

describe('SchemaListViewComponent', () => {
  let component: SchemaListViewComponent;
  let fixture: ComponentFixture<SchemaListViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchemaListViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchemaListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
