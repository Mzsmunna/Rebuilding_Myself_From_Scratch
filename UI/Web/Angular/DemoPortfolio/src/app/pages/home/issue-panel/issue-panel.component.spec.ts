import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssuePanelComponent } from './issue-panel.component';

describe('IssuePanelComponent', () => {
  let component: IssuePanelComponent;
  let fixture: ComponentFixture<IssuePanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IssuePanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IssuePanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
