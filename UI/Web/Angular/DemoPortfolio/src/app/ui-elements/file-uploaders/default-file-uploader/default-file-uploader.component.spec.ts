import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultFileUploaderComponent } from './default-file-uploader.component';

describe('DefaultFileUploaderComponent', () => {
  let component: DefaultFileUploaderComponent;
  let fixture: ComponentFixture<DefaultFileUploaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultFileUploaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultFileUploaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
