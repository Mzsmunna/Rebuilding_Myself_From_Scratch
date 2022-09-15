import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NgSmartTableComponent } from './ng-smart-table.component';

describe('NgSmartTableComponent', () => {
  let component: NgSmartTableComponent;
  let fixture: ComponentFixture<NgSmartTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NgSmartTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NgSmartTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
