import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultAlertComponent } from './default-alert.component';

describe('DefaultAlertComponent', () => {
  let component: DefaultAlertComponent;
  let fixture: ComponentFixture<DefaultAlertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultAlertComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
