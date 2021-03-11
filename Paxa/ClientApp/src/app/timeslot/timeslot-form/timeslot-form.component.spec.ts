import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeslotFormComponent } from './timeslot-form.component';

describe('TimeslotFormComponent', () => {
  let component: TimeslotFormComponent;
  let fixture: ComponentFixture<TimeslotFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeslotFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeslotFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
