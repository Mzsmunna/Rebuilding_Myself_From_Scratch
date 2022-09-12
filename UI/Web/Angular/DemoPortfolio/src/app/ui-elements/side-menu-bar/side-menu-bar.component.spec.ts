import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideMenuBarComponent } from './side-menu-bar.component';

describe('SideMenuBarComponent', () => {
  let component: SideMenuBarComponent;
  let fixture: ComponentFixture<SideMenuBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SideMenuBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SideMenuBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
