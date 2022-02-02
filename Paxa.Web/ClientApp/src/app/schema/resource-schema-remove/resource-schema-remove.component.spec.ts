import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceSchemaRemoveComponent } from './resource-schema-remove.component';

describe('ResourceSchemaRemoveComponent', () => {
  let component: ResourceSchemaRemoveComponent;
  let fixture: ComponentFixture<ResourceSchemaRemoveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceSchemaRemoveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceSchemaRemoveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
