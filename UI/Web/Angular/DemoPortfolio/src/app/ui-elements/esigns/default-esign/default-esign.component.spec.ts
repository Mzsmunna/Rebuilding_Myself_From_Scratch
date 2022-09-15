import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultEsignComponent } from './default-esign.component';

describe('DefaultEsignComponent', () => {
  let component: DefaultEsignComponent;
  let fixture: ComponentFixture<DefaultEsignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultEsignComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultEsignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
