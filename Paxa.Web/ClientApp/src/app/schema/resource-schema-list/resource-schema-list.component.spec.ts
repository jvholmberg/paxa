import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ResourceSchemaListComponent } from './resource-schema-list.component';

describe('ResourceSchemaListComponent', () => {
  let component: ResourceSchemaListComponent;
  let fixture: ComponentFixture<ResourceSchemaListComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ResourceSchemaListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceSchemaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
