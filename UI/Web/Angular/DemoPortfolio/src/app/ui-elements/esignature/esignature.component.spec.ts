import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ESignatureComponent } from './esignature.component';

describe('ESignatureComponent', () => {
  let component: ESignatureComponent;
  let fixture: ComponentFixture<ESignatureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ESignatureComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ESignatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
