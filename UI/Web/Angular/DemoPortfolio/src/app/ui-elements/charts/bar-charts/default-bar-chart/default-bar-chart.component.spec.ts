import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultBarChartComponent } from './default-bar-chart.component';

describe('DefaultBarChartComponent', () => {
  let component: DefaultBarChartComponent;
  let fixture: ComponentFixture<DefaultBarChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultBarChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultBarChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
