import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceSchemaEditComponent } from './resource-schema-edit.component';

describe('ResourceSchemaEditComponent', () => {
  let component: ResourceSchemaEditComponent;
  let fixture: ComponentFixture<ResourceSchemaEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceSchemaEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceSchemaEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
