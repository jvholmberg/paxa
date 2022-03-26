import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TabStripComponent } from './tab-strip.component';

describe('TabStripComponent', () => {
  let component: TabStripComponent;
  let fixture: ComponentFixture<TabStripComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TabStripComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TabStripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
