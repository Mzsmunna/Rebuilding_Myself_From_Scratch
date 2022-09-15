import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultGraphComponent } from './default-graph.component';

describe('DefaultGraphComponent', () => {
  let component: DefaultGraphComponent;
  let fixture: ComponentFixture<DefaultGraphComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultGraphComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultGraphComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
