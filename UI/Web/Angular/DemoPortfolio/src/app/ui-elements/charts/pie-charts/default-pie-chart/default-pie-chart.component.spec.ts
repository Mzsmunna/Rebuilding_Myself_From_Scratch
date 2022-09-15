import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultPieChartComponent } from './default-pie-chart.component';

describe('DefaultPieChartComponent', () => {
  let component: DefaultPieChartComponent;
  let fixture: ComponentFixture<DefaultPieChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultPieChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultPieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
