import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceListViewComponent } from './resource-list-view.component';

describe('ResourceListViewComponent', () => {
  let component: ResourceListViewComponent;
  let fixture: ComponentFixture<ResourceListViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceListViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
