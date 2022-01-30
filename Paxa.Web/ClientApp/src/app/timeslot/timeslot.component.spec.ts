import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeslotComponent } from './timeslot.component';

describe('TimeslotComponent', () => {
  let component: TimeslotComponent;
  let fixture: ComponentFixture<TimeslotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeslotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeslotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
