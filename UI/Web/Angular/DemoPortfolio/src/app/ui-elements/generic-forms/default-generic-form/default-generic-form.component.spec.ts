import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultGenericFormComponent } from './default-generic-form.component';

describe('DefaultGenericFormComponent', () => {
  let component: DefaultGenericFormComponent;
  let fixture: ComponentFixture<DefaultGenericFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultGenericFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultGenericFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
