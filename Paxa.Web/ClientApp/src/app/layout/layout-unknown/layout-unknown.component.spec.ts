import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutUnknownComponent } from './layout-unknown.component';

describe('LayoutUnknownComponent', () => {
  let component: LayoutUnknownComponent;
  let fixture: ComponentFixture<LayoutUnknownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LayoutUnknownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LayoutUnknownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
