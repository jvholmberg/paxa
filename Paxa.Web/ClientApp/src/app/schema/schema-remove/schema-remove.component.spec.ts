import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchemaRemoveComponent } from './schema-remove.component';

describe('SchemaRemoveComponent', () => {
  let component: SchemaRemoveComponent;
  let fixture: ComponentFixture<SchemaRemoveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchemaRemoveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchemaRemoveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
