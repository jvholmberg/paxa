import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceRemoveComponent } from './resource-remove.component';

describe('ResourceRemoveComponent', () => {
  let component: ResourceRemoveComponent;
  let fixture: ComponentFixture<ResourceRemoveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceRemoveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceRemoveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
