import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizationRemoveComponent } from './organization-remove.component';

describe('OrganizationRemoveComponent', () => {
  let component: OrganizationRemoveComponent;
  let fixture: ComponentFixture<OrganizationRemoveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganizationRemoveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganizationRemoveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
