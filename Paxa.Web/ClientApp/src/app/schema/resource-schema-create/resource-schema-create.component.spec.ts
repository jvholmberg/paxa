import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceSchemaCreateComponent } from './resource-schema-create.component';

describe('ResourceSchemaCreateComponent', () => {
  let component: ResourceSchemaCreateComponent;
  let fixture: ComponentFixture<ResourceSchemaCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceSchemaCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceSchemaCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
