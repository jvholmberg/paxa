import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceSchemaViewComponent } from './resource-schema-view.component';

describe('ResourceSchemaViewComponent', () => {
  let component: ResourceSchemaViewComponent;
  let fixture: ComponentFixture<ResourceSchemaViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceSchemaViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceSchemaViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
