import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultMapComponent } from './default-map.component';

describe('DefaultMapComponent', () => {
  let component: DefaultMapComponent;
  let fixture: ComponentFixture<DefaultMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultMapComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
