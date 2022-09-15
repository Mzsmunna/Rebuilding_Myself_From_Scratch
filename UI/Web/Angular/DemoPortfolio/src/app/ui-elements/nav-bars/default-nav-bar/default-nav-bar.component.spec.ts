import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultNavBarComponent } from './default-nav-bar.component';

describe('DefaultNavBarComponent', () => {
  let component: DefaultNavBarComponent;
  let fixture: ComponentFixture<DefaultNavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultNavBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultNavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
