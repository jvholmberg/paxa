import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizationListViewComponent } from './organization-list-view.component';

describe('OrganizationListViewComponent', () => {
  let component: OrganizationListViewComponent;
  let fixture: ComponentFixture<OrganizationListViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganizationListViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganizationListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
