import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchemaExecuteComponent } from './schema-execute.component';

describe('SchemaExecuteComponent', () => {
  let component: SchemaExecuteComponent;
  let fixture: ComponentFixture<SchemaExecuteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchemaExecuteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchemaExecuteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
