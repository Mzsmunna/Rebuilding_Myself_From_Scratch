import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AngularDataTableComponent } from './angular-data-table.component';

describe('AngularDataTableComponent', () => {
  let component: AngularDataTableComponent;
  let fixture: ComponentFixture<AngularDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AngularDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AngularDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
