import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceSchemaListViewComponent } from './resource-schema-list-view.component';

describe('ResourceSchemaListViewComponent', () => {
  let component: ResourceSchemaListViewComponent;
  let fixture: ComponentFixture<ResourceSchemaListViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceSchemaListViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceSchemaListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
