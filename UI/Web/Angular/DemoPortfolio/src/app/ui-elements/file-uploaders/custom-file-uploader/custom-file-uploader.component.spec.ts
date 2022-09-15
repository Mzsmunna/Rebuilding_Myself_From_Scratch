import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomFileUploaderComponent } from './custom-file-uploader.component';

describe('CustomFileUploaderComponent', () => {
  let component: CustomFileUploaderComponent;
  let fixture: ComponentFixture<CustomFileUploaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomFileUploaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomFileUploaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
